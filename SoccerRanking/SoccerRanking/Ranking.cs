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
            foreach (var team in teams)
            {
                game?.Update(team);
            }

            SortTeams();
        }

        private void SortTeams()
        {
            for (int i = 0; i < teams.Length - 1; i++)
            {
                bool swapped = false;
                for (int j = teams.Length - 1; j > i; j--)
                {
                    if (teams[j - 1].CompareTo(teams[j], true))
                    {
                        Swap(j - 1, j);
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }

        private void Swap(int i, int j)
        {
            Team temp = teams[j];
            teams[j] = teams[i];
            teams[i] = temp;
        }
    }
}
