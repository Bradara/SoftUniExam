namespace TripleSum
{
    using System;
    using System.Linq;

    class TripleSum
    {
        static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool isFound = false;

            for (int i = 0; i < input.Length-1; i++)
            {
                for (int j = i+1; j < input.Length; j++)
                {
                    if (input.Contains(input[i]+input[j]))
                    {
                        Console.WriteLine("{0} + {1} == {2}", input[i], input[j], input[i]+input[j]);
                        isFound = true;
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine("No");
            }
           
        }
    }
}
