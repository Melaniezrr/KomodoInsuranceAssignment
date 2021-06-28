using System;
using System.Collections.Generic;

namespace KomodoInsurance
{
    public class DeveloperTeamRepo
    {
        private List<DeveloperTeam> _listOfDeveloperTeams = new List<DeveloperTeam>();
        // Create CRUD Methods
        // create
        public void AddDeveloperTeam(DeveloperTeam developerTeam)
        {
            _listOfDeveloperTeams.Add(developerTeam);
        }
        // read (list or get one)
        public List<DeveloperTeam> GetDeveloperTeamList()
        {
            return _listOfDeveloperTeams;
        }
        public DeveloperTeam GetDeveloperTeam(string id)
        {
            DeveloperTeam devTeam = GetDeveloperTeamByTeamId(id);
            return devTeam;
        }
        // update
        public bool UpdateDeveloperTeam(string teamId, DeveloperTeam newDeveloperTeam)
        {
            DeveloperTeam oldDeveloperTeam = GetDeveloperTeamByTeamId(teamId);
            if (oldDeveloperTeam != null)
            {
                oldDeveloperTeam.TeamId = newDeveloperTeam.TeamId;
                oldDeveloperTeam.TeamName = newDeveloperTeam.TeamName;
                oldDeveloperTeam.Developers = newDeveloperTeam.Developers;
                return true;
            }
            return false;
        }
        // delete
        public bool RemoveDeveloperTeamFromList(string teamId)
        {
            DeveloperTeam developerTeam = GetDeveloperTeamByTeamId(teamId);
            if (developerTeam == null)
            {
                return false;
            }
            int initialCount = _listOfDeveloperTeams.Count;
            _listOfDeveloperTeams.Remove(developerTeam);
            return initialCount > _listOfDeveloperTeams.Count;
        }
        // helper
        private DeveloperTeam GetDeveloperTeamByTeamId(string teamId)
        {
            foreach (DeveloperTeam developerTeam in _listOfDeveloperTeams)
            {
                if (developerTeam.TeamId == teamId)
                {
                    return developerTeam;
                }
                return null;
            }
            return null;
        }
    }
}