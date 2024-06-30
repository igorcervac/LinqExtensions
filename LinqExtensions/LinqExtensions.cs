using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExtensions
{
    public static partial class LinqExtensions
    {
        public static U MaxBy<U, V>(this IEnumerable<U> source, Func<U, V> keySelector)
            where V : IComparable<V>
        {
            return source.Aggregate((x, y) => keySelector(y).CompareTo(keySelector(x)) > 0 ? y : x);
        }

        public static U MinBy<U, V>(this IEnumerable<U> source, Func<U, V> keySelector)
            where V : IComparable<V>
        {
            return source.Aggregate((x, y) => keySelector(y).CompareTo(keySelector(x)) < 0 ? y : x);
        }

        public static IEnumerable<V> TrySelect<U, V>(this IEnumerable<U> source, Func<U, V> keySelector)
        {
            foreach (var s in source)
            {
                bool success = true;
                V result = default;

                try
                {
                    result = keySelector(s);
                }
                catch (Exception)
                {
                    success = false;
                }

                if (success)
                {
                    yield return result;
                }
            }
        }

        public static Dictionary<V, int> CountBy<U,V>(this IEnumerable<U> source, Func<U, V> selector)
        {
            var dictionary  = new Dictionary<V, int>();

            foreach(var s in source)
            {
                var selectedValue = selector(s);
                if (!dictionary.ContainsKey(selectedValue))
                {
                    dictionary.Add(selectedValue, 1);
                }
                else
                {
                    dictionary[selectedValue]++;
                }
            }

            return dictionary;
        }

        public static bool LogicalAnd(this IEnumerable<bool> source)
        {
            return source.Aggregate((x, y) => x && y);
        }

        public static bool LogicalOr(this IEnumerable<bool> source)
        {
            return source.Aggregate((x, y) => x || y);
        }

        public static IEnumerable<U> DistinctBy<U,V>(this IEnumerable<U> source, Func<U,V> keySelector)
        {
            var query = source.GroupBy(keySelector);

            foreach (var group in query)
            {
                yield return group.First();
            }
        }

        public static IDictionary<U, int> RankBy<U,V>(this IEnumerable<U> source, Func<U,V> keySelector)
            where V : IComparable<V>
        {
            return source
                .Select(x => new { Value = x, Rank = source
                .Count(y => keySelector(y).CompareTo(keySelector(x)) > 0) + 1 })
                .ToDictionary(x => x.Value, y => y.Rank);
        }
    }
}
