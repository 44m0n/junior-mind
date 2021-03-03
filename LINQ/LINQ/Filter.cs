using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    public static class Filter
    {
        public static IEnumerable<ProductWithFeatures> OneOrMoreFeatures(ProductWithFeatures[] products, Feature[] features)
        {
            return from pr in products
                         where features.Select(f => f.Id).Intersect(pr.Features.Select(pf => pf.Id)).Any()
                         select pr;
        }

        public static IEnumerable<ProductWithFeatures> AllFeatures(ProductWithFeatures[] products, Feature[] features)
        {
            return from pr in products
                   where !features.Select(f => f.Id).Except(pr.Features.Select(pf => pf.Id)).Any()
                   select pr;
        }

        public static IEnumerable<ProductWithFeatures> NoneOfFeatures(ProductWithFeatures[] products, Feature[] features)
        {
            return from pr in products
                   where !features.Select(f => f.Id).Intersect(pr.Features.Select(pf => pf.Id)).Any()
                   select pr;
        }

        public static IEnumerable<Product> Union(Product[] first, Product[] second)
        {
            CheckParameterIsNull(first, nameof(first));
            CheckParameterIsNull(second, nameof(second));

            var products = first.Concat(second);

            return products.GroupBy(p => p.Name, p => p.Quantity, (name, quantity) => new Product(name, quantity.Sum()));
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
