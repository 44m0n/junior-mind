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

        [Fact]
        public void GetRankingWithMultipleTeams()
        {
            Team[] teams = new Team[] { new Team("Cluj", 10), new Team("Alba", 20), new Team("Bucuresti", 5) };
            Team[] desiredRanking = new Team[] { new Team("Alba", 20), new Team("Cluj", 10), new Team("Bucuresti", 5) };
            Ranking rank = new Ranking(teams);
            Team[] resultedRanking = rank.GetRanking();
            Assert.Equal(resultedRanking.ToString(), desiredRanking.ToString());
        }

        [Fact]
        public void GetRankingWithOneTeam()
        {
            Team[] teams = new Team[] { new Team("Cluj", 10)};
            Team[] desiredRanking = new Team[] {new Team("Cluj", 10)};
            Ranking rank = new Ranking(teams);
            Team[] resultedRanking = rank.GetRanking();
            Assert.Equal(resultedRanking.ToString(), desiredRanking.ToString());
        }

        [Fact]
        public void GetPosition()
        {
            Team[] teams = new Team[] { new Team("Alba", 20), new Team("Cluj", 10), new Team("Bucuresti", 5) };
            Team desiredTeam = new Team("Cluj", 10);
            Ranking rank = new Ranking(teams);
            Team resultedTeam = rank.GetPosition(2);
            Assert.Equal(resultedTeam.ToString(), desiredTeam.ToString());
        }

        [Fact]
        public void GetPositionUsingNameWhenTheTeamExists()
        {
            Team[] teams = new Team[] { new Team("Alba", 20), new Team("Cluj", 10), new Team("Bucuresti", 5) };
            Ranking rank = new Ranking(teams);
            int desiredPosition = 2;
            Assert.Equal(rank.GetPositionUsingName("Cluj"), desiredPosition);
        }
    }
}