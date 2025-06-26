using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyManagementSystem.Models
{
    public class Maintenance
    {
        [Key]
        public int MaintenanceId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public bool IsPaid { get; set; }

        public AppUser User { get; set; } // Navigation Property
    }
}
