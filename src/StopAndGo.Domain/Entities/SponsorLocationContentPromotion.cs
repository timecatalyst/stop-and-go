namespace Nymbus.Domain.Entities
{
    public class SponsorLocationContentPromotion
    {
        public int SponsorLocationId { get; set; }
        public SponsorLocation SponsorLocation { get; set; }
        public int ContentPromotionId { get; set; }
        public ContentPromotion ContentPromotion { get; set; }
    }
}
