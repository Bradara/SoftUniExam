using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveNegativesandReverse
{
    class RemoveNegativesandReverse
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> positiveNum = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]>=0)
                {
                    positiveNum.Add(input[i]);
                }
            }

            if (positiveNum.Count==0)
            {
                Console.WriteLine("empty");
            }
            else
            Console.WriteLine(string.Join(" ", positiveNum.Select(n => n).Reverse()));
        }
    }
}
