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
            if (team != secondTeam)
            {
                return;
            }

            if (secondScore > firstScore)
            {
                team?.UpdatePoints(points);
                return;
            }

            if (secondScore != firstScore)
            {
                return;
            }

            team?.UpdatePoints(1);
        }
    }
}
