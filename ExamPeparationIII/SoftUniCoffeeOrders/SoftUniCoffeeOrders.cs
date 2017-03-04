using System;
using System.Globalization;

namespace SoftUniCoffeeOrders
{
    class SoftUniCoffeeOrders
    {
        static void Main()
        {
            var numberOfOrder = int.Parse(Console.ReadLine());
            var orderTotal = 0m;

            for (int i = 0; i < numberOfOrder; i++)
            {
                var priceOfCaps = decimal.Parse(Console.ReadLine());
                var date = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                var capsCount = int.Parse(Console.ReadLine());
                var order = priceOfCaps * DateTime.DaysInMonth(date.Year, date.Month) * capsCount;
                Console.WriteLine("The price for the coffee is: ${0:f2}", order);
                orderTotal += order;
            }

            Console.WriteLine("Total: ${0:f2}", orderTotal);
        }
    }
}
