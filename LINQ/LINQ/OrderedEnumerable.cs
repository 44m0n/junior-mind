using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class OrderedEnumerable<TSource, TKey> : IOrderedEnumerable<TSource>
    {
        private readonly IEnumerable<TSource> source;
        private readonly Func<TSource, TKey> keySelector;
        private readonly IComparer<TKey> comparer;

        public OrderedEnumerable(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            this.source = source;
            this.keySelector = keySelector;
            this.comparer = comparer;
        }

        public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey1>(Func<TSource, TKey1> keySelector, IComparer<TKey1> comparer, bool descending)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
