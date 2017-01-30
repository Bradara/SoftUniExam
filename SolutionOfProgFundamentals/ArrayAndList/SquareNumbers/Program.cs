using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> inputInt = ConvertToInt(input).ToList();
            List<int> squareNum = new List<int>();
            for (int i = 0; i < inputInt.Count; i++)
            {
                if (Math.Sqrt(inputInt[i])== (int)Math.Sqrt(inputInt[i]))
                {
                    squareNum.Add(inputInt[i]);
                }
            }
            squareNum.Sort((a, b) => b.CompareTo(a));
            Console.WriteLine(string.Join(" ", squareNum));
        }
        private static int[] ConvertToInt(string v)
        {
            char[] separator = { ' ' };
            string[] inputStr = v.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int[] result = new int[inputStr.Length];
            for (int i = 0; i < inputStr.Length; i++)
            {
                result[i] = int.Parse(inputStr[i]);
            }
            return result;
        }
    }
}
