﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public static class Functions
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckParameterIsNull(source, nameof(source));
            CheckParameterIsNull(predicate, nameof(predicate));

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
            CheckParameterIsNull(source, nameof(source));
            CheckParameterIsNull(predicate, nameof(predicate));

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
            CheckParameterIsNull(source, nameof(source));
            CheckParameterIsNull(predicate, nameof(predicate));

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
            CheckParameterIsNull(source, nameof(source));
            CheckParameterIsNull(selector, nameof(selector));

            foreach (var el in source)
            {
                yield return selector(el);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            CheckParameterIsNull(source, nameof(source));
            CheckParameterIsNull(selector, nameof(selector));

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
            CheckParameterIsNull(source, nameof(source));
            CheckParameterIsNull(predicate, nameof(predicate));

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
            CheckParameterIsNull(source, nameof(source));
            CheckParameterIsNull(keySelector, nameof(keySelector));
            CheckParameterIsNull(elementSelector, nameof(elementSelector));

            var dictionary = new Dictionary<TKey, TElement>();

            foreach (var el in source)
            {
                dictionary.Add(keySelector(el), elementSelector(el));
            }

            return dictionary;
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
                                                                        this IEnumerable<TFirst> first,
                                                                        IEnumerable<TSecond> second,
                                                                        Func<TFirst, TSecond, TResult> resultSelector)
        {
            CheckParameterIsNull(first, nameof(first));
            CheckParameterIsNull(second, nameof(second));
            CheckParameterIsNull(resultSelector, nameof(resultSelector));

            var firstEnumElement = first.GetEnumerator();
            var secondEnumElement = second.GetEnumerator();

            while (firstEnumElement.MoveNext() && secondEnumElement.MoveNext())
            {
                yield return resultSelector(firstEnumElement.Current, secondEnumElement.Current);
            }
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(
                                                                    this IEnumerable<TSource> source,
                                                                    TAccumulate seed,
                                                                    Func<TAccumulate, TSource, TAccumulate> func)
        {
            CheckParameterIsNull(source, nameof(source));
            CheckParameterIsNull(seed, nameof(seed));
            CheckParameterIsNull(func, nameof(func));

            TAccumulate result = seed;

            foreach (var el in source)
            {
                result = func(result, el);
            }

            return result;
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
                                                                    this IEnumerable<TOuter> outer,
                                                                    IEnumerable<TInner> inner,
                                                                    Func<TOuter, TKey> outerKeySelector,
                                                                    Func<TInner, TKey> innerKeySelector,
                                                                    Func<TOuter, TInner, TResult> resultSelector)
        {
            CheckParameterIsNull(outer, nameof(outer));
            CheckParameterIsNull(inner, nameof(inner));
            CheckParameterIsNull(outerKeySelector, nameof(outerKeySelector));
            CheckParameterIsNull(innerKeySelector, nameof(innerKeySelector));
            CheckParameterIsNull(resultSelector, nameof(resultSelector));

            foreach (var outEl in outer)
            {
                foreach (var inEl in inner)
                {
                    if (innerKeySelector(inEl).Equals(outerKeySelector(outEl)))
                    {
                        yield return resultSelector(outEl, inEl);
                    }
                }
            }
        }

        public static IEnumerable<TSource> Distinct<TSource>(
                                  this IEnumerable<TSource> source,
                                  IEqualityComparer<TSource> comparer)
        {
            CheckParameterIsNull(source, nameof(source));
            CheckParameterIsNull(comparer, nameof(comparer));

            return new HashSet<TSource>(source, comparer);
        }

        public static IEnumerable<TSource> Union<TSource>(
                                                    this IEnumerable<TSource> first,
                                                    IEnumerable<TSource> second,
                                                    IEqualityComparer<TSource> comparer)
        {
            CheckParameterIsNull(first, nameof(first));
            CheckParameterIsNull(second, nameof(second));
            CheckParameterIsNull(comparer, nameof(comparer));

            HashSet<TSource> result = new HashSet<TSource>(first, comparer);
            result.UnionWith(second);

            return result;
        }

        public static IEnumerable<TSource> Intersect<TSource>(
                                                    this IEnumerable<TSource> first,
                                                    IEnumerable<TSource> second,
                                                    IEqualityComparer<TSource> comparer)
        {
            CheckParameterIsNull(first, nameof(first));
            CheckParameterIsNull(second, nameof(second));
            CheckParameterIsNull(comparer, nameof(comparer));

            HashSet<TSource> result = new HashSet<TSource>(first, comparer);
            result.IntersectWith(second);

            return result;
        }

        public static IEnumerable<TSource> Except<TSource>(
                                                     this IEnumerable<TSource> first,
                                                     IEnumerable<TSource> second,
                                                     IEqualityComparer<TSource> comparer)
        {
            CheckParameterIsNull(first, nameof(first));
            CheckParameterIsNull(second, nameof(second));
            CheckParameterIsNull(comparer, nameof(comparer));

            HashSet<TSource> result = new HashSet<TSource>(first, comparer);
            result.ExceptWith(second);

            return result;
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
                                                    this IEnumerable<TSource> source,
                                                    Func<TSource, TKey> keySelector,
                                                    Func<TSource, TElement> elementSelector,
                                                    Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
                                                    IEqualityComparer<TKey> comparer)
        {
            CheckParameterIsNull(source, nameof(source));
            CheckParameterIsNull(keySelector, nameof(keySelector));
            CheckParameterIsNull(elementSelector, nameof(elementSelector));
            CheckParameterIsNull(resultSelector, nameof(resultSelector));

            var result = new Dictionary<TKey, List<TElement>>(comparer);

            foreach (var el in source)
            {
                var key = keySelector(el);
                if (result.ContainsKey(key))
                {
                    result[key].Add(elementSelector(el));
                }
                else
                {
                    result.Add(key, new List<TElement>());
                    result[key].Add(elementSelector(el));
                }
            }

            foreach (var el in result)
            {
                yield return resultSelector(el.Key, el.Value);
            }
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
                                                        this IEnumerable<TSource> source,
                                                        Func<TSource, TKey> keySelector,
                                                        IComparer<TKey> comparer)
        {
            CheckParameterIsNull(source, nameof(source));
            CheckParameterIsNull(keySelector, nameof(keySelector));
            CheckParameterIsNull(comparer, nameof(comparer));

            return new OrderedEnumerable<TSource>(source, new ProjectionComparer<TSource, TKey>(keySelector, comparer));
        }

        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
                                                        this IOrderedEnumerable<TSource> source,
                                                        Func<TSource, TKey> keySelector,
                                                        IComparer<TKey> comparer)
        {
            CheckParameterIsNull(source, nameof(source));
            CheckParameterIsNull(keySelector, nameof(keySelector));
            CheckParameterIsNull(comparer, nameof(comparer));

            return source.CreateOrderedEnumerable(keySelector, comparer, false);
        }

        private static void CheckParameterIsNull<T>(T param, string name)
        {
            if (param != null)
            {
                return;
            }

            throw new ArgumentNullException(paramName: name);
        }
    }
}
