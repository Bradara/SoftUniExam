using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<double> inputInt = ConvertToDouble(input).ToList<double>();
            bool isFoundEqual = true;
            while (isFoundEqual)
            {
                isFoundEqual = false;
                for (int i = 0; i < inputInt.Count - 1; i++)
                {
                    if (inputInt[i] == inputInt[i + 1])
                    {
                        var temp = inputInt[i] + inputInt[i + 1];
                        inputInt.RemoveAt(i);
                        inputInt.RemoveAt(i);
                        inputInt.Insert(i, temp);
                        isFoundEqual = true;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", inputInt));

        }
        private static double[] ConvertToDouble(string v)
        {
            char[] separator = { ' ' };
            string[] inputStr = v.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            double[] result = new double[inputStr.Length];
            for (int i = 0; i < inputStr.Length; i++)
            {
                result[i] = double.Parse(inputStr[i]);
            }
            return result;
        }
    }
}
