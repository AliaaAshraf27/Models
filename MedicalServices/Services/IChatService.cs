using MedicalServices.DTO;
using MedicalServices.Models;
using System.Collections.Generic;

namespace MedicalServices.Services
{
    public interface IChatService
    {
        Task<List<Chat>> GetMessagesAsync(int senderId, int receiverId);
        Task<Chat> SaveMessageAsync(ChatDTO dto);
        Task<List<GetChatDTO>> GetAllChatsAsync(int userId , string userType);
        Task<string> GetUserName(int userId, string UserType);


    }
}
