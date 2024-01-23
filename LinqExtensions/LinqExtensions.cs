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

    }
}
