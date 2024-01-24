using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqApp
{
    static partial class LinqExtensions
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
    }
}
