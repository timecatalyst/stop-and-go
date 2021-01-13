namespace Nymbus.Domain.Documents.EffectConfigurations
{
    public interface IEffectConfiguration
    {
        EffectChannel Channel { get; }
        bool HasStates { get; }
    }
}
