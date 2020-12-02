using System;
using Xunit;
using TeamsConstructor;

namespace SoccerRankingFacts
{
    public class TeamsFacts
    {

        [Fact]
        public void CompareToReturnTrue()
        {
            Team team = new Team("Cluj", 20);
            Team secondTeam = new Team("botosani", 30);
            Assert.True(team.CompareTo(secondTeam));
        }


        [Fact]
        public void CompareToReturnFalse()
        {
            Team team = new Team("Cluj", 20);
            Team secondTeam = new Team("botosani", 10);
            Assert.False(team.CompareTo(secondTeam));
        }

    }
}
