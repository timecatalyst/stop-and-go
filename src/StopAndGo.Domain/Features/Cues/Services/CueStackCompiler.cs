using System.Collections.Generic;
using System.Linq;
using Nymbus.Domain.Documents.Cues;
using Nymbus.Domain.Features.Interfaces;

namespace Nymbus.Domain.Features.Cues.Services
{
    public class CueStackCompiler : IFeatureService
    {
        private readonly CueCompiler _cueCompiler;

        public CueStackCompiler(CueCompiler cueCompiler) => _cueCompiler = cueCompiler;

        public CompiledCueStack CompileCueStack(CueStack cueStack) =>
            new CompiledCueStack
            {
                Cues = CompileCues(cueStack).ToArray()
            };

        private IEnumerable<CompiledCue> CompileCues(CueStack cueStack)
        {
            var compiledCues = cueStack.Cues.Select(cue => _cueCompiler.CompileCue(cue)).ToList();

            return compiledCues.OrderBy(cc => cc.StartingMillisecond);
        }
    }
}
