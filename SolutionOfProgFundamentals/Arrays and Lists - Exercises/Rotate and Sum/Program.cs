using System;
using System.Linq;

namespace Rotate_and_Sum
{
    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select((n) => int.Parse(n)).ToArray();
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Join(" ", RotateandSum(input, k)));
        }

        private static int[] RotateandSum(int[] input, int k)
        {
            int length = input.Length;
            int[] result = new int[length];
            for (int j = 0; j < k; j++)
            {
                int[] temp = new int[length];
                for (int i = 0; i < length; i++)
                {
                    int indexRight = (length - 1 + i) % length;
                    temp[i] = input[indexRight];
                }
                input = temp;
                result = temp.Select((n, index) =>n + result[index]).ToArray();
            }
            return result;
        }
    }
}
