using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nymbus.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; }
        
        [MaxLength(50)]
        public string Subtitle { get; set; }
        
        [MaxLength(50)]
        public string Headliner { get; set; }
        
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
        
        [MaxLength(1024)]
        public string ImageUrl { get; set; }
        
        public EventColorPalette ColorPalette { get; set; }

        public bool Published { get; set; }
        
        public ISet<EventArtist> Artists { get; } = new HashSet<EventArtist>();
        public ISet<UserEvent> Users { get; set; }
    }
}
