using System;
using TeamsConstructor;

namespace RankingConstructor
{
    public class Ranking
    {
        private Team[] teams;

        public Ranking(Team[] teams)
        {
            this.teams = teams;
        }

        public void AddTeam(Team team)
        {
            Team[] newTeams = new Team[teams.Length + 1];
            newTeams[0] = team;
            for (int i = 1; i < newTeams.Length; i++)
            {
                newTeams[i] = teams[i - 1];
            }

            teams = newTeams;
        }

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

        public void Update(Team teamData)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].CompareTo(teamData))
                {
                    teams[i] = teamData;
                }
            }
        }
    }
}
