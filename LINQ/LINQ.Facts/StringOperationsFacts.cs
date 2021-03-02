using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LINQ.Facts
{
    public class StringOperationsFacts
    {
        [Fact]
        public void GetConsAndVowelsCountTest()
        {
            string text = "ana are mere";

            (int v, int c) result = StringOperations.GetConsAndVowelsCount(text);
            Assert.Equal(6, result.v);
            Assert.Equal(4, result.c);
        }

        [Fact]
        public void FirstUniqueCharacterTest()
        {
            string text = "ana are mere";

            Assert.Equal('n', StringOperations.FirstUniqueCharacter(text));
        }

        [Fact]
        public void ConvertToIntTest()
        {
            string text = "123";
            Assert.Equal(123, StringOperations.ConvertStringToInt(text));
            text = "-123";
            Assert.Equal(-123, StringOperations.ConvertStringToInt(text));
        }

        [Fact]
        public void MaxOccurenceTest()
        {
            string text = "area";
            Assert.Equal('a', StringOperations.MaxOccurence(text));
        }

        [Fact]
        public void CheckPalindroms()
        {
            string text = "aabaac";
            IEnumerable<string> enumerable = new[] { "a", "a", "a", "a", "b", "c", "aa", "aa", "aba", "aabaa" };

            var palindroms = StringOperations.GetPalindroms("aabaac").OrderBy(e => e.Length, Comparer<int>.Default).ThenBy(e => e, Comparer<string>.Default);

            Assert.Equal(enumerable, palindroms);
        }

        [Fact]
        public void GetTopWordsTest()
        {
            string text = "Ana3 are, pere si mere si mere- iarasi mere";

            IEnumerable<(string word, int count)> result = StringOperations.TopWords(text, 2);
            
            var element = result.GetEnumerator();

            element.MoveNext();
            Assert.Equal("mere", element.Current.word);
            Assert.Equal(3, element.Current.count);

            element.MoveNext();
            Assert.Equal("si", element.Current.word);
            Assert.Equal(2, element.Current.count);
        }

    }
}
