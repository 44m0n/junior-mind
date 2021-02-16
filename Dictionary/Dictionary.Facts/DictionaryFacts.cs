using System;
using Xunit;
using Dictionary;

namespace Dictionary.Facts
{
    public class DictionaryFacts
    {
        [Fact]
        public void AddFact()
        {
            var dict = new Dictionary.DictionaryObject<int, string>();
            dict.Add(1, "ceva");
            Assert.Equal(1, dict.Count);
        }

        [Fact]
        public void IndexGet()
        {
            var dict = new Dictionary.DictionaryObject<int, string>();
            dict.Add(1, "ceva");
            Assert.Equal("ceva", dict[1]);
        }

        [Fact]
        public void IndexSet()
        {
            var dict = new Dictionary.DictionaryObject<int, string>();
            dict.Add(1, "ceva");
            dict[1] = "altceva";
            Assert.Equal("altceva", dict[1]);
        }

        [Fact]
        public void ClearFacts()
        {
            var dict = new Dictionary.DictionaryObject<int, string>();
            dict.Add(1, "ceva");
            Assert.Equal(1, dict.Count);
            dict.Clear();
            Assert.Equal(0, dict.Count);
        }

        public void ContainsFacts()
        {
            var dict = new Dictionary.DictionaryObject<int, string>();
            dict.Add(1, "ceva");

            Assert.True(dict.ContainsKey(1));
        }
    }
}
