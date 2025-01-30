using MedicalServices.Models;
using System.Collections.Generic;

namespace MedicalServices.Services
{
    public interface IChatService
    {
        public Task<List<Chat>> GetMessages(int senderId, int receiverId);
        public Task<Chat> SaveMessage(Chat chat);
    }
}
