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
            Game game = new Game("Cluj", "Alba", 2, 0);
            Team[] newPoints = game.CalculatePoints();
            Team[] desiredResult = new[] { new Team("Cluj", 3), new Team("Alba", 0) };
            Assert.Equal(newPoints.ToString(), desiredResult.ToString());
        }
    }
}
