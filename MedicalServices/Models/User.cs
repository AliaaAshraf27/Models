using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalServices.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [MaxLength(50)]
        public required string Name { get; set; }
        
        public required string Email { get; set; }
        
        public required string Password { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public List<Notification> Notifications { get; set; }
        public virtual Role Role { get; set; }

    }
}
