using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFuchsia.Entities
{
    public class Challenge
    {
        public string Text { get; set; }
        public int Points { get; set; }
        public ChallengeCategory Category { get; set; }
    }

    public enum ChallengeCategory {
        Health,
        Cardio,
        Training
    }
}