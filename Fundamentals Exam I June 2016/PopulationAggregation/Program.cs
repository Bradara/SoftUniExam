

namespace PopulationAggregation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class PopulationAggregation
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var country = new Dictionary<string, long>();
            var city = new Dictionary<string, long>();

            while (!input.Equals("stop"))
            {
                TakeInput(input, country, city);

                input = Console.ReadLine();
            }

            PrintData(country, city);        
        }

        private static void PrintData(Dictionary<string, long> country, Dictionary<string, long> city)
        {
            foreach (var item in country.OrderBy(n => n.Key))
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }

            foreach (var item in city.OrderByDescending(n => n.Value).Take(3))
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }

        private static void TakeInput(string input, Dictionary<string, long> country, Dictionary<string, long> city)
        {
            if (char.IsUpper(input[0]))
            {
                var data = input.Split('\\');
                var countryName = data[0];
                var cityName = data[1];
                var population = data[2];
                PopulateData(countryName, cityName, population, city, country);
            }
            else
            {
                var data = input.Split('\\');
                var countryName = data[1];
                var cityName = data[0];
                var population = data[2];
                PopulateData(countryName, cityName, population, city, country);
            }
        }

        private static void PopulateData(string countryName, string cityName, string population, Dictionary<string, long> city, Dictionary<string, long> country)
        {
            countryName = CleanString(countryName);
            cityName = CleanString(cityName);
            if (country.ContainsKey(countryName))
            {
                country[countryName]++;
            }
            else
            {
                country[countryName] = 1;
            }
            city[cityName] = long.Parse(population);
        }

        private static string CleanString(string name)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < name.Length; i++)
            {
                if (char.IsLetter(name[i]))
                {
                    result.Append(name[i]);
                }
            }
            return result.ToString();
        }
    }
}
