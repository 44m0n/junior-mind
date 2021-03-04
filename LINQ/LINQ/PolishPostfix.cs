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
            return ec.Aggregate(Enumerable.Empty<double>(), (operands, current) => "+-*/%".Contains(current) ?
                                                                                UpdateResult(operands, current) :
                                                                                operands.Append(Convert.ToDouble(current))).Last();
        }

        private IEnumerable<double> UpdateResult(IEnumerable<double> operands, char current)
        {
            throw new NotImplementedException();
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
