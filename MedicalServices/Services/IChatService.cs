using MedicalServices.DTO;
using MedicalServices.Models;
using System.Collections.Generic;

namespace MedicalServices.Services
{
    public interface IChatService
    {
        Task<List<Chat>> GetMessagesAsync(int senderId, int receiverId);
        Task<Chat> SendMessageAsync(ChatDTO dto);
        Task<List<GetChatDTO>> GetAllChatsAsync(int userId , string userType);
        Task<(string UserName, byte[]? UserPhoto)> GetUserDetails(int userId, string userType);


    }
}
