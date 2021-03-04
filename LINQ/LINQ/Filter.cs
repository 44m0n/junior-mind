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
            return products.Where(p => features.Select(f => f.Id).Intersect(p.Features.Select(pf => pf.Id)).Any());
        }

        public static IEnumerable<ProductWithFeatures> AllFeatures(ProductWithFeatures[] products, Feature[] features)
        {
            return products.Where(p => !features.Select(f => f.Id).Except(p.Features.Select(pf => pf.Id)).Any());
        }

        public static IEnumerable<ProductWithFeatures> NoneOfFeatures(ProductWithFeatures[] products, Feature[] features)
        {
            return products.Where(p => !features.Select(f => f.Id).Intersect(p.Features.Select(pf => pf.Id)).Any());
        }

        public static IEnumerable<Product> Union(Product[] first, Product[] second)
        {
            CheckParameterIsNull(first, nameof(first));
            CheckParameterIsNull(second, nameof(second));

            var products = first.Concat(second);

            return products.GroupBy(p => p.Name, p => p.Quantity, (name, quantity) => new Product(name, quantity.Sum()));
        }

        public static IEnumerable<TestResult> GetFinalScore(TestResult[] source)
        {
            return source.GroupBy(result => result.FamilyId, result => result, (familyId, results) =>
                                    new TestResult(results.First().Id, familyId, results.Select(r => r.Score).Max()));
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
