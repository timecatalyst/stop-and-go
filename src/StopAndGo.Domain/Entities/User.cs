using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Nymbus.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public bool Disabled { get; set; }
        public bool InviteSent { get; set; }

        public ISet<UserArtist> Artists { get; } = new HashSet<UserArtist>();
        public ISet<ArtistFollower> ArtistsFollowed { get; } = new HashSet<ArtistFollower>();
        public ISet<UserContentPromotion> UnlockedContentPromotions { get; } = new HashSet<UserContentPromotion>();
        public ISet<UserEvent> UserEvents { get; set; } = new HashSet<UserEvent>();
        public string PasswordResetToken { get; set; }
        public DateTimeOffset? PasswordResetTokenExpirationDate { get; set; }
        
        public string Gender { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public string FacebookLink { get; set; }
    }
}
