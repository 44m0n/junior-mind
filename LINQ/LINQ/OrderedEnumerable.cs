using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class OrderedEnumerable<TSource> : IOrderedEnumerable<TSource>
    {
        private readonly IEnumerable<TSource> source;
        private readonly IComparer<TSource> comparer;

        public OrderedEnumerable(IEnumerable<TSource> source, IComparer<TSource> comparer)
        {
            this.source = source;
            this.comparer = comparer;
        }

        public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey>(Func<TSource, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            IComparer<TSource> secondComparer = new ProjectionComparer<TSource, TKey>(keySelector, comparer);

            return new OrderedEnumerable<TSource>(source, new CompoundComparer<TSource>(this.comparer, secondComparer));
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            List<TSource> elements = source.ToList();

            while (elements.Count > 0)
            {
                TSource minElement = elements[0];
                int minIndex = 0;

                for (int i = 1; i < elements.Count; i++)
                {
                    if (this.comparer.Compare(elements[i], minElement) < 0)
                    {
                        minElement = elements[i];
                        minIndex = i;
                    }
                }

                elements.RemoveAt(minIndex);
                yield return minElement;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
