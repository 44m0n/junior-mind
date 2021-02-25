using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace LINQ
{
#pragma warning disable RCS1241 // Implement non-generic counterpart.
    public class ProjectionComparer<TSource, TKey> : IComparer<TSource>
#pragma warning restore RCS1241 // Implement non-generic counterpart.
    {
        private readonly Func<TSource, TKey> keySelector;
        private readonly IComparer<TKey> comparer;

        public ProjectionComparer(Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            this.keySelector = keySelector;
            this.comparer = comparer;
        }

        public int Compare([AllowNull] TSource x, [AllowNull] TSource y)
        {
            return comparer.Compare(keySelector(x), keySelector(y));
        }
    }
}
