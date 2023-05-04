using aspnet_background_service_demo;
using aspnet_background_service_demo.BackgroundServices;
using aspnet_background_service_demo.Services;
using aspnet_background_service_demo.ServicesImpl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register email service
builder.Services.AddSingleton<IEmailService, EmailService>();

// Register subscriber manager
builder.Services.AddSingleton<SubscriptionManager>();

// Register hosted services
builder.Services.AddHostedService<OneTimeEmailService>();
// builder.Services.AddHostedService<BatchEmailService>();

var app = builder.Build();

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
