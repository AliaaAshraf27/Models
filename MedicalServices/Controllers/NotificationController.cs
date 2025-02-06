using MedicalServices.AppMetaData;
using MedicalServices.Hubs;
using MedicalServices.Models.Identity;
using MedicalServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace MedicalServices.Controllers
{
    [ApiController]
    public class NotificationController : ControllerBase
    {
        #region Constractor
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService; 
        }
        #endregion

        [HttpGet(Router.NotificationRouting.GetNotification)]
        public async Task<IActionResult> GetAllNotifications(int receiverId)
        {
            var notifications = await _notificationService.GetNotificationsAsync(receiverId);
            if (notifications == null || notifications.Count == 0)
                return NotFound(new { message = "No notification" });
            return Ok(notifications);
        }
    }
}
