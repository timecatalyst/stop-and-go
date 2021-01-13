using System;
using NodaTime;

namespace Nymbus.Domain.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime TodayInZone(this IClock clock, DateTimeZone timeZone) =>
            clock.GetCurrentInstant().InZone(timeZone).Date.ToDateTimeUnspecified();
    }
}
