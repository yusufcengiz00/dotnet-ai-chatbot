using Microsoft.AspNetCore.Mvc;
using Chatbot.AI_Service;
namespace Chatbot.Controllers

{
    [ApiController]
    [Route("/api/[controller]")]
    public class RestAPIControllers : ControllerBase
    {
        private readonly ChatService _chatService;
        public RestAPIControllers(ChatService chatService) { 
            _chatService = chatService;
        }

        [HttpGet("merhaba")]
        public IActionResult Merhaba()
        {
            return Ok(new { mesaj = "Merhaba Gama Mühendislik!" });
        }

        [HttpPost]
        public async Task<IActionResult> Mesaj(ChatIstegi request)
        {

            return Ok(new {cevap = await _chatService.MesajGonder(request.mesaj) });
        }

    }
    public class ChatIstegi
    {
        public string mesaj { get; set; }
    }
}
