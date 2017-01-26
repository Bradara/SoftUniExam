using System;
using System.Collections.Generic;
using System.Linq;

namespace FundamentalsExamApril2016
{
    class Nacepin
    {
        static void Main(string[] args)
        {
            decimal priceUS = Convert.ToDecimal(Console.ReadLine());
            decimal weightUS = Convert.ToDecimal(Console.ReadLine());
            decimal priceUK = Convert.ToDecimal(Console.ReadLine());
            decimal weightUK = Convert.ToDecimal(Console.ReadLine());
            decimal priceCH = Convert.ToDecimal(Console.ReadLine());
            decimal weightCH= Convert.ToDecimal(Console.ReadLine());

            Dictionary<string, decimal> priceInLv = new Dictionary<string, decimal>();
            decimal priceInUSPerKG = priceUS / weightUS / 0.58m;
            priceInLv["US"] = priceInUSPerKG;
            decimal priceInUKPerKG = priceUK / weightUK / 0.41m;
            priceInLv["UK"] = priceInUKPerKG;
            decimal priceInCHPerKG = priceCH / weightCH * 0.27m;
            priceInLv["Chinese"] = priceInCHPerKG;
            decimal minPrice = 0;
            foreach (var country in priceInLv.OrderBy(k => k.Value).Take(1))
            {
                Console.WriteLine("{0} store. {1:f2} lv/kg", country.Key, country.Value);
                minPrice = country.Value;
            }
            decimal maxPrice = priceInLv.Max(k => k.Value);
            Console.WriteLine("Difference {0:f2} lv/kg", maxPrice-minPrice);
            
        }
    }
}
