using System;

namespace TeamsConstructor
{
    public class Team
    {
        readonly string team;
        readonly int points;

        public Team(string team, int points)
        {
            this.team = team;
            this.points = points;
        }

        public bool CompareTo(Team anotherTeam)
        {
            return anotherTeam != null && anotherTeam.points > points;
        }
    }
}