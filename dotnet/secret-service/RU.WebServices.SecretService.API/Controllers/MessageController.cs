using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RU.WebServices.SecretService.Models.InputModels;
using RU.WebServices.SecretService.Services.Interfaces;

namespace RU.WebServices.SecretService.API.Controllers
{
    [Authorize]
    [Route("api/messages")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult StoreMessage([FromBody] MessageInputModel message)
        {
            var newMessageId = _messageService.StoreMessage(message, User.Identity?.Name);
            return CreatedAtRoute("ReadMessage", new { messageId = newMessageId }, null);
        }

        [HttpGet]
        [Route("{messageId}", Name = "ReadMessage")]
        public IActionResult ReadMessage(int messageId)
        {
            return Ok(_messageService.ReadMessage(messageId, User.Identity?.Name));
        }

        [HttpGet]
        [Route("")]
        public IActionResult ListMessages()
        {
            return Ok(_messageService.ListMessages(User.Identity?.Name));
        }
    }
}
