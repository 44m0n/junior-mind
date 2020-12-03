using System;

namespace TeamsConstructor
{
    public class Team
    {
        readonly string team;
        private int points;

        public Team(string team, int points)
        {
            this.team = team;
            this.points = points;
        }

        public bool CompareTo(Team anotherTeam)
        {
            return anotherTeam != null && anotherTeam.points == points && anotherTeam.team == team;
        }

        public void UpdatePoints(int n)
        {
            points += n;
        }
    }
}