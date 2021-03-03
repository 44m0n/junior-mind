using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    public class TestResult
    {
        public TestResult(string id, string familyId, int score)
        {
            Id = id;
            FamilyId = familyId;
            Score = score;
        }

        public string Id { get; set; }

        public string FamilyId { get; set; }

        public int Score { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TestResult result
                && Id == result.Id
                && FamilyId == result.FamilyId
                && Score == result.Score;
        }
    }
}
