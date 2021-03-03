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

        [Fact]
        public void AllTest()
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

            Assert.Equal(new[] { pr1 }, Filter.AllFeatures(products, feature));
        }

        [Fact]
        public void NoneTest()
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

            Assert.Equal(new[] { pr2 }, Filter.NoneOfFeatures(products, feature));
        }

        [Fact]
        public void UnionTest()
        {
            var stock1 = new[] { new Product("telefon", 4), new Product("baterie", 3), new Product("incarcator", 5) };
            var stock2 = new[] { new Product("telefon", 2), new Product("baterie", 1) };

            var expected = new[] { new Product("telefon", 6), new Product("baterie", 4), new Product("incarcator", 5) };

            Assert.Equal(expected, Filter.Union(stock1, stock2));
        }

        [Fact]
        public void GetFinalScoreTest()
        {
            var test = new[] { new TestResult("0", "0", 3), new TestResult("1", "1", 10), new TestResult("3", "0", 11) };
            var expected = new[] { new TestResult("0", "0", 11), new TestResult("1", "1", 10) };

            Assert.Equal(expected, Filter.GetFinalScore(test));
        }
    }
}
