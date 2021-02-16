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
    }
}
