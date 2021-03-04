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
