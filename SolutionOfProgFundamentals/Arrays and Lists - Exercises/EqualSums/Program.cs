using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool isFound = false;
            for (int i = 0; i < input.Length; i++)
            {            
                int sumLeft = input.Where((n, index) => index < i).ToArray().Sum();
                int sumRight = input.Where((n, index) => index > i).ToArray().Sum();
                if (sumLeft == sumRight)
                {
                    Console.WriteLine(i);
                    isFound = true;
                }
            }
            if (!isFound)
            {
                Console.WriteLine("no");
            }
        }
    }
}
