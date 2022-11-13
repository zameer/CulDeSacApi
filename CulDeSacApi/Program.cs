using CulDeSacApi.Brokers.Queues;
using CulDeSacApi.Brokers.Storages;
using CulDeSacApi.Services.Foundations.StudentEvents;
using CulDeSacApi.Services.Foundations.Students;
using CulDeSacApi.Services.Orchestrations.StudentEvents;
using FluentAssertions.Common;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<StorageBroker>();
builder.Services.AddTransient<IQueueBroker, QueueBroker>();
builder.Services.AddTransient<IStorageBroker, StorageBroker>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IStudentEventOrchestrationService, StudentEventOrchestrationService>();
builder.Services.AddTransient<IStudentEventService, StudentEventService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Services.GetService<IStudentEventOrchestrationService>().ListenToStudentEvents();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
