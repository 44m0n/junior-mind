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
            feature[1].Id = 5;
            var feature2 = new Feature[] { new Feature() };
            feature2[0].Id = 4;

            var feature3 = new[] { new Feature() };
            feature3[0].Id = 5;

            var pr1 = new ProductWithFeatures();
            pr1.Name = "produs1";
            pr1.Features = feature;

            var pr2 = new ProductWithFeatures();
            pr2.Name = "produs2";
            pr2.Features = feature2;

            var pr3 = new ProductWithFeatures();
            pr3.Name = "produs2";
            pr3.Features = feature3;

            var products = new[] { pr1, pr2, pr3 };

            Assert.Equal(new[] { pr1, pr3 }, Filter.OneOrMoreFeatures(products, feature));
        }
    }
}
