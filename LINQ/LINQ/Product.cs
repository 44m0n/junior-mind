using System;

namespace LINQ
{
    public class Product
    {
        public Product(string name, int quantity)
        {
            CheckParameterIsNull(name, nameof(name));

            CheckIfQuantityIsLessThanZero(quantity);

            Name = name;
            Quantity = quantity;
        }

        public string Name { get; protected set; }

        public int Quantity { get; protected set; }

        public void Add(int no)
        {
            CheckIfQuantityIsLessThanZero(no);

            Quantity += no;
        }

        public void Substract(int no)
        {
            CheckIfQuantityIsLessThanZero(no);
            CheckIfQuantityIsLessThanZero(Quantity - no);

            Quantity -= no;
        }

        public override bool Equals(object obj)
        {
            return obj is Product prod
                && Name == prod.Name;
        }

        private void CheckIfQuantityIsLessThanZero(int no)
        {
            if (no >= 0)
            {
                return;
            }

            throw new ArgumentException("Quantity cannot be less than 0");
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
