using BarberShopWorker;
using RabbitMQ.Client;
using System.Reflection;
using BarberShopWorker.Configuration;
using BarberShopWorker.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using BarberShopWorker.Consumers;

IHost host = Host
    .CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services
            .AddHostedService<BookingCreatedConsumer>()
            .AddMediatR(Assembly.GetExecutingAssembly())
            .AddConsumers()
            .AddHandlers()
            .AddRepositories()
            .AddSingleton(serviceProvider =>
            {
                var connectionFactory = new ConnectionFactory()
                {
                    HostName = hostContext.Configuration.GetSection("RabbitMqConnection").GetSection("HostName").Value,
                    UserName = hostContext.Configuration.GetSection("RabbitMqConnection").GetSection("Username").Value,
                    Password = hostContext.Configuration.GetSection("RabbitMqConnection").GetSection("Password").Value,
                    VirtualHost = "/",
                    AutomaticRecoveryEnabled = true,
                    RequestedHeartbeat = new TimeSpan(60),
                    DispatchConsumersAsync = true
                };

                return connectionFactory;
            });

        services.AddDbContext<BarberShopContext>(options =>
            options.UseSqlServer(hostContext.Configuration.GetConnectionString("BarberShopContext")));

    })
    .Build();

host.Run();