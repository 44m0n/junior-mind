using System;
using Xunit;

namespace LINQ.Facts
{
    public class StockFacts
    {
        [Fact]
        public void ConstructorWithDuplicateProducts()
        {
            Product[] products =
            {
                new Product("baterie", 20),
                new Product("baterie", 10)
            };

            var err = Assert.Throws<ArgumentException>(() => new Stock(products));
            Assert.Equal("Cannot add duplicate products in stock!", err.Message);
        }

        [Fact]
        public void AddTests()
        {
            Product[] product = { new Product("telefon", 50) };
            var stock = new Stock(product);
            Assert.True(stock.Count == 1);

            Product[] productsToAdd =
            {
                new Product("baterie", 20),
                new Product("masina", 10)
            };

            stock.Add(productsToAdd);
            Assert.True(stock.Count == 3);
        }

        [Fact]
        public void AddTestsWithNullProductsReturnException()
        {
            Product[] product = { new Product("telefon", 50) };
            var stock = new Stock(product);

            Product[] productsToAdd = { default };

            var err = Assert.Throws<ArgumentException>(() => stock.Add(productsToAdd));
            Assert.Equal("Cannot add null products in stock!", err.Message);
        }

        [Fact]
        public void AddTestsWithNullArrayReturnException()
        {
            Product[] product = { new Product("telefon", 50) };
            var stock = new Stock(product);

            Assert.Throws<ArgumentNullException>(() => stock.Add(null));
        }

        [Fact]
        public void AddWithDuplicates()
        {
            Product[] product = { new Product("telefon", 50) };
            var stock = new Stock(product);

            Product[] productsToAdd =
           {
                new Product("baterie", 20),
                new Product("baterie", 10)
            };

            var err = Assert.Throws<ArgumentException>(() => stock.Add(productsToAdd));
            Assert.Equal("Cannot add duplicate products in stock!", err.Message);
        }

        [Fact]
        public void AddElementAlreadyExists()
        {
            Product[] product = { new Product("telefon", 50) };
            var stock = new Stock(product);

            Product[] productsToAdd =
           {
                new Product("baterie", 20),
                new Product("telefon", 10)
            };

            var err = Assert.Throws<ArgumentException>(() => stock.Add(productsToAdd));
            Assert.Equal("The product already exists in stock!", err.Message);
        }

        [Fact]
        public void RefillFacts()
        {
            Product[] product =
            {
                new Product("baterie", 20),
                new Product("masina", 10)
            };

            var stock = new Stock(product);

            Product[] prodToUpdate =
            {
                new Product("altceva", 10),
                new Product("masina", 5)
            };

            stock.Refill(prodToUpdate);

            Assert.True(stock.Count == 3);

            var elements = stock.GetEnumerator();

            elements.MoveNext();
            Assert.Equal("baterie", elements.Current.Name);
            Assert.Equal(20, elements.Current.Quantity);

            elements.MoveNext();
            Assert.Equal("masina", elements.Current.Name);
            Assert.Equal(15, elements.Current.Quantity);

            elements.MoveNext();
            Assert.Equal("altceva", elements.Current.Name);
            Assert.Equal(10, elements.Current.Quantity);
        }
    }
}
