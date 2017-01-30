using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestEqualSequense
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separ = { ' ', ',' };

            int[] input = Console.ReadLine().Split(separ, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(n => int.Parse(n))
                                 .ToArray();

            int count = 1, pos = 0, temp = 1;

            for (int i = 1; i < input.Length; i++)
            {

                if (input[i] >= input[i - 1]+1)
                {
                    temp++;                    
                }
                else
                {
                    if (temp > count)
                    {
                        count = temp;
                        pos = i-1;
                        temp = 1;
                    }
                    temp = 1;
                }
            }
            if (temp > count)
            {
                count = temp;
                pos = input.Length - 1;
            }
            Console.WriteLine(string.Join(" ", input.Skip(pos-count+1).Take(count)));
        }
    }
}
