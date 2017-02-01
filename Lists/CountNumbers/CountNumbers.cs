namespace CountNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CountNumbers
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToList();

            input.Sort();

            int count = 1;
            int num = input[0];

            if (input.Count == 1)
            {
                Console.WriteLine("{0} -> {1}", num, count);
            }

            for (int i = 1; i < input.Count; i++)
            {
                if (input[i] == num)
                {
                    count++;
                }
                else
                {
                    Console.WriteLine("{0} -> {1}", num, count);
                    count = 1;
                    num = input[i];
                }
                if (i==input.Count-1)
                {
                    Console.WriteLine("{0} -> {1}", num, count);
                }
            }
        }
    }
}
