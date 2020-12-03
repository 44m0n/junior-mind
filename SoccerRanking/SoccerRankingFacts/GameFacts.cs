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
            firstTeamData.Update(new Game(new Team("Alba", 10), 0));
            Assert.True(firstTeam.CompareTo(new Team("Cluj", 13)));
        }

        [Fact]
        public void CalculatePointsWithADraw()
        {
            Team firstTeam = new Team("Cluj", 10);
            Team secondTeam = new Team("Alba", 5);
            Game firstTeamData = new Game(firstTeam, 3);
            firstTeamData.Update(new Game(secondTeam, 3));
            Assert.True(firstTeam.CompareTo(new Team("Cluj", 11)));
            Assert.True(secondTeam.CompareTo(new Team("Alba", 6)));
        }
    }
}
