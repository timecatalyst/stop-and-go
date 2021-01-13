using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nymbus.Domain.Entities
{
    public class Set
    {
        public int Id { get; set; }

        [Required]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public ISet<SetSong> Songs { get; } = new HashSet<SetSong>();
        public ISet<EventArtist> Events { get; } = new HashSet<EventArtist>();
    }
}
