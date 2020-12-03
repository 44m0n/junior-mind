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

        public Team[] GetRanking()
        {
            Team tempTeam;
            for (int j = 0; j < teams.Length - 1; j++)
            {
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    if (teams[i].CompareTo(teams[i + 1]))
                    {
                        tempTeam = teams[i + 1];
                        teams[i + 1] = teams[i];
                        teams[i] = tempTeam;
                    }
                }
            }

            return teams;
        }

        public Team GetPosition(int position) => teams[position - 1];

        public int GetPositionUsingName(string name)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].SearchTeamName(name))
                {
                    return i + 1;
                }
            }

            return -1;
        }
    }
}
