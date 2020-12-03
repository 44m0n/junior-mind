using System;
using Xunit;
using RankingConstructor;
using TeamsConstructor;

namespace SoccerRankingFacts
{
    public class RankingFacts
    {
        [Fact]
        public void GetPositionTeamExists()
        {
            Team[] teams = new Team[] { new Team("Alba", 20), new Team("Cluj", 20), new Team("Bucuresti", 5) };
            Ranking rank = new Ranking(teams);
            Team teamToFind = new Team("Cluj", 20);
            int desiredPosition = 2;
            Assert.Equal(rank.GetPosition(teamToFind), desiredPosition);
        }

        [Fact]
        public void GetPositionWhenTheTeamDosentExits()
        {
            Team[] teams = new Team[] { new Team("Alba", 20), new Team("Cluj", 10), new Team("Bucuresti", 5) };
            Ranking rank = new Ranking(teams);
            Team teamToFind = new Team("Timisoara", 20);
            int desiredPosition = -1;
            Assert.Equal(rank.GetPosition(teamToFind), desiredPosition);
        }

        [Fact]
        public void AddTeamToRankingFact()
        {
            Team[] teams = new Team[] { new Team("Alba", 20), new Team("Cluj", 10), new Team("Bucuresti", 5) };
            Team teamToAdd = new Team("Timisoara", 30);
            Ranking rank = new Ranking(teams);
            rank.AddTeamToRanking(teamToAdd);
            Assert.Equal(1, rank.GetPosition(teamToAdd));
        }
    }
}