using System.Collections.Generic;
using System.Linq;

namespace Business.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> OrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable ?? Enumerable.Empty<T>();
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                return true;
            }

            return !enumerable.Any();
        }
    }
}
