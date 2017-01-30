using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseanArrayofIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            var arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            var arrReversed = new int[length];
            for (int i = 0; i < length; i++)
            {
                arrReversed[length -1 - i] = arr[i];
            }
            Console.WriteLine(string.Join(" ", arrReversed));
        }
    }
}
