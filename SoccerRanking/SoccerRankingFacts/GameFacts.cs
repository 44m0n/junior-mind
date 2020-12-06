using System;
using Xunit;
using GameConstructor;
using TeamsConstructor;

namespace SoccerRankingFacts
{
    public class GameFacts
    {
        [Fact]
        public void CalculatePointsWithOneWinner()
        {
            Team firstTeam = new Team("Cluj", 10);
            Game firstTeamData = new Game(firstTeam, 3);
            Team[] result = firstTeamData.Update(new Team("Alba", 10), 0);
            Assert.True(result[0].CompareTo(new Team("Cluj", 13), true));
        }

        [Fact]
        public void CalculatePointsWithADraw()
        {
            Team firstTeam = new Team("Cluj", 10);
            Team secondTeam = new Team("Alba", 5);
            Game firstTeamData = new Game(firstTeam, 3);
            Team[] result = firstTeamData.Update(secondTeam, 3);
            Assert.True(result[0].CompareTo(new Team("Cluj", 11), true));
            Assert.True(result[1].CompareTo(new Team("Alba", 6), true));
        }
    }
}
