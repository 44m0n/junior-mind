using System;
using Xunit;
using GameConstructor;
using TeamsConstructor;

namespace SoccerRankingFacts
{
    public class GameFacts
    {
        [Fact]
        public void UpdatePointsWithOneWinner()
        {
            Team firstTeam = new Team("Cluj", 10);
            Team secondTeam = new Team("Alba", 5);
            Game game = new Game(firstTeam, secondTeam, 1, 2);
            game.Update(secondTeam);
            Assert.True(secondTeam.CompareTo(new Team("Alba", 8), true));
            Assert.True(secondTeam.CompareTo(new Team("Cluj", 10), true));
        }

        [Fact]
        public void UpdatePointsWithADraw()
        {
            Team firstTeam = new Team("Cluj", 10);
            Team secondTeam = new Team("Alba", 5);
            Game game = new Game(firstTeam, secondTeam, 1, 1);
            game.Update(secondTeam);
            Assert.True(secondTeam.CompareTo(new Team("Alba", 6), true));
            Assert.True(secondTeam.CompareTo(new Team("Cluj", 11), true));
        }
    }
}
