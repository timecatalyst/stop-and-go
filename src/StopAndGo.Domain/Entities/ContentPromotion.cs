using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nymbus.Domain.Entities
{
    public class ContentPromotion
    {
        public int Id { get; set; }
        
        [Required, MaxLength(256)]
        public string Name { get; set; }
        
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        
        [Required, MaxLength(1024)]
        public string ContentUrl { get; set; }

        [Required, MaxLength(30)]
        public string PostShowNotificationTitle { get; set; }

        [Required, MaxLength(150)]
        public string PostShowNotificationBody { get; set; }

        [Required, MaxLength(30)]
        public string GeofenceNotificationTitle { get; set; }

        [Required, MaxLength(150)]
        public string GeofenceNotificationBody { get; set; }

        [Column(TypeName = "date")]
        public DateTime AvailableStartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime AvailableEndDate { get; set; }

        public ISet<SponsorLocationContentPromotion> SponsorLocations { get; } = new HashSet<SponsorLocationContentPromotion>();
        public ISet<UserContentPromotion> UnlockedByUsers { get; } = new HashSet<UserContentPromotion>();
    }
}
