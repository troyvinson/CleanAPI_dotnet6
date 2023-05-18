﻿using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests;

public abstract class IntegrationTestBase
{
    protected ServiceProvider ServiceProvider { get; private set; }
    protected IRepositoryManager Repository { get; private set; }
    protected IMapper Mapper { get; private set; }
    protected IMediator Mediator { get; private set; }

    [SetUp]
    public void SetUpBase()
    {
        // Create a new service collection
        var serviceCollection = new ServiceCollection();

        // Add a DbContext to the service collection
        serviceCollection.AddDbContext<RepositoryContext>(options =>
        {
            options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
            options.EnableSensitiveDataLogging();
        }, ServiceLifetime.Transient);

        serviceCollection.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(typeof(Application.AssemblyReference));
        });

        // Add the repository to the service collection
        serviceCollection.AddScoped<IRepositoryManager, RepositoryManager>();
        serviceCollection.AddAutoMapper(typeof(Application.AssemblyReference).Assembly);

        // Build the service provider
        ServiceProvider = serviceCollection.BuildServiceProvider();

        // Get an instance of the DbContext and the repository
        Repository = ServiceProvider.GetRequiredService<IRepositoryManager>();
        Mapper = ServiceProvider.GetRequiredService<IMapper>();
        Mediator = ServiceProvider.GetRequiredService<IMediator>();

    }

    [TearDown]
    public void TearDownBase()
    {
        // Dispose of the service provider to clean up the in-memory database
        ServiceProvider.Dispose();
    }
}