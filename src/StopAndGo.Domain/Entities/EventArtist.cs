using System.ComponentModel.DataAnnotations.Schema;

namespace Nymbus.Domain.Entities
{
    [Table("EventArtists")]
    public class EventArtist
    {
        public int Id { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public int? SetId { get; set; }
        public Set Set { get; set; }

        public string StartTime { get; set; }
    }
}
