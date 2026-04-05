using OpenAI;
using OpenAI.Chat;
using System.ClientModel;

namespace Chatbot.AI_Service
{
    public class ChatService
    {
        private readonly OpenAIClient _client;
        // constructor buraya
        public ChatService(string apiKey)
        {
            _client = new OpenAIClient(
             new ApiKeyCredential(apiKey),
            new OpenAIClientOptions { Endpoint = new Uri("https://api.groq.com/openai/v1") }
            );
        }

        // MesajGonder metodu buraya
        public async Task<string> MesajGonder(string mesaj)
        {
            var chatClient = _client.GetChatClient("llama-3.3-70b-versatile");
            var response = await chatClient.CompleteChatAsync(
                new UserChatMessage(mesaj)
            );
            var cevap = response.Value.Content[0].Text;
            return cevap;
        }
    }
}