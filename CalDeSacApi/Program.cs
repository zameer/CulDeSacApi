using CalDeSacApi.Brokers.Queues;
using CalDeSacApi.Services.Foundations.StudentEvents;
using CalDeSacApi.Services.Orchestrations.StudentEvents;
using FluentAssertions.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddTransient<IQueueBroker, QueueBroker>();
builder.Services.AddTransient<IStudentEventService, StudentEventService>();
builder.Services.AddTransient<IStudentEventOrchestrationService, StudentEventOrchestrationService>();

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
