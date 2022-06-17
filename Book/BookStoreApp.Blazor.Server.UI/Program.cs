using Blazored.LocalStorage;
using BookStoreApp.Blazor.Server.UI.Configurations;
using BookStoreApp.Blazor.Server.UI.Providers;
using BookStoreApp.Blazor.Server.UI.Services;
using BookStoreApp.Blazor.Server.UI.Services.Authentication;
using BookStoreApp.Blazor.Server.UI.Services.Base;
using DL.DatabaseSpecific;
using DL.Linq;
using Microsoft.AspNetCore.Components.Authorization;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDevExpressBlazor(); // DevExpress service
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri(builder.Configuration["BaseAddress"]));

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped<ApiAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(p => 
    p.GetRequiredService<ApiAuthenticationStateProvider>());

void ConfigureLLBLGenPro(WebApplicationBuilder builder)
{
    var connectionString = "data source=.\\MSSQLSERVER01;initial catalog=BookStoreDB;integrated security=SSPI;persist security info=False";
    if (!string.IsNullOrEmpty(connectionString)!)
    {
        RuntimeConfiguration.AddConnectionString("ConnectionString.SQL Server (SqlClient)", connectionString);
    }

    var factoryType = typeof(Microsoft.Data.SqlClient.SqlClientFactory);
    RuntimeConfiguration.ConfigureDQE<SQLServerDQEConfiguration>(c =>
    {
        c.AddDbProviderFactory(factoryType)
            .SetDefaultCompatibilityLevel(SqlServerCompatibilityLevel.SqlServer2012);
        c.AddCatalogNameOverwrite("*", string.Empty);
    });


    builder.Services.AddScoped<IDataAccessAdapter>(zz => new DataAccessAdapter
    {
        CatalogNameUsageSetting = CatalogNameUsage.Clear,
        ActiveRecoveryStrategy = new SqlAzureRecoveryStrategy(),
       // CommandTimeOut = sqlCommandTimeout
    });
    builder.Services.AddScoped<LinqMetaData>();
}

ConfigureLLBLGenPro(builder);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
