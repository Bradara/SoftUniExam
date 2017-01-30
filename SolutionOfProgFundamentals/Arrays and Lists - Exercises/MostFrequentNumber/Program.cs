using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Dictionary<int, int> numFrequency = new Dictionary<int, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (numFrequency.ContainsKey(input[i]))
                {
                    numFrequency[input[i]]++;
                }
                else
                {
                    numFrequency[input[i]] = 1;
                }
            }
            int max = numFrequency.Values.Max();

            //Console.WriteLine(numFrequency.Where(n => n.Value == max)
            //                                .Select(n => n.Key)
            //                                .FirstOrDefault());
            foreach (var item in numFrequency)
            {
                if (item.Value == max)
                {
                    Console.WriteLine(item.Key);
                    break;
                }
            }
        }
    }
}
