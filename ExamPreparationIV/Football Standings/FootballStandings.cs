using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Football_Standings
{
    class FootballStandings
    {
        class  Team
        {
            public string Name { get; set; }
            public long Score { get; set; }
            public long Goals { get; set; }

            public Team(string name, int score, long goals)
            {
                Name = name;
                Score = score;
                Goals = goals;
            }
        }

       static List<Team> teams = new List<Team>();
        static void Main()
        {
            var key = Console.ReadLine();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "final")
            {
                var split = input.Split(new []{' ', '\t', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
                var nameHost = DecodeName(split[0], key);
                var nameGuest = DecodeName(split[1], key);
                var result = split[2].Trim().Split(':').Select(long.Parse).ToArray();

                CalcResult(nameGuest, nameHost, result);
            }

            PrintStanding();
            PrintTop3Goals();

        }

        private static void PrintTop3Goals()
        {
            Console.WriteLine("Top 3 scored goals:");

            foreach (var team in teams.OrderByDescending(t => t.Goals).ThenBy(t => t.Name).Take(3))
            {
                Console.WriteLine("- {0} -> {1}", team.Name, team.Goals);
            }
        }

        private static void PrintStanding()
        {
            Console.WriteLine("League standings:");

            var count = 1;

            foreach (var team in teams.OrderByDescending(t => t.Score).ThenBy(t => t.Name))
            {
                Console.WriteLine("{0}. {1} {2}", count++, team.Name, team.Score);
            }
        }

        private static void CalcResult(string nameGuest, string nameHost, long[] result)
        {
            var goalsHost = result[0];
            var goalsGuest = result[1];

            if (goalsGuest>goalsHost)
            {
                InputData(nameGuest, goalsGuest, 3);
                InputData(nameHost, goalsHost, 0);
            }
            if (goalsGuest<goalsHost)
            {
                InputData(nameGuest, goalsGuest, 0);
                InputData(nameHost, goalsHost, 3);
            }
            if (goalsGuest==goalsHost)
            {
                InputData(nameGuest, goalsGuest, 1);
                InputData(nameHost, goalsHost, 1);
            }
        }

        private static void InputData(string name, long goals, int score)
        {
            if (teams.Any(t => t.Name == name))
            {
                var team = teams.Find(t => t.Name == name);
                team.Goals += goals;
                team.Score += score;
            }
            else
            {
                var team = new Team(name, score, goals);
                teams.Add(team);
            }
        }

        private static string DecodeName(string text, string key)
        {
            var len = key.Length;
            var rx = new Regex(@"(?<=[" + key + @"]{" + len + @"})\w*(?=[" + key + @"]{" + len + @"})");
            var match = rx.Match(text);
            var name = match.Groups[0].ToString();
            name = string.Join("", name.ToUpper().Reverse());

            return name;
            //int firstIndex = text.IndexOf(key) + key.Length;
            //int secondIndex = text.LastIndexOf(key);
            //int length = secondIndex - firstIndex;
            //string name = text.Substring(firstIndex, length);
            //return string.Join("", name.ToUpper().Reverse());
        }
    }
}
