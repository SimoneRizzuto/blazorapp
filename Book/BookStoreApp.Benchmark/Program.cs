using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Security.Cryptography;
using AutoMapper;
using BookStoreApp.API.Configurations;
using BookStoreApp.API.Controllers;
using BookStoreApp.API.Data;
using BookStoreApp.API.Repositories;
using DL.DatabaseSpecific;
using DL.EntityClasses;
using DL.Linq;
using Microsoft.EntityFrameworkCore;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;

public class QueryBench
{
    private const int N = 10;

    public QueryBench()
    {
        var map= new Mapper(new MapperConfiguration(zz => { new MapperConfig(); }));
        var connectionString = "data source=.\\MSSQLSERVER01;initial catalog=BookStoreDB;integrated security=SSPI;persist security info=False;Trusted_Connection=True;TrustServerCertificate=True";
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

        var daa = new DataAccessAdapter
        {
            CatalogNameUsageSetting = CatalogNameUsage.Clear,
            ActiveRecoveryStrategy = new SqlAzureRecoveryStrategy(),
            // CommandTimeOut = sqlCommandTimeout
        };
        _authorsRepository = new AuthorsRepository(map, daa, new LinqMetaData(daa));
        var dbContextOptions = new DbContextOptionsBuilder<BookStoreDBContext>()
            .UseSqlServer(connectionString);
        _efAuthors = new BookStoreDBContext(dbContextOptions.Options);
    }

    private readonly AuthorsRepository _authorsRepository;
    private readonly BookStoreDBContext _efAuthors;


    [Benchmark]
    public List<AuthorEntity> LLBLGenFetch()
    {
        return _authorsRepository.GetAllAsync().Result;
    }
    
    [Benchmark]
    public List<Author> EFCoreFetch()
    {
        return _efAuthors.Authors.ToList();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
    }
}