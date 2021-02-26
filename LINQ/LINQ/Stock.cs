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
            CheckParameterIsNull(products, nameof(products));
            CheckProductIsNull(products);
            CheckForDuplicates(products);

            this.products = products;
        }

        public int Count
        {
            get
            {
                return products.Count();
            }
        }

        public void Add(Product[] productsToAdd)
        {
            CheckParameterIsNull(productsToAdd, nameof(productsToAdd));
            CheckProductIsNull(productsToAdd);
            CheckForDuplicates(productsToAdd);

            foreach (var product in productsToAdd)
            {
                if (products.SingleOrDefault(prod => prod.Equals(product)) != default)
                {
                    throw new ArgumentException("The product already exists in stock!");
                }

                products = products.Append(product);
            }
        }

        public void Refill(Product[] productsToUpdate)
        {
            CheckParameterIsNull(productsToUpdate, nameof(productsToUpdate));

            foreach (var product in productsToUpdate)
            {
                try
                {
                    products.Single(prod => prod.Equals(product)).Add(product.Quantity);
                }
                catch (InvalidOperationException e)
                {
                    Add(new[] { product });
                }
            }
        }

        public void Sell(Product[] productsToSell)
        {
            CheckParameterIsNull(productsToSell, nameof(productsToSell));

            foreach (var product in productsToSell)
            {
                try
                {
                    products.Single(prod => prod.Equals(product)).Substract(product.Quantity);
                }
                catch
                {
                    throw new ArgumentException("The product you're trying to sell doesn't exists in the current stock");
                }
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

        private void CheckParameterIsNull<T>(T param, string name)
        {
            if (param != null)
            {
                return;
            }

            throw new ArgumentNullException(paramName: name);
        }

        private void CheckForDuplicates(Product[] prod)
        {
            if (!prod.GroupBy(x => x.Name).Any(y => y.Count() > 1))
            {
                return;
            }

            throw new ArgumentException("Cannot add duplicate products in stock!");
        }

        private void CheckProductIsNull(Product[] prod)
        {
            if (!prod.Contains(null))
            {
                return;
            }

            throw new ArgumentException("Cannot add null products in stock!");
        }
    }
}
