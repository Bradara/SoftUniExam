using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int incr = int.Parse(Console.ReadLine());

            byte b = 0;

            Console.WriteLine(incr%(byte.MaxValue+1));
            Console.WriteLine(incr/byte.MaxValue);
        }
    }
}
