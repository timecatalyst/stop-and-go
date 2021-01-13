using System;
using System.Globalization;
using Nymbus.Domain.Documents.EffectConfigurations;

namespace Nymbus.Domain.Documents.Cues
{
    public class Cue
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string StartingTime { get; set; }
        public IEffectConfiguration[] EffectConfigurations { get; set; }

        public double CalculateStartingMillisecond()
        {
            if (string.IsNullOrEmpty(StartingTime)) return 0;

            var ts = TimeSpan.ParseExact(
                StartingTime, @"hh\:mm\:ss\:fff", CultureInfo.CurrentCulture, TimeSpanStyles.None);

            return ts.TotalMilliseconds;
        }
    }
}
