using System;
using System.Linq;
using Newtonsoft.Json;

namespace Nymbus.Domain.Documents.EffectConfigurations
{
    public abstract class EffectConfiguration<TEffectState> : IEffectConfiguration
    {
        public abstract EffectChannel Channel { get; }

        public double SequenceSpeedMultiplier { get; set; } = 1;
        public int? Iterations { get; set; }
        public TEffectState[] States { get; set; } = Array.Empty<TEffectState>();

        [JsonIgnore]
        public bool HasStates => (States?.Any()).GetValueOrDefault();
    }
}
