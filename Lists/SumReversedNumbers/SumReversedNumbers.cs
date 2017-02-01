namespace SumReversedNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SumReversedNumbers
    {
        static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var sum = 0;

            foreach (var item in input)
            {
                var num = item;
                int len = item.ToString().Length;
                var temp = 0;
                for (int i = 0; i < len; i++)
                {
                    temp = temp*10 + num % 10;
                    num /= 10;
                }
                sum += temp;
            }

            Console.WriteLine(sum);
        }
    }
}
