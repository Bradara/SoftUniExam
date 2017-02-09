namespace Largest3Num
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Largest3Num
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(string.Join(" ", input.OrderByDescending(n => n).Take(3)));
        }
    }
}
