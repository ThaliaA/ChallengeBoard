using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFuchsia.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<string> CompletedChallenges { get; set; }
        public int Score { get; set; }
    }
}