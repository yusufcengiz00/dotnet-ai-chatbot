using Chatbot.AI_Service;

var builder = WebApplication.CreateBuilder(args);

// User Secrets'tan verileri çek
var apiKey = builder.Configuration["GroqApiKey"];
var connectionString = builder.Configuration.GetConnectionString("PostgreSQL");

// Servisi kaydet
builder.Services.AddSingleton(new ChatService(apiKey, connectionString));

builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();
app.Run();