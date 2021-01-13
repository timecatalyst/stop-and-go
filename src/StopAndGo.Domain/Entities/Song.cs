using System.ComponentModel.DataAnnotations;

namespace Nymbus.Domain.Entities
{
    public class Song
    {
        public int Id { get; set; }

        [Required]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; }

        [Required, MaxLength(50)]
        public string ByLine { get; set; }
    }
}
