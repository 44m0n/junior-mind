using System;
using IMatchConstructor;

namespace MatchConstructor
{
    public class Match : IMatch
    {
        readonly bool response;
        readonly string remainingText;

        public Match(bool response, string remainingText)
        {
            this.response = response;
            this.remainingText = remainingText;
        }

        public bool Success()
        {
            return response;
        }

        public string RemainingText()
        {
            return remainingText;
        }
    }
}
