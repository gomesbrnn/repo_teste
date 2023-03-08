using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;

namespace ProEventos.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<SpeakerEvent> SpeakersEvents { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeakerEvent>()
                .HasKey(speakerEvent =>
                new { speakerEvent.EventId, speakerEvent.SpeakerId });

            modelBuilder.Entity<Event>()
                .HasMany(evt => evt.SocialMedia)
                .WithOne(socialM => socialM.Event)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Speaker>()
                .HasMany(spk => spk.SocialMedia)
                .WithOne(socialM => socialM.Speaker)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}