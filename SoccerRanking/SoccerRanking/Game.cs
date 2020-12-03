using System;
using TeamsConstructor;

namespace GameConstructor
{
    public class Game
    {
        readonly string firstName;
        readonly int firstScore;
        readonly string secondName;
        readonly int secondScore;

        readonly int points = 3;

        public Game(string firstName, string secondName, int firstScore, int secondScore)
        {
            this.firstName = firstName;
            this.firstScore = firstScore;
            this.secondName = secondName;
            this.secondScore = secondScore;
        }

        public Team[] CalculatePoints()
        {
            // Three points for a win, one point for a draw, zero points for a lose
            if (firstScore > secondScore)
            {
                return new[] { new Team(firstName, points), new Team(secondName, 0) };
            }

            if (firstScore < secondScore)
            {
                return new[] { new Team(firstName, 0), new Team(secondName, points) };
            }

            return new[] { new Team(firstName, 1), new Team(secondName, 1) };
        }
    }
}
