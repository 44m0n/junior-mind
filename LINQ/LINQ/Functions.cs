using System;
using System.Collections.Generic;
using System.Text;

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
