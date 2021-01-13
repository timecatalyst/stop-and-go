using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Nymbus.Domain.Features.Shared
{
    public class TimeComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == y) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            var regex = new Regex(@"^(\d{1,2}):(\d{2}) (AM|PM)$", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

            if (!regex.IsMatch(x) && !regex.IsMatch(y)) return 0;
            if (regex.IsMatch(x) && !regex.IsMatch(y)) return -1;
            if (!regex.IsMatch(x) && regex.IsMatch(y)) return 1;

            var xResult = regex.Match(x);
            var yResult = regex.Match(y);

            if (xResult.Groups[3].Value == "AM" && yResult.Groups[3].Value == "PM") return -1;
            if (xResult.Groups[3].Value == "PM" && yResult.Groups[3].Value == "AM") return 1;

            var xHour = int.Parse(xResult.Groups[1].Value);
            if (xHour == 12) xHour = 0;

            var yHour = int.Parse(yResult.Groups[1].Value);
            if (yHour == 12) yHour = 0;

            if (xHour < yHour) return -1;
            if (xHour > yHour) return 1;

            var xMinute = int.Parse(xResult.Groups[2].Value);
            var yMinute = int.Parse(yResult.Groups[2].Value);

            if (xMinute < yMinute) return -1;
            if (xMinute > yMinute) return 1;

            return 0;
        }
    }
}
