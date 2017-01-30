namespace SweetDessert
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SweetDessert
    {
        static void Main()
        {
            var cash = decimal.Parse(Console.ReadLine());
            var guests = int.Parse(Console.ReadLine());
            var priceBanana = decimal.Parse(Console.ReadLine());
            var priceEgg = decimal.Parse(Console.ReadLine());
            var priceBerry = decimal.Parse(Console.ReadLine());

            var price1Portion = priceBanana * 2 + priceEgg * 4 + priceBerry * 0.2m;
            var portion = 0;

            if (guests%6==0)
            {
                portion = guests / 6;
            }
            else
            {
                portion = guests / 6 + 1;
            }

            var moneyNeed = portion * price1Portion;

            if (moneyNeed>cash)
            {
                Console.WriteLine("Ivancho will have to withdraw money - he will need {0:f2}lv more.", moneyNeed-cash);
            }
            else
            {
                Console.WriteLine("Ivancho has enough money - it would cost {0:f2}lv.", moneyNeed);
            }
        }
    }
}
