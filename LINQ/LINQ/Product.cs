using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    public class Product
    {
        public Product(string name, int quantity)
        {
            CheckParameterIsNull(name, nameof(name));

            if (quantity < 0)
            {
                throw new ArgumentException("Quantity cannot be less than 0");
            }

            Name = name;
            Quantity = quantity;
        }

        public string Name { get; protected set; }

        public int Quantity { get; protected set; }

        public void Update(int no)
        {
            Quantity += no;
        }

        public override bool Equals(object obj)
        {
            return obj is Product prod
                && Name == prod.Name;
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
