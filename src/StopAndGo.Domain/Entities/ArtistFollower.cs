namespace Nymbus.Domain.Entities
{
    public class ArtistFollower
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
