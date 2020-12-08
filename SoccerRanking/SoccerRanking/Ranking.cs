using System;
using GameConstructor;
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
            Array.Resize(ref teams, teams.Length + 1);
            teams[^1] = team;
            SortTeams();
        }

        public int GetPosition(Team team)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i] == team)
                {
                    return i + 1;
                }
            }

            return -1;
        }

        public Team GetTeamByPosition(int position)
        {
            return teams[position - 1];
        }

        public void Update(Game game)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].CompareTo(game?.SecondTeam))
                {
                    teams[i] = game?.SecondTeam;
                }
            }

            SortTeams();
        }

        private void SortTeams()
        {
            Team temp;
            for (int i = 0; i < teams.Length - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < teams.Length - 1; j++)
                {
                    if (teams[j].CompareTo(teams[j + 1], true))
                    {
                        temp = teams[j + 1];
                        teams[j + 1] = teams[j];
                        teams[j] = temp;
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }
    }
}
