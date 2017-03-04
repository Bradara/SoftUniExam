using System;

namespace SweetDessert
{
    class SweetDessert
    {
        static void Main()
        {
            var cash = decimal.Parse(Console.ReadLine());
            var guests = int.Parse(Console.ReadLine());
            var bananaPrice = decimal.Parse(Console.ReadLine());
            var eggPrice = decimal.Parse(Console.ReadLine());
            var berryPricePerKilo= decimal.Parse(Console.ReadLine());

            var pricePerPortion = bananaPrice * 2 + eggPrice * 4 + 0.2m * berryPricePerKilo;
            var moneyNeeded = guests % 6 == 0 ? pricePerPortion * (guests / 6) : pricePerPortion * (guests / 6 + 1);

            if (moneyNeeded<=cash)
            {
                Console.WriteLine("Ivancho has enough money - it would cost {0:f2}lv.", moneyNeeded);
            }
            else
            {
                Console.WriteLine("Ivancho will have to withdraw money - he will need {0:f2}lv more.", moneyNeeded-cash);
            }

        }
    }
}
