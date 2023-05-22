using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace IntegrationTests;

public abstract class IntegrationTestBase
{
    protected ServiceProvider ServiceProvider { get; private set; }
    protected IRepositoryManager Repository { get; private set; }
    protected RepositoryContext Context { get; private set; }
    protected IMapper Mapper { get; private set; }
    protected IMediator Mediator { get; private set; }
    protected UserManager<User> UserManager { get; private set; }

    [SetUp]
    public void SetUpBase()
    {
        // Create a new service collection
        var serviceCollection = new ServiceCollection();

        // Add a DbContext to the service collection
        serviceCollection.AddDbContext<RepositoryContext>(options =>
            options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()), ServiceLifetime.Transient);

        // Add the repository to the service collection
        serviceCollection.AddLogging(logging => logging.AddDebug());
        serviceCollection.AddScoped<IRepositoryManager, RepositoryManager>();
        serviceCollection.AddAutoMapper(typeof(Application.AssemblyReference).Assembly);
        serviceCollection.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(typeof(Application.AssemblyReference));
        });

        serviceCollection.AddIdentity<User, IdentityRole>(o =>
        {
            o.Password.RequireDigit = false;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            o.Password.RequiredLength = 8;
            o.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<RepositoryContext>()
        .AddDefaultTokenProviders();

        // Build the service provider
        ServiceProvider = serviceCollection.BuildServiceProvider();

        // Get an instance of the DbContext and the repository
        Context = ServiceProvider.GetRequiredService<RepositoryContext>();
        Repository = ServiceProvider.GetRequiredService<IRepositoryManager>();
        Mapper = ServiceProvider.GetRequiredService<IMapper>();
        Mediator = ServiceProvider.GetRequiredService<IMediator>();
        UserManager = ServiceProvider.GetRequiredService<UserManager<User>>();
    }

    [TearDown]
    public void TearDownBase()
    {
        // Dispose of the service provider to clean up the in-memory database
        ServiceProvider.Dispose();
    }
}
