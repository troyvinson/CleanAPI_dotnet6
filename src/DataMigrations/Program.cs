using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    // CreateDefaultBuilder automatically reads configs
    .ConfigureAppConfiguration((context, builder) =>
    {
    })
    .ConfigureServices((builder, services) =>
    {
        IConfiguration configuration = builder.Configuration;
        services.AddSqlServer<RepositoryContext>(
            configuration.GetConnectionString("DefaultConnection"),
            options => options.MigrationsAssembly("DataMigrations"));
    })
    .Build();

await host.RunAsync();

