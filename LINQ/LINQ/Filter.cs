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
    }
}
