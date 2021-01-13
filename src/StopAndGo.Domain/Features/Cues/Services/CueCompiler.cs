using Nymbus.Domain.Documents.Cues;
using Nymbus.Domain.Features.Interfaces;

namespace Nymbus.Domain.Features.Cues.Services
{
    public class CueCompiler : IFeatureService
    {
        public CompiledCue CompileCue(Cue cue) =>
            new CompiledCue
            {
                StartingMillisecond = cue.CalculateStartingMillisecond(),
                EffectConfigurations = cue.EffectConfigurations
            };
    }
}
