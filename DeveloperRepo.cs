using System;
using System.Collections.Generic;
using System.Text;

namespace KomodoInsurance
{
    public class DeveloperRepo
    {
        private List<Developer> _listOfDevelopers = new List<Developer>();
        // Create CRUD Methods
        // create
        public void AddDeveloper(Developer developer)
        {
            _listOfDevelopers.Add(developer);
        }
        // read (list or get one)
        public List<Developer> GetDeveloperList()
        {
            return _listOfDevelopers;
        }
        public Developer GetDeveloper(string id)
        {
            Developer dev = GetDeveloperById(id);
            return dev;
        }
        // update
        public bool UpdateDeveloper(string id, Developer newDeveloper)
        {
            Developer oldDeveloper = GetDeveloperById(id);
            if (oldDeveloper != null)
            {
                oldDeveloper.Id = newDeveloper.Id;
                oldDeveloper.Name = newDeveloper.Name;
                oldDeveloper.HasPluralsightAccess = newDeveloper.HasPluralsightAccess;
                return true;
            }
            return false;
        }
        // delete
        public bool RemoveDeveloperFromList(string id)
        {
            Developer developer = GetDeveloperById(id);
            if (developer == null)
            {
                return false;
            }
            int initialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(developer);
            return initialCount > _listOfDevelopers.Count;
        }
        // helper
        private Developer GetDeveloperById(string id)
        {
            foreach (Developer developer in _listOfDevelopers)
            {
                if (developer.Id == id)
                {
                    return developer;
                }
                return null;
            }
            return null;
        }
    }
}