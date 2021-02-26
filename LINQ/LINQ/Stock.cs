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
            foreach (var product in products)
            {
                yield return product;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
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
