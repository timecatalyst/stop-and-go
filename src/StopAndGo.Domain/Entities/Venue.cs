using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nymbus.Domain.Entities
{
    public class Venue
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public int? SeatingCapacity { get; set; }

        [MaxLength(256)]
        public string StreetAddress { get; set; }

        [MaxLength(1024)]
        public string WebsiteUrl { get; set; }

        [MaxLength(1024)]
        public string TicketsUrl { get; set; }

        public ISet<Event> Events { get; } = new HashSet<Event>();
    }
}
