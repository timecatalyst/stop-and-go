namespace StopAndGo.Api.Hubs.Shared.Models
{
    public class GameLogicConfiguration
    {
        public int[] StartCountdownIntervals { get; set; }
        public int GameSpeed { get; set; }
        public int StopRate { get; set; }
        public int StopReactionGap { get; set; }
        public int StopCooldown { get; set; }
    }
}
