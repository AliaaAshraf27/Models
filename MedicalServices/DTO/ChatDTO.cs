namespace MedicalServices.DTO
{
    public class ChatDTO
    {
        public string Message { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string SenderType { get; set; }
        public string ReceiverType { get; set; }
        public IFormFile? Image { get; set; }
    }
    public class GetChatDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string OtherUserName { get; set; }
        public DateTime SendTime { get; set; }
        //public int SenderId { get; set; }
        //public int ReceiverId { get; set; }

    }
}
