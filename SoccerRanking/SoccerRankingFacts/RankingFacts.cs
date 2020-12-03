using System;
using Xunit;
using RankingConstructor;
using TeamsConstructor;

namespace SoccerRankingFacts
{
    public class RankingFacts
    {

        [Fact]
        public void GetRankingWithTwoTeams()
        {
            Team[] teams = new Team[] { new Team("Cluj", 10), new Team("Alba", 20) };
            Team[] desiredRanking = new Team[] { new Team("Alba", 20), new Team("Cluj", 10) };
            Ranking rank = new Ranking(teams);
            Team[] resultedRanking = rank.GetRanking();
            Assert.Equal(resultedRanking.ToString(), desiredRanking.ToString());
        }
    }
}