using System;
using TeamsConstructor;

namespace GameConstructor
{
    public class Game
    {
        readonly Team firstTeam;
        readonly Team secondTeam;
        readonly int firstScore;
        readonly int secondScore;

        readonly int points = 3;

        public Game(Team firstTeam, Team secondTeam, int firstScore, int secondScore)
        {
            this.firstTeam = firstTeam;
            this.secondTeam = secondTeam;
            this.firstScore = firstScore;
            this.secondScore = secondScore;
        }

        public void Update(Team team)
            {
            if (Winner() == team)
            {
                team?.UpdatePoints(points);
                return;
            }

            if (Winner() != null || (team != firstTeam && team != secondTeam))
            {
                return;
            }

            team?.UpdatePoints(1);
        }

        private Team Winner()
        {
            if (firstScore > secondScore)
            {
                return firstTeam;
            }

            return secondScore > firstScore ? secondTeam : null;
        }
    }
}
