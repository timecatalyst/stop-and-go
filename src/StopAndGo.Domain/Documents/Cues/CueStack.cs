namespace Nymbus.Domain.Documents.Cues
{
    public class CueStack
    {
        public string Id { get; set; }
        public int CueEffectStateDuration { get; set; }
        public Cue[] Cues { get; set; }
    }
}
