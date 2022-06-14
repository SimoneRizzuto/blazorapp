using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Microsoft.AspNetCore.StaticFiles;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitHub;
using Nuke.Common.Utilities.Collections;
using Nuke.Common.Tools.GitVersion;
using Octokit;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.GitHub.GitHubTasks;


[GitHubActions(
    "Nuke-CheckBuilds",
    GitHubActionsImage.WindowsLatest,
    InvokedTargets = new[] { nameof(Compile) },
    OnPushBranches = new[] { "main" },
    AutoGenerate = true)]
[CheckBuildProjectConfigurations]
[ShutdownDotNetAfterServerBuild]

class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main () => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution(GenerateProjects = true)] readonly Solution Solution;
    [GitRepository] readonly GitRepository GitRepository;

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath TestsDirectory => RootDirectory / "tests";
    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            EnsureCleanDirectory(ArtifactsDirectory);
        });

    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .EnableNoRestore());
        });

    IProcess ApiProcess;
    Target StartApi => _ => _
        .TriggeredBy(Compile)
        .Executes(() =>
        {
            ApiProcess = ProcessTasks.StartProcess("dotnet", "run", RootDirectory / "Book\\BookStoreApp.API");
        })
        .Triggers(BookStoreAppServer, BookStoreAppWASM);
    
    Target BookStoreAppServer => _ => _
        .DependsOn(Compile, StartApi)
        .Triggers(StopApi)
        .Executes(() =>
        {
            DotNetTest(s => s
                .SetProjectFile(RootDirectory / "Book\\BookStoreApp.Blazor.Server.UI")
                .EnableNoRestore()
                .EnableNoBuild());
        });

    Target BookStoreAppWASM => _ => _
        .DependsOn(Compile, StartApi)
        .Triggers(StopApi)
        .Executes(() =>
        {
            DotNetTest(s => s
                .SetProjectFile(RootDirectory / "Book\\BookStoreApp.Blazor.WebAssembly.UI")
                .EnableNoRestore()
                .EnableNoBuild());
        });

    Target StopApi => _ => _
        .DependsOn(BookStoreAppServer, BookStoreAppWASM)
        .Triggers(PushToAzure)
        .Executes(() =>
        {
            ApiProcess.Kill();
        });

    Target PushToAzure => _ => _
        .DependsOn(StopApi)
        .Executes(() =>
        {
            var projects = new[]
            {
                Solution.BookStoreApp_Blazor_Server_UI,
                Solution.BookStoreApp_Blazor_WebAssembly_UI,
                Solution.BookStoreApp_API,
            };
            var publishConfigurations =
                from project in projects
                from framework in project.GetTargetFrameworks()
                select (project, framework);

            DotNetPublish(_ => _
                .SetProject(Solution)
                .SetConfiguration(Configuration)
                .CombineWith(publishConfigurations, (_, v) => _
                    .SetProject(v.project)
                    .SetFramework(v.framework)
                    .SetOutput(ArtifactsDirectory / v.project.Name)
                ));

            // Go through each project and Zip files to artifacts folder. Name files according to project
            EnsureExistingDirectory(ArtifactsDirectory);
            foreach (var project in projects)
            {
                var zipFile = $"{ArtifactsDirectory}/{project.Name}.1.0.0.zip";
                ZipPublishFolder(zipFile, ArtifactsDirectory / project.Name);
            }
        });

    static void ZipPublishFolder(string zipFileToCreate, string folderToPackage,
        CompressionLevel compressionLevel = CompressionLevel.Optimal)
    {
        Logger.Info($"Creating {zipFileToCreate} from {folderToPackage}\\**");
        ZipFile.CreateFromDirectory(folderToPackage, zipFileToCreate, compressionLevel, false);
    }
}
