using Microsoft.EntityFrameworkCore;

namespace SocietyManagementSystem.Models
{
    public class SocietyDBContext : DbContext
    {
        public SocietyDBContext(DbContextOptions<SocietyDBContext> options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Maintenance> Maintenance { get; set; }
        public DbSet<Complaint> Complaints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set primary keys
            modelBuilder.Entity<AppUser>().HasKey(u => u.UserId);
            modelBuilder.Entity<Notice>().HasKey(n => n.NoticeId);
            modelBuilder.Entity<Message>().HasKey(m => m.MessageId);
            modelBuilder.Entity<Maintenance>().HasKey(m => m.MaintenanceId);
            modelBuilder.Entity<Complaint>().HasKey(c => c.ComplaintId);

            // Configure relationships for messages
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany()
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
