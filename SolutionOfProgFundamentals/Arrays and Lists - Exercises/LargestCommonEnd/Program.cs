using System;
using System.Linq;

namespace LargestCommonEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split();
            string[] input2 = Console.ReadLine().Split();

            int countStart = 0;
            for (int i = 0; i < Math.Min(input1.Length, input2.Length); i++)
            {
                if (input1[i]==input2[i])
                {
                    countStart++;
                }
                else
                {
                    break;
                }
            }
            int countEnd = 0;
            input1 = input1.Reverse().ToArray();
            input2 = input2.Reverse().ToArray();
            for (int i = 0; i < Math.Min(input1.Length, input2.Length); i++)
            {
                if (input1[i] == input2[i])
                {
                    countEnd++;
                }
                else
                {
                    break;
                }
            }
            if (countEnd==0&&countStart==0)
            {
                Console.WriteLine("0");
            }
            else if (countEnd>countStart)
            {
                Console.WriteLine(countEnd);
            }
            else if (countStart>=countEnd)
            {
                Console.WriteLine(countStart);
            }
        }
    }
}
