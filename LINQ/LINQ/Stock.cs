using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    public class Stock : IEnumerable<Product>
    {
        private readonly IEnumerable<Product> products;

        public Stock(Product[] products)
        {
            this.products = products;
        }

        public IEnumerator<Product> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
