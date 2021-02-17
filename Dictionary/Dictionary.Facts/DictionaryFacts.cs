using System;
using Xunit;
using System.Collections.Generic;

namespace Dictionary.Facts
{
    public class DictionaryFacts
    {
        [Fact]
        public void AddFact()
        {
            var dict = new DictionaryObject<int, string>();
            dict.Add(1, "ceva");
            Assert.True(dict[1] == "ceva");
            Assert.Equal(1, dict.Count);
        }

        [Fact]
        public void AddFactPair()
        {
            var dict = new DictionaryObject<int, string>() { { 1, "a" }, { 2, "b" }, { 3, "c" } };
            dict.Add((new KeyValuePair<int, string>(5, "b")));
            Assert.Equal(4, dict.Count);
            Assert.Equal("b", dict[5]);
        }

        [Fact]
        public void AddFactPairWithConflicts()
        {
            var dict = new DictionaryObject<int, string>() { { 1, "a" }, { 2, "b" }, { 3, "c" } };
            dict.Add((new KeyValuePair<int, string>(6, "b")));
            Assert.Equal(4, dict.Count);
            Assert.Equal("b", dict[6]);
        }

        [Fact]
        public void IndexGet()
        {
            var dict = new DictionaryObject<int, string>();
            dict.Add(1, "ceva");
            Assert.Equal("ceva", dict[1]);
        }

        [Fact]
        public void IndexSet()
        {
            var dict = new DictionaryObject<int, string>();
            dict.Add(1, "ceva");
            dict[1] = "altceva";
            Assert.Equal("altceva", dict[1]);
        }

        [Fact]
        public void ClearFacts()
        {
            var dict = new DictionaryObject<int, string>();
            dict.Add(1, "ceva");
            Assert.Equal(1, dict.Count);
            dict.Clear();
            Assert.Equal(0, dict.Count);
        }

        [Fact]
        public void ContainsFacts()
        {
            var dict = new DictionaryObject<int, string>();
            dict.Add(1, "ceva");

            Assert.True(dict.ContainsKey(1));
            Assert.False(dict.ContainsKey(2));
        }

        [Fact]
        public void ContainsPair()
        {
            var dict = new DictionaryObject<int, string>() { { 1, "a" }, { 2, "b" } };
            Assert.True(dict.Contains(new KeyValuePair<int, string>(1, "a")));
            Assert.False(dict.Contains(new KeyValuePair<int, string>(1, "b")));
            Assert.False(dict.Contains(new KeyValuePair<int, string>(5, "b")));
        }

        [Fact]
        public void Remove()
        {
            var dict = new DictionaryObject<int, string>() { { 1, "a" }, { 2, "b" } };
            dict.Remove(1);
            Assert.False(dict.Contains(new KeyValuePair<int, string>(1, "a")));
        }

        [Fact]
        public void RemoveWithConflicts()
        {
            var dict = new DictionaryObject<int, string>() { { 1, "a" }, { 6, "b" }, { 3, "c" } };
            Assert.Equal(3, dict.Count);
            dict.Remove(6);
            Assert.Equal(2, dict.Count);
            Assert.True(dict.Contains(new KeyValuePair<int, string>(1, "a")));
            Assert.False(dict.Contains(new KeyValuePair<int, string>(6, "b")));
        }
    }
}
