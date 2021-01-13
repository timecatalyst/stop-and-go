using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nymbus.Domain.Entities
{
    public class SponsorLocation
    {
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        [Required, MaxLength(256)]
        public string Name { get; set; }

        [Required, MaxLength(1024)]
        public string Address { get; set; }

        public bool InvalidAddress { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public double GeofenceRadius { get; set; }

        public ISet<SponsorLocationContentPromotion> ContentPromotions { get; } = new HashSet<SponsorLocationContentPromotion>();
    }
}
