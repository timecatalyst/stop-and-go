namespace Nymbus.Domain.Documents.EffectConfigurations
{
    public class BraceletColorEffectConfiguration : EffectConfiguration<BraceletColorEffectState>
    {
        public override EffectChannel Channel => EffectChannel.BraceletColor;
        public bool SynchronizeToMobileColor { get; set; } = true;
    }
}
