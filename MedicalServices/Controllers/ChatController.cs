using MedicalServices.DTO;
using MedicalServices.Hubs;
using MedicalServices.Models;
using MedicalServices.Services;
using MedicalServices.ServicesImplementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace MedicalServices.Controllers
{
    [ApiController]
    public class ChatController : ControllerBase
    {
        #region Constractor
        private readonly IChatService _chatService;
        private readonly IHubContext<ChatHub> _chatHub;
        public ChatController(IChatService chatService, IHubContext<ChatHub> chatHub)
        {
            _chatService = chatService;
            _chatHub = chatHub;
        }
        #endregion
        #region chat

        [HttpGet("{senderId}/{receiverId}")]
        public async Task<IActionResult> GetMessages(int senderId, int receiverId)
        {
            var messages = await _chatService.GetMessagesAsync(senderId, receiverId);
            if (messages == null) return BadRequest("There is not chat between them");
            return Ok(messages);
        }

        [HttpPost("send")]
        public async Task<IActionResult> SaveMessage([FromBody] Chat chat)
        {
            var message = await _chatService.SaveMessageAsync(chat);
            await _chatHub.Clients.User(chat.ReceiverId.ToString())
            .SendAsync("ReceiveMessage", chat.SenderId, chat.SenderType, chat.Message, chat.SendTime);
            return Ok(message);
        }

        #endregion
        // from form في فايل هيترفع
        // from body مافيش فايل هيترفع
        #region Notification
        //[HttpGet("{userId}")]
        //public async Task<IActionResult> GetNotifications(int userId)
        //{
        //    var notifications = await _chatService.GetNotificationsAsync(userId);
        //    if (notifications == null) return BadRequest("No Notifications");
        //    return Ok(notifications);
        //}
        //[HttpPost("sendNotification")]
        //public async Task<IActionResult> SendNotification(SendNotificationDTO dto)
        //{
        //   var res = await _chatService.SendNotificationAsync(dto);

        //    return Ok(res);

        //}
        #endregion
    }
}
