using System.Linq;
using System;

namespace Numbers
{


    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var average = input.Average();

            var result = input.Where(n => n > average).OrderByDescending(n => n).Take(5).ToArray();

            Console.WriteLine(result.Length > 0 ? string.Join(" ", result) : "No");
        }
    }
}
