using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendList
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('|');
            List<int[]> listInt = new List<int[]>();
            for (int i = input.Length-1; i >= 0; i--)
            {
                listInt.Add(ConvertToInt(input[i]));
            }
            PrintList(listInt);
        }

        private static void PrintList(List<int[]> listInt)
        {
            for (int i = 0; i < listInt.Count; i++)
            {
                Console.Write(string.Join(" ", listInt[i]));
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        private static int[] ConvertToInt(string v)
        {
            char[] separator = { ' ' };
            string[] inputStr = v.Split(separator,StringSplitOptions.RemoveEmptyEntries);
            int[] result = new int[inputStr.Length];
            for (int i = 0; i < inputStr.Length; i++)
            {
                result[i] = int.Parse(inputStr[i]);
            }
            return result;
        }
    }
}
