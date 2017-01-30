using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareCharArray
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input1 = Console.ReadLine().Split().Select(char.Parse).ToArray();
            char[] input2 = Console.ReadLine().Split().Select(char.Parse).ToArray();
            bool isDifferent = false;
            for (int i = 0; i < Math.Min(input1.Length, input2.Length); i++)
            {
                if (input1[i]<input2[i])
                {
                    Console.WriteLine(string.Join("", input1));
                    Console.WriteLine(string.Join("", input2));
                    isDifferent = true;
                    break;
                }
                else if (input1[i] > input2[i])
                {
                    Console.WriteLine(string.Join("", input2));
                    isDifferent = true;
                    Console.WriteLine(string.Join("", input1));
                    break;
                }
               
            }
            if (!isDifferent)
            {
                if (input1.Length<=input2.Length)
                {
                    Console.WriteLine(string.Join("", input1));
                    Console.WriteLine(string.Join("", input2));
                }
                else
                {
                    Console.WriteLine(string.Join("", input2));
                    Console.WriteLine(string.Join("", input1));
                }
            }
        }
    }
}
