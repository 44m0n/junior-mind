namespace IMatchConstructor
{
    class Match
    {
        private readonly IMatch[] matches;

        public Match(IMatch[] matches)
        {
            this.matches = matches;
        }
    }
}
