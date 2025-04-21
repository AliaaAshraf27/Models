using System.ComponentModel.DataAnnotations;

namespace MedicalServices.DTO
{
    public class GetAllSpecializaion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public int Rating { get; set; }
        public float Price { get; set; }
    }
}
