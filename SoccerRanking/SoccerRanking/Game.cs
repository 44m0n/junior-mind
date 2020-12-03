using System;
using TeamsConstructor;

namespace GameConstructor
{
    public class Game
    {
        readonly Team team;
        readonly int score;

        readonly int points = 3;

        public Game(Team team, int score)
        {
            this.team = team;
            this.score = score;
        }

        public void Update(Game secondTeam)
        {
            // Three points for a win, one point for a draw, zero points for a lose
            if (secondTeam != null && score > secondTeam.score)
            {
                team.UpdatePoints(points);
            }

            if (secondTeam != null && score < secondTeam.score)
            {
                secondTeam.team.UpdatePoints(points);
            }

            if (secondTeam == null || score != secondTeam.score)
            {
                return;
            }

            team.UpdatePoints(1);
            secondTeam.team.UpdatePoints(1);
        }
    }
}
