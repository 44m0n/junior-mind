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

        public bool CompareTo(Team anotherTeam, bool entireTeam = false)
        {
            if (entireTeam)
            {
                return anotherTeam != null && anotherTeam.team == team && anotherTeam.points == points;
            }

            return anotherTeam != null && anotherTeam.team == team;
        }

        public void UpdatePoints(int n)
        {
            points += n;
        }
    }
}