using MedicalServices.DTO;
using MedicalServices.Models;

namespace MedicalServices.Services
{
    public interface INotificationService
    {
        Task<List<NotificationDTO>> GetNotificationsAsync(int receiverId);
    }
}
