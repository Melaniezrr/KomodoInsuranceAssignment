using System;
using System.Collections.Generic;
namespace KomodoInsurance
{
    // ==== Menu Design ===
    // Manage Teams
    // - Developer Team Directory - List Teams of Developers
    // - Add Developer Team
    // - Update Developer Team by Adding Developer to the team
    // - Update Developer Team by Removing Developer from the team
    // - Go back to main menu
    // Manage Developers
    // - Developer Directory - List Developers
    // - Add Developer
    // - Go back to main menu
    // Exit
    public class ProgramUI
    {
        DeveloperRepo devRepo = new DeveloperRepo();
        DeveloperTeamRepo devTeamRepo = new DeveloperTeamRepo();
        public void Run()
        {
            Console.WriteLine("Welcome to Dev Team Manager");
            MainMenu();
        }
        private void MainMenu()
        {
            Console.WriteLine("Select an Option: \n" +
                "1. Manage Developer Teams\n" +
                "2. Manage Developers \n" +
                "3. Exit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    DevTeamMenu();
                    break;
                case "2":
                    DeveloperMenu();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please make a different selection.");
                    MainMenu();
                    break;
            }
        }
        private void DevTeamMenu()
        {
            Console.WriteLine("You are in the Dev Team Menu.");
            Console.WriteLine("Select an Option: \n" +
               "1. List Developer Teams \n" +
               "2. Get Developer Team by ID (View Developers on Team) \n" +
               "3. Add Developer Team \n" +
               "4. Add Developer to Dev Team \n" +
               "5. Remove Developer from Dev Team \n" +
               "6. Back to Main Menu");
            string input = Console.ReadLine();
            string id;
            string teamId;
            string teamName;
            List<Developer> newDevelopers;
            DeveloperTeam updatedDevTeam;
            switch (input)
            {
                case "1":
                    List<DeveloperTeam> devTeams = devTeamRepo.GetDeveloperTeamList();
                    if (devTeams.Count > 0)
                    {
                        foreach (DeveloperTeam devTeamIndex in devTeams)
                        {
                            Console.WriteLine(devTeamIndex.TeamId + " | " + devTeamIndex.TeamName);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Dev Teams yet. Please create one.");
                    }
                    DevTeamMenu();
                    break;
                case "2":
                    // Show Developers on a Team
                    Console.WriteLine("Enter a Developer Team ID: ");
                    teamId = Console.ReadLine();
                    DeveloperTeam devTeamSingle = devTeamRepo.GetDeveloperTeam(teamId);
                    if (devTeamSingle.Developers.Count > 0)
                    {
                        foreach (Developer devIndex in devTeamSingle.Developers)
                        {
                            Console.WriteLine(devIndex.Id + " | " + devIndex.Name);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Devs on this team yet.");
                    }
                    DevTeamMenu();
                    break;
                case "3":
                    // Add Developer Team
                    Console.WriteLine("Enter a Developer Team ID: ");
                    teamId = Console.ReadLine();
                    Console.WriteLine("Enter a Developer Team Name: ");
                    teamName = Console.ReadLine();
                    List<Developer> list = new List<Developer>();
                    DeveloperTeam newDevTeam = new DeveloperTeam(teamId, teamName, list);
                    devTeamRepo.AddDeveloperTeam(newDevTeam);
                    DevTeamMenu();
                    break;
                case "4":
                    // Add Developer to Team
                    Console.WriteLine("Which Dev Team would you like to add to?");
                    teamId = Console.ReadLine();
                    Console.WriteLine("Which developer would you like to add to the team? (By ID)");
                    id = Console.ReadLine();
                    Developer dev = devRepo.GetDeveloper(id);
                    DeveloperTeam devTeam = devTeamRepo.GetDeveloperTeam(teamId);
                    teamName = devTeam.TeamName;
                    newDevelopers = devTeam.Developers;
                    newDevelopers.Add(dev);
                    updatedDevTeam = new DeveloperTeam(teamId, teamName, newDevelopers);
                    devTeamRepo.UpdateDeveloperTeam(teamId, updatedDevTeam);
                    DevTeamMenu();
                    break;
                case "5":
                    // Remove Developer from team
                    Console.WriteLine("Which Dev Team would you like to add to?");
                    teamId = Console.ReadLine();
                    Console.WriteLine("Which developer would you like to remove from the team? (By ID)");
                    id = Console.ReadLine();
                    Developer devUpdate = devRepo.GetDeveloper(id);
                    DeveloperTeam devTeamUpdate = devTeamRepo.GetDeveloperTeam(teamId);
                    teamName = devTeamUpdate.TeamName;
                    newDevelopers = devTeamUpdate.Developers;
                    newDevelopers.Remove(devUpdate);
                    updatedDevTeam = new DeveloperTeam(teamId, teamName, newDevelopers);
                    devTeamRepo.UpdateDeveloperTeam(teamId, updatedDevTeam);
                    DevTeamMenu();
                    break;
                case "6":
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Please make a different selection.");
                    DevTeamMenu();
                    break;
            }
        }
        private void DeveloperMenu()
        {
            Console.WriteLine("You are in the Developer Menu.");
            Console.WriteLine("Select an Option: \n" +
               "1. List Developers \n" +
               "2. Add Developer\n" +
               "3. Update Developer \n" +
               "4. Remove Developer \n" +
               "5. Go back to Main Menu");
            string input = Console.ReadLine();
            string id;
            string name;
            string hasPluralsightAccess;
            bool wasSuccessful;
            switch (input)
            {
                case "1":
                    // List Developers
                    List<Developer> devs = devRepo.GetDeveloperList();
                    Console.WriteLine(devs.Count);
                    if (devs.Count > 0)
                    {
                        foreach (Developer dev in devs)
                        {
                            Console.WriteLine(dev.Id + " | " + dev.Name);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Devs yet. Please create one.");
                    }
                    DeveloperMenu();
                    break;
                case "2":
                    // Add Developer
                    Console.WriteLine("Enter a Developer ID: ");
                    id = Console.ReadLine();
                    Console.WriteLine("Enter a Developer Name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Has Pluralsight Access? (Enter yes or no)");
                    hasPluralsightAccess = Console.ReadLine();
                    Developer newDev = new Developer(id, name, hasPluralsightAccess);
                    devRepo.AddDeveloper(newDev);
                    DeveloperMenu();
                    break;
                case "3":
                    // Update Developer
                    // Get Developer ID
                    Console.WriteLine("Enter a Developer ID to Update: ");
                    id = Console.ReadLine();
                    Console.WriteLine("Enter a new name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Has Pluralsight Access? (Enter yes or no)");
                    hasPluralsightAccess = Console.ReadLine();
                    Developer updatedDev = new Developer(id, name, hasPluralsightAccess);
                    wasSuccessful = devRepo.UpdateDeveloper(id, updatedDev);
                    Console.WriteLine("Your update was successful? :" + wasSuccessful);
                    DeveloperMenu();
                    break;
                case "4":
                    // Remove Developer
                    Console.WriteLine("Remove a developer by ID: ");
                    id = Console.ReadLine();
                    wasSuccessful = devRepo.RemoveDeveloperFromList(id);
                    Console.WriteLine("Your removal was successful? :" + wasSuccessful);
                    DeveloperMenu();
                    break;
                case "5":
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Please make a different selection.");
                    DeveloperMenu();
                    break;
            }
        }
    }
}