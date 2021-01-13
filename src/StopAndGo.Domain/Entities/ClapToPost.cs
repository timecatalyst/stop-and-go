using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nymbus.Domain.Entities
{
    public class ClapToPost
    {
        public int Id { get; set; }

        [Required]
        public int EventArtistId { get; set; }
        public EventArtist EventArtist { get; set; }

        [Required]
        public int SetSongId { get; set; }
        public SetSong SetSong { get; set; }

        [Required]
        public ClapToPostType Type { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Message { get; set; }

        public string VideoUrl { get; set; }

        public ISet<ClapToPostImage> Images { get; } = new HashSet<ClapToPostImage>();
    }
}
