using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LINQ
{
    class CompoundComparer<TSource> : IComparer<TSource>
    {
        private readonly IComparer<TSource> firstComparer;
        private readonly IComparer<TSource> secondComparer;

        public CompoundComparer(IComparer<TSource> firstComparer, IComparer<TSource> secondComparer)
        {
            this.firstComparer = firstComparer;
            this.secondComparer = secondComparer;
        }

        public int Compare([AllowNull] TSource x, [AllowNull] TSource y)
        {
            return firstComparer.Compare(x, y) != 0 ? firstComparer.Compare(x, y) : secondComparer.Compare(x, y);
        }
    }
}
