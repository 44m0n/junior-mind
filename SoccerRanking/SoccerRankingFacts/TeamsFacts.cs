using System;
using Xunit;
using TeamsConstructor;

namespace SoccerRankingFacts
{
    public class TeamsFacts
    {

        [Fact]
        public void TestAddTeamToList()
        {
            Team team = new Team("cluj", 20);
            Teams teams = new Teams("cluj", 20);
            Team resultedTeams = teams.AddTeamToList();
            Assert.True(resultedTeams.Equals(team));
        }
    }
}
