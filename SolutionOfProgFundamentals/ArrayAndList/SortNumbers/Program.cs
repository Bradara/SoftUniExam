using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<decimal> inputInt = ConvertToInt(input).ToList();
            inputInt.Sort();
            Console.WriteLine(string.Join(" <= ", inputInt));
        }
        private static decimal[] ConvertToInt(string v)
        {
            char[] separator = { ' ' };
            string[] inputStr = v.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            decimal[] result = new decimal[inputStr.Length];
            for (int i = 0; i < inputStr.Length; i++)
            {
                result[i] = decimal.Parse(inputStr[i]);
            }
            return result;
        }
    }
}
