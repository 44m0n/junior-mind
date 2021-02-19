using System;
using System.Collections.Generic;

namespace LINQ
{
    public static class Functions
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckParameterIsNull(source);
            CheckParameterIsNull(predicate);

            foreach (var el in source)
            {
                if (!predicate(el))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckParameterIsNull(source);
            CheckParameterIsNull(predicate);

            foreach (var el in source)
            {
                if (predicate(el))
                {
                    return true;
                }
            }

            return false;
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckParameterIsNull(source);
            CheckParameterIsNull(predicate);

            foreach (var el in source)
            {
                if (predicate(el))
                {
                    return el;
                }
            }

            throw new InvalidOperationException("There is no element that meet the given condition");
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            CheckParameterIsNull(source);
            CheckParameterIsNull(selector);

            foreach (var el in source)
            {
                yield return selector(el);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            CheckParameterIsNull(source);
            CheckParameterIsNull(selector);

            foreach (var el1 in source)
            {
                foreach (var el2 in selector(el1))
                {
                    yield return el2;
                }
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckParameterIsNull(source);
            CheckParameterIsNull(predicate);

            foreach (var el in source)
            {
                if (predicate(el))
                {
                    yield return el;
                }
            }
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
                                                                        this IEnumerable<TSource> source,
                                                                        Func<TSource, TKey> keySelector,
                                                                        Func<TSource, TElement> elementSelector)
        {
            CheckParameterIsNull(source);
            CheckParameterIsNull(keySelector);
            CheckParameterIsNull(elementSelector);

            var dictionary = new Dictionary<TKey, TElement>();

            foreach (var el in source)
            {
                dictionary.Add(keySelector(el), elementSelector(el));
            }

            return dictionary;
        }

        private static void CheckParameterIsNull<T>(T param)
            {
            if (param != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(param));
        }
    }
}
