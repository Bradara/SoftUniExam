namespace PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PopulationCounter
    {
        static Dictionary<string, Dictionary<string, long>> statistics = new Dictionary<string, Dictionary<string, long>>();

        static void Main()
        {
            var input = Console.ReadLine();

            while (!input.Equals("report"))
            {
                var inSplit = input.Split('|');
                var country = inSplit[1];
                var city = inSplit[0];
                var population =long.Parse(inSplit[2]);

                ProceedData(country, city, population);

                input = Console.ReadLine();
            }

            Print();
        }

        private static void Print()
        {
            foreach (var country in statistics.OrderByDescending(n => n.Value.Values.Sum()))
            {
                Console.WriteLine("{0} (total population: {1})", country.Key, country.Value.Values.Sum());
                foreach (var city in country.Value.OrderByDescending(n => n.Value))
                {
                    Console.WriteLine("=>{0}: {1}", city.Key, city.Value);
                }
            }
        }

        private static void ProceedData(string country, string city, long population)
        {
            if (statistics.ContainsKey(country))
            {
                if (statistics[country].ContainsKey(city))
                {
                    statistics[country][city] += population;
                }
                else
                {
                  //  statistics[country] = new Dictionary<string, long>();
                    statistics[country][city] = population;
                }                
            }
            else
            {
                statistics[country] = new Dictionary<string, long>();
                statistics[country][city] = population;
            }
        }
    }
}
