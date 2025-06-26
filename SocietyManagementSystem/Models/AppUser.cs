using System.ComponentModel.DataAnnotations;

namespace SocietyManagementSystem.Models
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string FlatNo { get; set; }

        [Required]
        public string ContactNo { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
