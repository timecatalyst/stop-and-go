using System.ComponentModel.DataAnnotations;

namespace Nymbus.Domain.Entities
{
    public class ClapToPostImage
    {
        public int Id { get; set; }

        [Required]
        public int ClapToPostId { get; set; }
        public ClapToPost ClapToPost { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
