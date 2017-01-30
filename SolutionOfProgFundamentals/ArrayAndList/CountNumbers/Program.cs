using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
           List<int> inputInt = ConvertToInt(input).ToList();
            inputInt.Sort();
            List<int> countResult = new List<int>();
            List<int> numberFound = new List<int>();
            int temp = inputInt[0];
            int count = 0;
            for (int i = 0; i < inputInt.Count; i++)
            {
                var searchInt = inputInt[i];
                if (searchInt==temp)
                {
                    count++;
                }
                else
                {
                    countResult.Add(count);
                    numberFound.Add(temp);
                    count = 1;
                    temp = searchInt;
                }
                if (i==inputInt.Count-1&&searchInt==temp)
                {
                    countResult.Add(count);
                    numberFound.Add(temp);
                }
                else if (i == inputInt.Count - 1 && searchInt != temp)
                {
                    countResult.Add(1);
                    numberFound.Add(searchInt);
                }
            }
            for (int i = 0; i < countResult.Count; i++)
            {
                Console.WriteLine(numberFound[i]+ " -> "+countResult[i]);

            }

            //Dictionary<int, int> test = new Dictionary<int, int>();
            //test[3] = 55;
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
