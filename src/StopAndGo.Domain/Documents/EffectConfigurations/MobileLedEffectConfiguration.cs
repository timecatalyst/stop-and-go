namespace Nymbus.Domain.Documents.EffectConfigurations
{
    public class MobileLedEffectConfiguration : EffectConfiguration<MobileLedEffectState>
    {
        public override EffectChannel Channel => EffectChannel.MobileLed;
    }
}
