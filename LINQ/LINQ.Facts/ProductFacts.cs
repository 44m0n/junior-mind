using System;
using Xunit;

namespace LINQ.Facts
{
    public class ProductFacts
    {
        [Fact]
        public void NameProproietyTest()
        {
            var prod = new Product("tricou", 10);

            Assert.Equal("tricou", prod.Name);
        }

        [Fact]
        public void QuantityProproietyTest()
        {
            var prod = new Product("tricou", 10);

            Assert.Equal(10, prod.Quantity);
        }

        [Fact]
        public void NullNameProductConstructor()
        {
            Assert.Throws<ArgumentNullException>(() => new Product(null, 10));
        }

        [Fact]
        public void InvalidQuantityProductConstructor()
        {
            var result = Assert.Throws<ArgumentException>(() => new Product("tricou", -10));

            Assert.Equal("Quantity cannot be less than 0", result.Message);
        }

        [Fact]
        public void UpdateAddProducts()
        {
            var prod = new Product("tricou", 10);
            prod.Update(2);

            Assert.Equal(12, prod.Quantity);
        }

        [Fact]
        public void UpdateSubstractProducts()
        {
            var prod = new Product("tricou", 10);
            prod.Update(-2);

            Assert.Equal(8, prod.Quantity);
        }
    }
}
