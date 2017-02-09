namespace TeamWorkProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TeamWorkProject
    {
        static List<Team> teams = new List<Team>();

        static void Main()
        {
            CreateTeam();

            AddUsers();

            Print();
        }

        private static void Print()
        {
            foreach (var team in teams.OrderByDescending(t => t.Users.Count)
                                        .ThenBy(t => t.Name).Where(t => t.Users.Count > 0))
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.Creator}");
                foreach (var user in team.Users.OrderBy(n => n))
                {
                    Console.WriteLine($"-- {user}");
                }
            }
            Console.WriteLine("Teams to disband:");

            foreach (var team in teams.Where(t => t.Users.Count == 0).OrderBy(t => t.Name))
            {
                Console.WriteLine(team.Name);
            }
        }

        private static void AddUsers()
        {
            string input;

            while (!(input = Console.ReadLine()).Equals("end of assignment"))
            {
                var inputSplit = input.Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var user = inputSplit[0];
                var teamName = inputSplit[1];

                if (!teams.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");                                  
                }
                else if (teams.Any(t => t.Users.Contains(user)) || teams.Any(t => t.Creator == user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                }
                else
                {
                    var index = teams.FindIndex(t => t.Name == teamName);
                    teams[index].Users.Add(user);
                }
            }
        }

        private static void CreateTeam()
        {
            var numberOfTeams = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfTeams; i++)
            {
                var input = Console.ReadLine().Split('-');
                var user = input[0];
                var teamName = input[1];

                if (!teams.Any(t => t.Name==teamName))
                {
                    if (!teams.Any(t => t.Creator == user))
                    {
                        var team = new Team(teamName, user);
                        teams.Add(team);
                    }
                    else
                    {
                        Console.WriteLine($"{user} cannot create another team!");
                    }
                }
                else
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }

                //if (teams.Any(t => t.Creator == user))
                //{
                //    Console.WriteLine($"{user} cannot create another team!");                    
                //}
                //else if (teams.Any(t => t.Name == teamName))
                //{
                //    Console.WriteLine($"Team {teamName} was already created!");
                //}
                //else
                //{
                //    var team = new Team(teamName, user);
                //    teams.Add(team);
                //}
            }
        }

        public class Team
        {
            public string Name { get; set; }
            public List<string> Users { get; set; }
            public string Creator { get; set; }

            public Team(string name, string user)
            {
                Name = name;
                Users = new List<string>();
                Creator = user;
                Console.WriteLine($"Team {name} has been created by {user}!");
            }
        }
    }
}
