using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyManagementSystem.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        public string MessageText { get; set; }

        public DateTime SentOn { get; set; }

        [ForeignKey("SenderId")]
        public virtual AppUser Sender { get; set; }

        [ForeignKey("ReceiverId")]
        public virtual AppUser Receiver { get; set; }
    }
}
