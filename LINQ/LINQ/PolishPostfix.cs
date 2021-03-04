using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    public class PolishPostfix
    {
        private readonly string ec;

        public PolishPostfix(string input)
        {
            CheckParameterIsNull(input, nameof(input));
            ec = input;
        }

        public double Calculate()
        {
            return ec.Split().Aggregate(Enumerable.Empty<double>(), (operands, current) => double.TryParse(current, out double no) ?
                                                                                operands.Append(no) :
                                                                                UpdateResult(operands, current[0])).Last();
        }

        private IEnumerable<double> UpdateResult(IEnumerable<double> operands, char current)
        {
            const int N = 2;

            var result = CalculateOperation(operands.Take(2), current);

            return operands.Skip(N).Append(result).Reverse();
        }

        private double CalculateOperation(IEnumerable<double> values, char current)
        {
            switch (current)
            {
                case '+':
                    return values.First() + values.Last();
                case '-':
                    return values.First() - values.Last();
                case '*':
                    return values.First() * values.Last();
                default:
                    return values.First() / values.Last();
            }
        }

        private void CheckParameterIsNull<T>(T param, string name)
        {
            if (param != null)
            {
                return;
            }

            throw new ArgumentNullException(paramName: name);
        }
    }
}
