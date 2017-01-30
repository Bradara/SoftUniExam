using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            string[] arrRev = new string[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                arrRev[arr.Length - 1 - i] = arr[i];
            }
            Console.WriteLine(string.Join(" ", arrRev));
        }
    }
}
