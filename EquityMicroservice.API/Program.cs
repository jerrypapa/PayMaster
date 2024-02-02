using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using EquityMicroservice.API.BrokerConfigurations;
using EquityMicroservice.Application.Commands;
using EquityMicroservice.Application.Services;
using EquityMicroservice.Domain.Entities;
using EquityMicroservice.Domain.Repositories;
using EquityMicroservice.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("EquityCoreBanking");
builder.Services.AddDbContext<EquityContext>(opt =>
opt.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services
    .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateCustomerCommandHandler)));

var broker = RabbitHutch.CreateBus(builder.Configuration["RabbitMQ:RabbitConn"]);
builder.Services.AddSingleton<IBus>(broker);
builder.Services.AddSingleton<MessageDispatcher>();
builder.Services.AddSingleton<AutoSubscriber>(_ =>
{
    return new AutoSubscriber(_.GetRequiredService<IBus>(), Assembly
        .GetExecutingAssembly().GetName().Name)
    {
        AutoSubscriberMessageDispatcher=_.GetRequiredService<MessageDispatcher>()
    };
});
builder.Services.AddHostedService<Worker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
