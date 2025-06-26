using System;
using System.ComponentModel.DataAnnotations;

namespace SocietyManagementSystem.Models
{
    public class Notice
    {
        [Key]
        public int NoticeId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }
    }
}
