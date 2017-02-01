namespace SumAdjacentEqualNumbers
{
    using System;
    using System.Linq;

    class SumAdjacentEqualNumbers
    {
        static void Main()
        {
            var input = Console.ReadLine().Split().Select(decimal.Parse).ToList();

            for (int i = 1; i < input.Count; i++)
            {
                if (input[i]==input[i-1])
                {
                    input[i - 1] = input[i] + input[i - 1];
                    input.RemoveAt(i);
                    i = 0;
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
