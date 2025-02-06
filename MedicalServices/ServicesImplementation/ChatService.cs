using AutoMapper;
using MedicalServices.DbContext;
using MedicalServices.DTO;
using MedicalServices.Hubs;
using MedicalServices.Models;
using MedicalServices.Models.Identity;
using MedicalServices.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace MedicalServices.ServicesImplementation
{
    public class ChatService(ApplicationDbContext dbContext, IHubContext<NotificationHub> hubContext, IMapper mapper) : IChatService
    {
        #region Constractor
        private readonly ApplicationDbContext _dbContext = dbContext;
        private readonly IHubContext<NotificationHub> _hubContext = hubContext;
        private readonly IMapper _mapper = mapper;
        #endregion

        #region chat 
        public async Task<List<Chat>> GetMessagesAsync(int senderId, int receiverId)
        {
            var messages = await _dbContext.Chats
                .Where(c => (c.SenderId == senderId && c.ReceiverId == receiverId) ||
                (c.SenderId == receiverId && c.ReceiverId == senderId))
                .OrderBy(c => c.SendTime)
                .ToListAsync();

            return messages;
        }
        public async Task<Chat> SaveMessageAsync(Chat chat) //Add dto and time from backend
        {
            _dbContext.Chats.Add(chat);
            await _dbContext.SaveChangesAsync();
            return chat;
        }
        #endregion


        //public async Task SendNotification(NotificationDTO dto)
        //{
        //    var notification = _mapper.Map<Notification>(dto);
        //    notification.Date = DateTime.Now;
        //var message = $"shjfgiufir {receiverId}";
        //    notification.message = message;
        //    await _dbContext.Notifications.AddAsync(notification);
        //    await _dbContext.SaveChangesAsync();
        //    await _hubContext.Clients.Users(dto.ReceiverId.ToString()).SendAsync("ReceiveNotification", dto.Message);

        //}


    }
}
