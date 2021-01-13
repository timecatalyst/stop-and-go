using System.ComponentModel.DataAnnotations;

namespace Nymbus.Domain.Entities
{
    public class EventNotification
    {
        public int Id { get; set; }

        [Required]
        public int EventId { get; set; }
        public Event Event { get; set; }

        [Required, MaxLength(30)]
        public string Title { get; set; }

        [Required, MaxLength(150)]
        public string Body { get; set; }
    }
}
