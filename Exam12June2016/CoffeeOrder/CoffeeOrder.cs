using System.Globalization;

namespace CoffeeOrder
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var totalPrice = 0m;

            for (int i = 0; i < n; i++)
            {
                var pricePerCapsules = decimal.Parse(Console.ReadLine());
                var orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                var capsilesCount = int.Parse(Console.ReadLine());
                var price = DateTime.DaysInMonth(orderDate.Year, orderDate.Month) * (long)capsilesCount * pricePerCapsules;
                Console.WriteLine($"The price for the coffee is: ${price:f2}");
                totalPrice += price;
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
