using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nymbus.Domain.Entities
{
    public class Artist
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(1024)]
        public string WebsiteUrl { get; set; }

        [MaxLength(1024)]
        public string MerchandiseUrl { get; set; }
        
        [MaxLength(1024)]
        public string ImageUrl { get; set; }

        public ISet<EventArtist> Events { get; } = new HashSet<EventArtist>();
        public ISet<UserArtist> Users { get; } = new HashSet<UserArtist>();
        public ISet<ArtistFollower> UsersFollowing { get; } = new HashSet<ArtistFollower>();
    }
}
