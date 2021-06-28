using System;
using System.Collections.Generic;

namespace KomodoInsurance
{
    // POCO
    public class DeveloperTeam
    {
        public string TeamName { get; set; }
        public string TeamId { get; set; }
        public List<Developer> Developers { get; set; }
        public DeveloperTeam(string TeamIdValue, string TeamNameValue, List<Developer> developers)
        {
            TeamName = TeamNameValue;
            TeamId = TeamIdValue;
            Developers = developers;
        }
    }
}