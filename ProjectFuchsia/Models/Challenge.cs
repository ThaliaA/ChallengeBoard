using Raven.Imports.Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFuchsia.Models
{
    public class Challenge
    {
        public int ChallengeID { get; set; }
        public string Text { get; set; }
        public int Points { get; set; }
        public ChallengeCategory? Category { get; set; }
        [JsonIgnore]
        public IEnumerable<SelectListItem> Categories
        {
            get
            {
                var categories =
                    from l in (ChallengeCategory[])Enum.GetValues(typeof(ChallengeCategory))
                    select new { ID = (int)l, Name = l.ToString() };
                return new SelectList(categories, "ID", "Name", this.Category);
            }
        }
    }

    public enum ChallengeCategory {
        Health = 1,
        Cardio = 2,
        Training = 3,
        Miscellaneous = 4
    }
}