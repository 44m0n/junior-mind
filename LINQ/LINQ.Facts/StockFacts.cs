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

        [Fact]
        public void SellTests()
        {
            Product[] product =
            {
                new Product("baterie", 20),
                new Product("masina", 10)
            };

            var stock = new Stock(product);

            Product[] productsToSell =
            {
                new Product("baterie", 10),
                new Product("masina", 2),
                new Product("masina", 2)
            };

            stock.Sell(productsToSell);
            Assert.Equal(2, stock.Count);

            var element = stock.GetEnumerator();
            element.MoveNext();

            Assert.Equal(10, element.Current.Quantity);
            element.MoveNext();
            Assert.Equal(6, element.Current.Quantity);
        }

        [Fact]
        public void SellIfProductDoesntExists()
        {
            Product[] product =
{
                new Product("baterie", 20),
                new Product("masina", 10)
            };

            var stock = new Stock(product);


            Product[] productsToSell =
            {
                new Product("iphone", 10)
            };

            var err = Assert.Throws<ArgumentException>(() => stock.Sell(productsToSell));
            Assert.Equal("The product you're trying to sell doesn't exists in the current stock", err.Message);
        }

        [Fact]
        public void RemoveTest()
        {
            Product[] product =
{
                new Product("baterie", 20),
                new Product("masina", 10),
                new Product("telefon", 30),
            };

            var stock = new Stock(product);

            Assert.Equal(3, stock.Count);
            Assert.Throws<ArgumentNullException>(() => stock.Remove(null));

            Product[] productToSell =
            {
                 new Product("baterie", 20),
                 new Product("telefon", 30)
            };

            stock.Remove(productToSell);
            Assert.Equal(1, stock.Count);
        }

        [Fact]
        public void TestCallback()
        {
            string notification = "";
            void CallbackFunct(Product product, int quantity)
            {
                notification = $"There are only {quantity} pices left of {product.Name}";
            }

            Product[] product =
{
                new Product("baterie", 20),
                new Product("masina", 10),
                new Product("telefon", 30),
            };

            Product[] productToSell =
            {
                 new Product("baterie", 16),
            };

            var stock = new Stock(product);

            stock.StartNewCallback(CallbackFunct);

            stock.Sell(productToSell);

            Assert.Equal("There are only 4 pices left of baterie", notification);
        }

    }
}
