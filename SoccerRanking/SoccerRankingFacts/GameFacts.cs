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
            Game game = new Game(firstTeam, 1, 2);
            Team secondTeam = new Team("Alba", 5);
            game.Update(secondTeam);
            Assert.True(game.SecondTeam.CompareTo(new Team("Alba", 8), true));
        }

        [Fact]
        public void UpdatePointsWithADraw()
        {
            Team firstTeam = new Team("Cluj", 10);
            Game game = new Game(firstTeam, 1, 1);
            Team secondTeam = new Team("Alba", 5);
            game.Update(secondTeam);
            Assert.True(game.SecondTeam.CompareTo(new Team("Alba", 6), true));
        }
    }
}
