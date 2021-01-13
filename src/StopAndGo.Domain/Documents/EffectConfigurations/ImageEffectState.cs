namespace Nymbus.Domain.Documents.EffectConfigurations
{
    public class ImageEffectState
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public int FadeInPercent { get; set; }
        public int? WidthPercent { get; set; }
        public int? HeightPercent { get; set; }
        public int? OpacityPercent { get; set; }
        public ImagePosition Position { get; set; }
    }
}
