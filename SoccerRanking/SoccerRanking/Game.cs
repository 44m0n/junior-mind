using System;
using TeamsConstructor;

namespace GameConstructor
{
    public class Game
    {
        public Team SecondTeam;
        readonly Team team;
        readonly int firstScore;
        readonly int secondScore;

        readonly int points = 3;

        public Game(Team team, int firstScore, int secondScore)
        {
            this.team = team;
            this.firstScore = firstScore;
            this.secondScore = secondScore;
        }

        public void Update(Team secondteam)
            {
            if (secondteam != null && secondScore > firstScore)
            {
                secondteam.UpdatePoints(points);
                SecondTeam = secondteam;
                return;
            }

            if (secondteam == null || secondScore != firstScore)
            {
                return;
            }

            secondteam.UpdatePoints(1);
            SecondTeam = secondteam;
        }
    }
}
