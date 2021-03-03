using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LINQ.Facts
{
    public class FilterFacts
    {
        [Fact]
        public void OneOrMoreTest()
        {
            var feature = new Feature[] { new Feature(), new Feature(), new Feature() };
            feature[0].Id = 1;
            feature[1].Id = 3;
            var feature2 = new Feature[] { new Feature() };
            feature2[0].Id = 4;

            var pr1 = new ProductWithFeatures();
            pr1.Name = "produs1";
            pr1.Features = feature;

            var pr2 = new ProductWithFeatures();
            pr2.Name = "produs2";
            pr2.Features = feature2;

            var products = new[] { pr1, pr2 };

            Assert.Equal(new[] { pr2 }, Filter.OneOrMoreFeatures(products, feature2));
        }
    }
}
