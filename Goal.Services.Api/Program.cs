using Goal.Application.Handlers;
using Goal.Application.Mappers;
using Goal.Application.Services;
using Goal.Domain.Items;
using Goal.Infra.Factories;
using Goal.Infra.Repositories;
using Goal.Services.Api.Configurations;
using FluentMediator;
using System.Reflection;
using Jaeger.Samplers;
using OpenTracing;
using Jaeger;
using OpenTracing.Util;
using Serilog;
using Goal.Domain.Items.Events;
using Goal.Domain.Items.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddEnvironmentVariables();

// ConfigureServices

// WebAPI Config
builder.Services.AddControllers();

// Setting JWT
builder.Services.AddJwtConfiguration(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Setting Swagger
builder.Services.AddSwaggerConfiguration();

// .NET Native DI Abstraction
builder.Services.AddDependencyInjectionConfiguration();

Log.Logger = new LoggerConfiguration().CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
