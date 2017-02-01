namespace SortNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SortNumbers
    {
        static void Main()
        {
            var input = Console.ReadLine().Split().Select(decimal.Parse).ToArray();

            Console.WriteLine(string.Join(" <= ", input.OrderBy(n => n)));
        }
    }
}
