using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Nymbus.Domain.Entities
{
    public class ApiDbContext : IdentityDbContext<User, Role, int>
    {
        public ApiDbContext(
            DbContextOptions<ApiDbContext> dbContextOptions)
            : base(dbContextOptions) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<EventArtist> EventArtists { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<UserArtist> UserArtists { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }
        public DbSet<ArtistFollower> ArtistFollowers { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<SetSong> SetSongs { get; set; }
        public DbSet<ClapToPost> ClapToPosts { get; set; }
        public DbSet<ClapToPostImage> ClapToPostImages { get; set; }
        public DbSet<SponsorLocation> SponsorLocations { get; set; }
        public DbSet<ContentPromotion> ContentPromotions { get; set; }
        public DbSet<UserContentPromotion> UserContentPromotions { get; set; }
        public DbSet<SponsorLocationContentPromotion> SponsorLocationContentPromotions { get; set; }
        public DbSet<EventNotification> EventNotifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureSetSong(modelBuilder);
            ConfigureEventArtist(modelBuilder);
            ConfigureUserArtists(modelBuilder);
            ConfigureUserEvents(modelBuilder);
            ConfigureArtistFollowers(modelBuilder);
            ConfigureEvents(modelBuilder);
            ConfigureSponsorLocationContentPromotions(modelBuilder);
            ConfigureUserContentPromotions(modelBuilder);
        }

        private static void ConfigureSetSong(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SetSong>()
                        .HasOne(ss => ss.Song)
                        .WithMany()
                        .OnDelete(DeleteBehavior.Restrict);
        }

        private static void ConfigureEventArtist(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventArtist>()
                        .HasOne(ea => ea.Set)
                        .WithMany(s => s.Events)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EventArtist>()
                        .HasOne(ea => ea.Artist)
                        .WithMany(a => a.Events)
                        .OnDelete(DeleteBehavior.Restrict);
        }

        private static void ConfigureUserArtists(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserArtist>()
                        .HasKey(ua => new {ua.UserId, ua.ArtistId});

            modelBuilder.Entity<UserArtist>()
                        .HasOne(ua => ua.User)
                        .WithMany(u => u.Artists)
                        .HasForeignKey(ua => ua.UserId);

            modelBuilder.Entity<UserArtist>()
                        .HasOne(ua => ua.Artist)
                        .WithMany(a => a.Users)
                        .HasForeignKey(ua => ua.ArtistId);
        }

        private static void ConfigureUserEvents(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEvent>()
                        .HasKey(ua => new {ua.UserId, ua.EventId});

            modelBuilder.Entity<UserEvent>()
                        .HasOne(ua => ua.User)
                        .WithMany(u => u.UserEvents)
                        .HasForeignKey(ua => ua.UserId);

            modelBuilder.Entity<UserEvent>()
                        .HasOne(ua => ua.Event)
                        .WithMany(a => a.Users)
                        .HasForeignKey(ua => ua.EventId);
        }

        private static void ConfigureArtistFollowers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtistFollower>()
                        .HasKey(af => new {af.ArtistId, af.UserId});
        }
        private static void ConfigureEvents(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                        .HasOne(e => e.Venue)
                        .WithMany(v => v.Events)
                        .OnDelete(DeleteBehavior.Restrict);
        }
        
        private static void ConfigureSponsorLocationContentPromotions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SponsorLocationContentPromotion>()
                        .HasKey(slcp => new {slcp.SponsorLocationId, slcp.ContentPromotionId});
        }

        private static void ConfigureUserContentPromotions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserContentPromotion>()
                        .HasKey(ucp => new {ucp.UserId, ucp.ContentPromotionId});
        }
    }
}
