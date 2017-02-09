namespace SrabskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class SrabskoUnleashed
    {
        static Dictionary<string, Dictionary<string, int>> schedule = new Dictionary<string, Dictionary<string, int>>();
        static string pattern = @"(.+?) @(.+?) (\d+?) (\d+?)\b";

        static void Main()
        {
            var input = string.Empty;

            while (!(input = Console.ReadLine()).Equals("End"))
            {
                if (!Regex.IsMatch(input, pattern))
                {
                    continue;
                }
                var firstSplit = input.Split('@');
                var name = firstSplit[0].Trim();

                var secondSplit = firstSplit[1].Split();
                if (secondSplit.Length > 2 && secondSplit.Length < 6)
                {
                    int ticketCount;
                    bool isCountValid = int.TryParse(secondSplit[secondSplit.Length - 1], out ticketCount);
                    int ticketPrice;
                    bool isPriceValid = int.TryParse(secondSplit[secondSplit.Length - 2], out ticketPrice);
                    int income = 0;
                    bool isIncomeValid = false;
                    if (isCountValid && isPriceValid)
                    {
                        income = ticketCount * ticketPrice;
                        isIncomeValid = true;
                    }

                    var city = string.Join(" ", secondSplit.Take(secondSplit.Length - 2).ToArray());
                    if (isIncomeValid)
                    {
                        Add(name, city, income);
                    }
                }
            }

            Print();
        }

        private static void Print()
        {
            foreach (var city in schedule)
            {
                Console.WriteLine("{0}", city.Key);

                foreach (var singer in city.Value.OrderByDescending(n => n.Value))
                {
                    Console.WriteLine("#  {0} -> {1}", singer.Key, singer.Value);
                }
            }
        }

        private static void Add(string name, string city, int income)
        {
            if (schedule.ContainsKey(city))
            {
                if (schedule[city].ContainsKey(name))
                {
                    schedule[city][name] += income;
                }
                else
                {
                    schedule[city][name] = income;
                }
            }
            else
            {
                schedule[city] = new Dictionary<string, int>();
                schedule[city][name] = income;
            }
        }
    }
}
