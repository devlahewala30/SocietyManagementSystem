using System;
using System.ComponentModel.DataAnnotations;

namespace SocietyManagementSystem.Models
{
    public class Complaint
    {
        [Key]
        public int ComplaintId { get; set; }

        public int UserId { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
