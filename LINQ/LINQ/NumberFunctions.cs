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
            CheckParameterIsNull(sum, nameof(sum));
            CheckParameterIsNull(max, nameof(max));

            if (sum < 1)
            {
                throw new ArgumentException("The set max limit cannot be less than 1");
            }

            IEnumerable<string> seed = new[] { "" };
            var signs = Enumerable.Range(1, max).Aggregate(seed, (res, x) =>
                                                            res.SelectMany(result => new[] { result + "+", result + "-" }));

            return signs.Select(sign => Enumerable.Range(1, max).Select(no => sign[no - 1] == '+' ? no : no * -1)).Where(set =>
                                                                                                            set.Sum() == sum);
        }

        public static IEnumerable<IEnumerable<int>> GetPythagoraTriplets(int[] source)
        {
            const int N = 2;

            IEnumerable<IEnumerable<int>> PermutePairs(int first, int second, int third)
            {
                return new[]
                {
                        new[] { first, second, third }, new[] { first, third, second },
                        new[] { second, first, third }, new[] { second, third, first },
                        new[] { third, first, second }, new[] { third, second, first }
                };
            }

            var pairs = source.SelectMany((first, firstIndex) =>
                            source.Skip(firstIndex + 1).SelectMany((second, secondIndex) =>
                                source.Skip(firstIndex + 1 + secondIndex + 1).Select(third => new[] { first, second, third })));

            return pairs.SelectMany(pair =>
            {
                return PermutePairs(pair[0], pair[1], pair.Last()).Where(e =>
                        (int)Math.Pow(e.First(), N) + (int)Math.Pow(e.ElementAt(1), N) == (int)Math.Pow(e.Last(), N));
            });
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
