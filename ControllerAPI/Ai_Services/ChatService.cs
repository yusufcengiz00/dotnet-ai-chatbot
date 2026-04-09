using OpenAI;
using OpenAI.Chat;
using System.ClientModel;
using Npgsql;
using Dapper;

namespace Chatbot.AI_Service
{
    public class ChatService
    {
        private readonly OpenAIClient _client;
        private readonly string _connectionString;

        public ChatService(string apiKey, string connectionString)
        {
            _client = new OpenAIClient(
                new ApiKeyCredential(apiKey),
                new OpenAIClientOptions { Endpoint = new Uri("https://api.groq.com/openai/v1") }
            );
            _connectionString = connectionString;
        }

        public async Task<string> MesajGonder(string mesaj)
        {
            var chatClient = _client.GetChatClient("llama-3.3-70b-versatile");
            var response = await chatClient.CompleteChatAsync(new UserChatMessage(mesaj));
            var cevap = response.Value.Content[0].Text;

            await VeritabaninaKaydet(mesaj, cevap);
            return cevap;
        }

        private async Task VeritabaninaKaydet(string mesaj, string cevap)
        {
            try
            {
                using var connection = new NpgsqlConnection(_connectionString);
                var sql = "INSERT INTO chat_history (user_message, bot_response) VALUES (@mesaj, @cevap)";
                await connection.ExecuteAsync(sql, new { mesaj, cevap });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DB Kayıt Hatası: {ex.Message}");
            }
        }

        public async Task<IEnumerable<dynamic>> GecmisiGetir()
        {
            try
            {
                using var connection = new NpgsqlConnection(_connectionString);
                var sql = "SELECT * FROM chat_history ORDER BY created_at DESC";
                return await connection.QueryAsync(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Veri çekme hatası: {ex.Message}");
                return Enumerable.Empty<dynamic>();
            }
        }
    }
}