using AutoMapper;
using MediatR;
using MedicalServices.DbContext;
using MedicalServices.DTO;
using MedicalServices.Hubs;
using MedicalServices.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.ServicesImplementation
{
    public class NotificationService(ApplicationDbContext dbContext) : INotificationService
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<List<NotificationDTO>> GetNotificationsAsync(int receiverId)
        {
            var notifications = await _dbContext.Notifications
                .Where(n => n.ReceiverId == receiverId)
                .OrderByDescending(n => n.Date)
                .Select(n => new NotificationDTO
                {
                    Date = n.Date,
                    Message = n.Message // string 
                }).ToListAsync();
            return notifications;
        }
    }
}
