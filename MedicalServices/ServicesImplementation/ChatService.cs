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
using System;
using static System.Net.Mime.MediaTypeNames;


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
            var chat = new Chat();
            if (dto.Image != null)
            {
                using var dataStream = new MemoryStream();
                await dto.Image.CopyToAsync(dataStream);
                chat.Image = dataStream.ToArray();
            }
            if (dto.Message != null)
                chat.Message = dto.Message;
            
            chat.SenderId = dto.SenderId;
            chat.ReceiverId = dto.ReceiverId;
            chat.SendTime = DateTime.Now;
            chat.ReceiverType = dto.ReceiverType;
            chat.SenderType = dto.SenderType;
            _dbContext.Chats.Add(chat);
            await _dbContext.SaveChangesAsync();
            return chat;
        }
        public async Task<string> GetUserName(int userId, string userType)
        {
            if (userType == "Doctor")
            {
                return await _dbContext.Doctors.Where(d => d.Id == userId)
                    .Select(d => d.User.Name).FirstAsync();
            }
            else if (userType == "Patient")
            {
                return await _dbContext.Patients.Where(p => p.Id == userId)
                    .Select(p => p.User.Name).FirstAsync();
            }
            return "Unknown";
        }


        public async Task<List<GetChatDTO>> GetAllChatsAsync(int userId, string userType)
        {
            var allChats = await _dbContext.Chats
                .Where(c => c.SenderId == userId || c.ReceiverId == userId)
                .OrderByDescending(c => c.SendTime) // Ensure latest messages come first
                .ToListAsync(); 

            var groupedChats = allChats
                .GroupBy(c => new
                {
                    User1 = Math.Min(c.SenderId, c.ReceiverId),
                    User2 = Math.Max(c.SenderId, c.ReceiverId)
                })
                .Select(g => g.First()) // Select the latest message per group
                .OrderByDescending(c => c.SendTime) // Keep latest messages first
                .ToList();

            var dto = new List<GetChatDTO>();
            foreach (var chat in groupedChats)
            {
                var otherUserId = chat.SenderId == userId ? chat.ReceiverId : chat.SenderId;
                var otherUserType = chat.SenderType == userType ? chat.ReceiverType : chat.SenderType;
                string otherUserName = await GetUserName(otherUserId, otherUserType);

                dto.Add(new GetChatDTO
                {
                    Id = chat.Id,
                    Message = chat.Message,
                    SendTime = chat.SendTime,
                    OtherUserName = otherUserName, 
                    OtherUserId = otherUserId,
                    Image =chat.Image != null ? $"data:image/png;base64,{Convert.ToBase64String(chat.Image)}" : null
                });
            }

            return dto;
        }



        #endregion
    }
}
