using Chatbot.AI_Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var groqApiKey = builder.Configuration["GroqApiKey"];
builder.Services.AddSingleton(new ChatService(groqApiKey!));
var app = builder.Build();


app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();
