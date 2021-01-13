using Nymbus.Domain.Documents.EffectConfigurations;

namespace Nymbus.Domain.Documents.Cues
{
    public class CompiledCue
    {
        public string Id { get; set; }
        public double StartingMillisecond { get; set; }
        public IEffectConfiguration[] EffectConfigurations { get; set; }
    }
}
