using System;
using Xunit;
using RankingConstructor;
using TeamsConstructor;
using GameConstructor;

namespace SoccerRankingFacts
{
    public class RankingFacts
    {
        [Fact]
        public void GetPositionTeamExists()
        {
            var first = new Team("Alba", 20);
            var second = new Team("Cluj", 20);
            var third = new Team("Bucuresti", 5);
            Team[] teams = new Team[] {first, second, third };
            Ranking rank = new Ranking(teams);
            int desiredPosition = 2;
            Assert.Equal(rank.GetPosition(second), desiredPosition);
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
            rank.AddTeam(teamToAdd);
            Assert.Equal(1, rank.GetPosition(teamToAdd));
        }

        [Fact]
        public void UpdateFact()
        {
            var first = new Team("Alba", 15);
            var second = new Team("Cluj", 20);
            var third = new Team("Bucuresti", 5);
            Team[] teams = new Team[] { first, second, third };
            Game game = new Game(first, 1, 2);
            game.Update(second);
            Ranking rank = new Ranking(teams);
            rank.Update(game);
            Assert.True(teams[0].CompareTo(second));
            Assert.True(teams[0].CompareTo(new Team("Cluj", 23), true));
        }

        [Fact]
        public void GetTeamByPosition()
        {
            var first = new Team("Alba", 20);
            var second = new Team("Cluj", 20);
            var third = new Team("Bucuresti", 5);
            Team[] teams = new Team[] { first, second, third };
            Ranking rank = new Ranking(teams);
            int desiredPosition = 2;
            Assert.Equal(second, rank.GetTeamByPosition(desiredPosition));
        }
    }
}