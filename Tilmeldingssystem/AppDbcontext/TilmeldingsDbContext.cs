using Microsoft.EntityFrameworkCore;
using Tilmeldingssystem.Models;
using Tilmeldingssystem.TicketSystem;

namespace Tilmeldingssystem.AppDbcontext
{
    public class TilmeldingsDbContext : DbContext
    {
        public TilmeldingsDbContext(DbContextOptions<TilmeldingsDbContext> options) : base(options)
        {
        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        public DbSet<Payment> Payments { get; set; } // Assuming you have a ClubMember model for many-to-many relationship

        public DbSet<MemberClub> MemberClubs { get; set; }  // ✅ Add this line

        public DbSet<MemberActivity> MemberActivities { get; set; }


        public DbSet<Ticket> Tickets { get; set; } // Assuming you have a Registration model for activity registrations


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship
            modelBuilder.Entity<MemberClub>()
                .HasKey(mc => new { mc.MemberId, mc.ClubId });

            modelBuilder.Entity<MemberClub>()
                .HasOne(mc => mc.Member)
                .WithMany(m => m.MemberClubs)
                .HasForeignKey(mc => mc.MemberId);

            modelBuilder.Entity<MemberClub>()
                .HasOne(mc => mc.Club)
                .WithMany(c => c.MemberClubs)
                .HasForeignKey(mc => mc.ClubId);

            modelBuilder.Entity<MemberActivity>()
    .HasKey(ma => new { ma.MemberId, ma.ActivityId });

            modelBuilder.Entity<MemberActivity>()
                .HasOne(ma => ma.Member)
                .WithMany(m => m.MemberActivities)
                .HasForeignKey(ma => ma.MemberId);

            modelBuilder.Entity<MemberActivity>()
                .HasOne(ma => ma.Activity)
                .WithMany(a => a.MemberActivities)
                .HasForeignKey(ma => ma.ActivityId);

            modelBuilder.Entity<Registration>()
    .HasOne(r => r.Member)
    .WithMany()
    .HasForeignKey(r => r.MemberId);

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Activity)
                .WithMany()
                .HasForeignKey(r => r.ActivityId);


        }
    }
   
}
