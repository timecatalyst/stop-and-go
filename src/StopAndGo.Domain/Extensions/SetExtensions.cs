using System.Collections.Generic;
using System.Linq;

namespace Nymbus.Domain.Extensions
{
    public static class SetExtensions
    {
        public static void UpdateTo<T>(this ISet<T> set, IReadOnlyCollection<T> items)
        {
            set.IntersectWith(items);
            set.AddRange(items.Except(set));
        }

        public static void RemoveRange<T>(this ISet<T> set, IEnumerable<T> items)
        {
            foreach (var item in items) set.Remove(item);
        }

        public static void AddRange<T>(this ISet<T> set, IEnumerable<T> items)
        {
            foreach (var item in items) set.Add(item);
        }
    }
}
