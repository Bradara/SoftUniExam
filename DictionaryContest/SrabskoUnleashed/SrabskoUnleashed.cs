namespace SrabskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SrabskoUnleashed
    {
        static Dictionary<string, Dictionary<string, int>> schedule = new Dictionary<string, Dictionary<string, int>>();

        static void Main()
        {
            var input = Console.ReadLine();

            while (!input.Equals("End"))
            {
                var firstSpit = input.Split('@');
                var name = firstSpit[0].Trim();

                var secondSplit = firstSpit[1].Split();
                if (secondSplit.Length > 2)
                {             
                    var ticketCount = int.Parse(secondSplit[secondSplit.Length - 1]);
                    var ticketPrice = int.Parse(secondSplit[secondSplit.Length - 2]);
                    var income = ticketCount * ticketPrice;
                    var city = string.Join(" ", secondSplit.Take(secondSplit.Length - 2).ToArray());

                    Add(name, city, income);
                }
                
                input = Console.ReadLine();
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
