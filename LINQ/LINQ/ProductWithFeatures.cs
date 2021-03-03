using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    public class ProductWithFeatures
    {
        public string Name { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
        public ICollection<Feature> Features { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
