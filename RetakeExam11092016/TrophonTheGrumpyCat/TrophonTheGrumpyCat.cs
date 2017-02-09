namespace TrophonTheGrumpyCat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TrophonTheGrumpyCat
    {
        static List<long> left = new List<long>();
        static List<long> right = new List<long>();
        static int[] priceRating;

        static void Main()
        {
            priceRating = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int entryPoint = int.Parse(Console.ReadLine());
            var typeOfItems = Console.ReadLine();
            var rating = Console.ReadLine();

            for (int i = 0; i < entryPoint; i++)
            {
                left.Add(priceRating[i]);
            }

            for (int i = entryPoint+1; i < priceRating.Length; i++)
            {
                right.Add(priceRating[i]);
            }

            var entry = priceRating[entryPoint];
            if (typeOfItems.Equals("cheap"))
            {
                left = left.Where(n => n < entry).ToList();
                right = right.Where(n => n < entry).ToList();
            }
            else
            {
                left = left.Where(n => n >= entry).ToList();
                right = right.Where(n => n >= entry).ToList();
            }

            if (rating.Equals("positive"))
            {
                left = left.Where(n => n >= 0).ToList();
                right = right.Where(n => n >= 0).ToList();
            }

            if (rating.Equals("negative"))
            {
                left = left.Where(n => n < 0).ToList();
                right = right.Where(n => n < 0).ToList();
            }

            if (left.Sum()>=right.Sum())
            {
                Console.WriteLine("Left - {0}", left.Sum());
            }
            else
            {
                Console.WriteLine("Right - {0}", right.Sum());
            }
        }
    }
}
