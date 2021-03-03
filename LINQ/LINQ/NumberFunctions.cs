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

        public static IEnumerable<IEnumerable<int>> GetAllCombinations(int max, int sum)
        {
            IEnumerable<string> seed = new[] { "" };
            var signs = Enumerable.Range(1, max).Aggregate(seed, (res, x) =>
                                                            res.SelectMany(result => new[] { result + "+", result + "-" }));

            return signs.Select(sign => Enumerable.Range(1, max).Select(no => sign[no - 1] == '+' ? no : no * -1)).Where(set =>
                                                                                                            set.Sum() == sum);
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
