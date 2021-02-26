using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    public class Product
    {
        public Product (string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public string Name { get; protected set; }

        public int Quantity { get; protected set; }

        public void Add(int no)
        {
            Quantity += no;
        }

        public void Substract(int no)
        {
            Quantity -= no;
        }
    }
}
