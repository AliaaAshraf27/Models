using System.ComponentModel.DataAnnotations.Schema;
using MedicalServices.Models.Identity;

namespace MedicalServices.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string SenderType { get; set; }
        public string ReceiverType { get; set; }
    }
}
