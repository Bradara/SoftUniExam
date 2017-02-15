using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStopWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var stw = new Stopwatch();

            var result = string.Empty;

            stw = Stopwatch.StartNew();
            for (int i = 0; i < 50000; i++)
            {
                result += i.ToString();
            }
            stw.Stop();

            Console.WriteLine("Time elapsed with +: {0}", stw.Elapsed);

            result = null;
            stw = Stopwatch.StartNew();

            for (int i = 0; i < 50000; i++)
            {
              result = string.Concat(result, i.ToString());
            }

            stw.Start();
            Console.WriteLine("Time elapsed with ConCat: {0}", stw.Elapsed);

            var sb = new StringBuilder();

            stw = new Stopwatch();
            result = string.Empty;

            for (int i = 0; i < 50000; i++)
            {
                sb.Append(i);
            }
            stw.Stop();

            Console.WriteLine("Time elapsed with stringBuilder: {0}", stw.Elapsed);
        }
    }
}
