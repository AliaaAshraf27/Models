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
        public async Task<Chat> SaveMessageAsync(ChatDTO dto) 
        {
            var chat = new Chat()
            {
                SenderId = dto.SenderId,
                ReceiverId = dto.ReceiverId,
                SendTime = DateTime.Now,
                Message = dto.Message,
                ReceiverType = dto.ReceiverType,
                SenderType = dto.SenderType
            };
            _dbContext.Chats.Add(chat);
            await _dbContext.SaveChangesAsync();
            return chat;
        }
        public async Task<List<Chat>> GetAllChatsAsync(int userId)
        {
            var chats = await _dbContext.Chats
                .Where(c=> c.SenderId == userId || c.ReceiverId == userId)
                .OrderByDescending(c => c.SendTime).ToListAsync();
            return chats;
        }
        #endregion
    }
}
