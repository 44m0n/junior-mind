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
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].CompareTo(team, true))
                {
                    Team temp = teams[i];
                    teams[i] = team;

                    for (int j = i + 1; j < teams.Length; j++)
                    {
                        Team temp2 = teams[j];
                        teams[j] = temp;
                        temp = temp2;
                    }

                    break;
                }
            }
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

        public void Update(Game game)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].CompareTo(game?.SecondTeam))
                {
                    teams[i] = game?.SecondTeam;
                }
            }

            SortTeamsAfterAGame();
        }

        private void SortTeamsAfterAGame()
        {
            Team temp;
            for (int i = 0; i < teams.Length - 1; i++)
            {
                for (int j = 0; j < teams.Length - 1; j++)
                {
                    if (teams[i].CompareTo(teams[i + 1], true))
                    {
                        temp = teams[i + 1];
                        teams[i + 1] = teams[i];
                        teams[i] = temp;
                    }
                }
            }
        }
    }
}
