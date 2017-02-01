namespace MaxSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class MaxSequence
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int count = 1;
            int index = 0;
            int maxCount = 0;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i]==input[i-1])
                {
                    count++;
                }
                else if (count>maxCount)
                {
                    index = i-1;
                    maxCount = count;
                    count = 1;
                }
                else
                {
                    count = 1;
                }
                if (i==input.Length-1&&input[i]==input[i-1]&&count>maxCount)
                {
                    index = i;
                    maxCount = count;
                }             
            }

            Console.WriteLine(string.Join(" ", input.Skip(index-maxCount+1).Take(maxCount)));
        }
    }
}
