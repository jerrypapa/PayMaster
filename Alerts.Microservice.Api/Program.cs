using Alerts.Microservice.Application.Commands;
using Alerts.Microservice.Application.Services;
using Alerts.Microservice.Application.Settings;
using Alerts.Microservice.Domain.Entities;
using Alerts.Microservice.Domain.Repositories;
using Alerts.Microservice.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder
    .Configuration
    .GetConnectionString("Alerts");
builder.Services.AddDbContext<AlertsContext>(opt =>
opt.UseSqlServer(connectionString));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAlertsService, AlertsService>();
builder.Services.AddScoped<IAlertsRepository, AlertsRepository>();
builder.Services
    .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(SendEmailCommandHandler)));

var mySettings = builder.Configuration.GetSection("MailSettings").Get<MailSettings>();
builder.Services.AddSingleton(mySettings);

var app = builder.Build();
using (var serviceScope = app.Services.CreateScope())
{
    var dbcontext = serviceScope.ServiceProvider.GetRequiredService<AlertsContext>();
    dbcontext.Database.Migrate();
}
// Configure the HTTP request pipeline.

app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
