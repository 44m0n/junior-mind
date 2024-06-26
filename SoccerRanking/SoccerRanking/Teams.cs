﻿using System;

namespace TeamsConstructor
{
    public class Team
    {
        readonly string team;
        private int points;

        public Team(string team, int points)
        {
            this.team = team;
            this.points = points;
        }

        public bool CompareTo(Team anotherTeam, bool comparePoints = false)
        {
            if (comparePoints)
            {
                return anotherTeam != null && anotherTeam.points >= points;
            }

            return anotherTeam != null && anotherTeam.team == team;
        }

        public void UpdatePoints(int n)
        {
            points += n;
        }
    }
}