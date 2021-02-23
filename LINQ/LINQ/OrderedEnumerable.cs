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

        public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey>(Func<TSource, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            var result = new SortedDictionary<TKey, List<TSource>>(comparer);

            foreach (var el in source)
            {
                var key = keySelector(el);
                if (result.ContainsKey(key))
                {
                    result[key].Add(el);
                }
                else
                {
                    result.Add(key, new List<TSource>());
                    result[key].Add(el);
                }
            }

            return (IOrderedEnumerable<TSource>)result;
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
