using GamaChatbot.Services;

var builder = WebApplication.CreateBuilder(args);
var groqApiKey = builder.Configuration["GroqApiKey"];
builder.Services.AddSingleton(new ChatService(groqApiKey!));
var app = builder.Build();

app.MapGet("/merhaba", () =>
{
    return new { mesaj = "Merhaba, Gama Mühendislik!" };
});

app.MapPost("/chat", async (ChatService chatService ,ChatIstegi istek) => // senkron async ekleyince asenkron olacak.
{
    
    var cevap = await chatService.MesajGonder(istek.mesaj);

    return cevap;
});
  

app.Run();

record ChatIstegi(string mesaj);