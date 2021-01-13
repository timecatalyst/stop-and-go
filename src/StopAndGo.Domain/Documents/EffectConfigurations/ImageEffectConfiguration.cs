namespace Nymbus.Domain.Documents.EffectConfigurations
{
    public class ImageEffectConfiguration : EffectConfiguration<ImageEffectState>
    {
        public override EffectChannel Channel => EffectChannel.Image;
    }
}
