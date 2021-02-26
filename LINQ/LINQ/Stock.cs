using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class Stock : IEnumerable<Product>
    {
        private IEnumerable<Product> products;

        public Stock(Product[] products)
        {
            this.products = products;
        }

        public void Add(Product[] productsToAdd)
        {
            CheckParameterIsNull(productsToAdd, nameof(productsToAdd));

            foreach (var product in productsToAdd)
            {
                products = products.Append(product);
            }
        }

        public IEnumerator<Product> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
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
