using System;

namespace Nymbus.Domain.Entities
{
    public class UserContentPromotion
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ContentPromotionId { get; set; }
        public ContentPromotion ContentPromotion { get; set; }
        public int UnlockedCount { get; set; }
        public DateTimeOffset UnlockedUntil { get; set; }
    }
}
