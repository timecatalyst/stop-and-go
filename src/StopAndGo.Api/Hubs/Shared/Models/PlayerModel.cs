namespace StopAndGo.Api.Hubs.Shared.Models
{
    public class PlayerModel
    {
        public string ConnectionId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Position { get; set; }
        public string Command { get; set; }
    }
}
