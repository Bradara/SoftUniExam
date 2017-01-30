using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(n => int.Parse(n)).ToArray();
            int k = input.Length / 4;

            int[] rowLeft = input.Take(k).Reverse().ToArray();
            int[] rowRight = input.Reverse().Take(k).ToArray();
            int[] firstRow = rowLeft.Concat(rowRight).ToArray();
            int[] secondRow = input.Skip(k).Take(k * 2).ToArray();
            int[] result = firstRow.Select((n, index) => n + secondRow[index]).ToArray();
            Console.WriteLine(string.Join(" ", result));

        }
    }
}
