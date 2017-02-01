namespace SquareNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SquareNumbers
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var square = new List<int>();

            foreach (var num in input)
            {
                if (Math.Sqrt(num)%1 == 0)
                {
                    square.Add(num);
                }
            }

            Console.WriteLine(string.Join(" ", square.OrderByDescending(n => n)));
        }
    }
}
