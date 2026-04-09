using Microsoft.AspNetCore.Mvc;
using Chatbot.AI_Service;

namespace Chatbot.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class RestAPIControllers : ControllerBase
    {
        private readonly ChatService _chatService;
        public RestAPIControllers(ChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory()
        {
            var history = await _chatService.GecmisiGetir();
            return Ok(history);
        }

        [HttpPost]
        public async Task<IActionResult> Mesaj(ChatIstegi request)
        {
            if (request == null || string.IsNullOrEmpty(request.mesaj))
            {
                return BadRequest("Mesaj boş olamaz.");
            }

            var cevap = await _chatService.MesajGonder(request.mesaj);
            return Ok(new { cevap });
        }
    }

    public class ChatIstegi { public string? mesaj { get; set; } }
}