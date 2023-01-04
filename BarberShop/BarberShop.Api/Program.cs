using BarberShop.DependencyInjection;
using RabbitMQ.Client;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services
    .AddSingleton(serviceProvider =>
    {
        var connectionFactory = new ConnectionFactory()
        {
            HostName = builder.Configuration.GetSection("RabbitMqConnection").GetSection("HostName").Value,
            UserName = builder.Configuration.GetSection("RabbitMqConnection").GetSection("Username").Value,
            Password = builder.Configuration.GetSection("RabbitMqConnection").GetSection("Password").Value,
            VirtualHost = "/",
            AutomaticRecoveryEnabled = true,
            RequestedHeartbeat = new TimeSpan(60)
        };

        return connectionFactory;
    });

//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.Configuration = builder.Configuration.GetSection("RedisConnection").GetSection("RedisCache").Value;
//    options.InstanceName = "redis";
//});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHandlers();
builder.Services.AddServices();
builder.Services.AddRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BarberShop v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
