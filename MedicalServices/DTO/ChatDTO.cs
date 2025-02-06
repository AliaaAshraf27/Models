namespace MedicalServices.DTO
{
    public class ChatDTO
    {
        public string Message { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string SenderType { get; set; }
        public string ReceiverType { get; set; }
    }
}
