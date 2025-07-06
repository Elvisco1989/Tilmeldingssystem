using Microsoft.EntityFrameworkCore;
using Tilmeldingssystem.Models;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional model configuration can go here
        }
    }
   
}
