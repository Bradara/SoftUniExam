namespace FootballStandings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        private static Dictionary<string, int> scoreTable = new Dictionary<string, int>();
        private static Dictionary<string, long> goalsTable = new Dictionary<string, long>();

        public static void Main()
        {
            TakeInput();
            Print();
        }

        private static void Print()
        {
            Console.WriteLine("League standings:");
            var count = 1;
            foreach (var country in scoreTable.OrderByDescending(c => c.Value).ThenBy(c => c.Key))
            {
                Console.WriteLine($"{count}. {country.Key} {country.Value}");
                count++;
            }

            Console.WriteLine("Top 3 scored goals:");
            foreach (var country in goalsTable.OrderByDescending(c => c.Value).ThenBy(c => c.Key).Take(3))
            {
                Console.WriteLine($"- {country.Key} -> {country.Value}");
            }
        }

        private static void TakeInput()
        {
            var key = GetKey(Console.ReadLine());
            var pattern = @".*(?<=" + key + @")([A-z]+)(?=" + key + @").*?(?<=" + key + @")([A-z]+)(?=" + key + @").*(?<= )(\d+:\d+)$";


            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("final"))
                {
                    break;
                }
                var matches = Regex.Split(input, pattern, RegexOptions.Multiline);
                if (matches.Length < 5) continue;
                var countryHost = string.Join("", matches[1].Reverse()).ToUpper();
                var countryGuest = string.Join("", matches[2].Reverse()).ToUpper();
                var goals = matches[3].Split(':');
                var hostGoals = int.Parse(goals[0]);
                var guestGoals = int.Parse(goals[1]);
                AddPoint(countryHost, countryGuest, hostGoals, guestGoals);
            }
        }

        private static string GetKey(string input)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                sb.Append("[");
                sb.Append(input[i]);
                sb.Append("]");
            }

            return sb.ToString();
        }

        private static void AddPoint(string countryHost, string countryGuest, int hostGoals, int guestGoals)
        {
            if (hostGoals > guestGoals)
            {
                if (!scoreTable.ContainsKey(countryHost))
                {
                    scoreTable[countryHost] = 3;
                    goalsTable[countryHost] = hostGoals;
                }
                else
                {
                    scoreTable[countryHost] += 3;
                    goalsTable[countryHost] += hostGoals;
                }
                if (!scoreTable.ContainsKey(countryGuest))
                {
                    scoreTable[countryGuest] = 0;
                    goalsTable[countryGuest] = guestGoals;
                }
                else
                {
                    goalsTable[countryGuest] += guestGoals;
                }
            }
            if (hostGoals < guestGoals)
            {
                if (!scoreTable.ContainsKey(countryHost))
                {
                    scoreTable[countryHost] = 0;
                    goalsTable[countryHost] = hostGoals;
                }
                else
                {
                    scoreTable[countryHost] += 0;
                    goalsTable[countryHost] += hostGoals;
                }

                if (!scoreTable.ContainsKey(countryGuest))
                {
                    scoreTable[countryGuest] = 3;
                    goalsTable[countryGuest] = guestGoals;
                }
                else
                {
                    scoreTable[countryGuest] += 3;
                    goalsTable[countryGuest] += guestGoals;
                }
            }
            if (hostGoals == guestGoals)
            {
                if (!scoreTable.ContainsKey(countryHost))
                {
                    scoreTable[countryHost] = 1;
                    goalsTable[countryHost] = hostGoals;
                }
                else
                {
                    scoreTable[countryHost] += 1;
                    goalsTable[countryHost] += hostGoals;
                }

                if (!scoreTable.ContainsKey(countryGuest))
                {
                    scoreTable[countryGuest] = 1;
                    goalsTable[countryGuest] = guestGoals;
                }
                else
                {
                    scoreTable[countryGuest] += 1;
                    goalsTable[countryGuest] += guestGoals;
                }
            }
        }
    }
}
