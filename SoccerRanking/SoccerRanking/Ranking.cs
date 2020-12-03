using System;
using TeamsConstructor;

namespace RankingConstructor
{
    public class Ranking
    {
        readonly Team[] teams;

        public Ranking(Team[] teams)
        {
            this.teams = teams;
        }

        public void AddTeamToRanking(Team team)
        {
            Team[] newTeams = new Team[teams.Length + 1];
            newTeams[0] = team;
            for (int i = 1; i < newTeams.Length; i++)
            {
                newTeams[i] = teams[i - 1];
            }
        }

        public Team GetPosition(int position) => teams[position - 1];

        public int GetPosition(Team team)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].CompareTo(team))
                {
                    return i + 1;
                }
            }

            return -1;
        }
    }
}
