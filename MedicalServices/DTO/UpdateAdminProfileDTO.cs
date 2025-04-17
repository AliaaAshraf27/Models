namespace MedicalServices.DTO
{
    public class UpdateAdminProfileDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public IFormFile? Photo { get; set; }
       
    }
    public class UserAdminProfileDTO
    {
        public string Name { get; set; }
        public string? PhotoData { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
