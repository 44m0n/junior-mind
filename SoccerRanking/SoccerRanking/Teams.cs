using System;

namespace TeamsConstructor
{
    public struct Team
    {
        public string Name;
        public int Points;

        public Team(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }
    }

    public class Teams
    {
        readonly string team;
        readonly int points;

        public Teams(string team, int points)
        {
            this.team = team;
            this.points = points;
        }

        public Team AddTeamToList()
        {
            return new Team(team, points);
        }
    }
}
