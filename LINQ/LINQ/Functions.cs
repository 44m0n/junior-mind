﻿using System;
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