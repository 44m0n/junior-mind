﻿using Xunit;
using RangeConstructor;

namespace Json.Facts
{
    public class RangeFacts
    {
        [Fact]
        public void MatchFactsReturnTrue()
        {
            var range = new Range('a', 'f');
            string text = "abcd";
            Assert.True(range.Match(text));
        }

        [Fact]
        public void MatchFactsReturnTrueWithDigit()
        {
            var range = new Range('1', 'f');
            string text = "1abcd";
            Assert.True(range.Match(text));
        }

        [Fact]
        public void MatchFactsReturnFalse()
        {
            var range = new Range('a', 'f');
            string text = "1abcd";
            Assert.False(range.Match(text));
        }
    }
}
