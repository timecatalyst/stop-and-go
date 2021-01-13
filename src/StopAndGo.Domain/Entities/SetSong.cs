using System;
using System.ComponentModel.DataAnnotations;

namespace Nymbus.Domain.Entities
{
    public class SetSong
    {
        public int Id { get; set; }

        [Required]
        public int SetId { get; set; }
        public Set Set { get; set; }

        [Required]
        public int SongId { get; set; }
        public Song Song { get; set; }

        [Required]
        public int Number { get; set; }

        public Guid? CueStackId { get; set; }
    }
}
