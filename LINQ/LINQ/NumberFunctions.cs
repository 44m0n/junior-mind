using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    public class NumberFunctions
    {
        public static IEnumerable<IEnumerable<int>> GetAllSubsetsLessThan(int[] source, int sum)
        {
            return source.SelectMany((no1, firstIndex) =>
                        source.Skip(firstIndex).Select((no2, secondIndex) =>
                            source.Skip(firstIndex).Take(source.Length - firstIndex - secondIndex))).Where(x =>
                               x.Sum() <= sum);
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
