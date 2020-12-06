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

        public Team[] Update(Team secondTeam, int secondScore)
        {
            // Three points for a win, one point for a draw, zero points for a lose
            if (secondTeam != null && score > secondScore)
            {
                team.UpdatePoints(points);
                return new[] { team, secondTeam };
            }

            if (secondTeam != null && score < secondScore)
            {
                secondTeam.UpdatePoints(points);
                return new[] { team, secondTeam };
            }

            team.UpdatePoints(1);
            secondTeam?.UpdatePoints(1);
            return new[] { team, secondTeam };
        }
    }
}
