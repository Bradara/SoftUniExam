using System;
using System.Linq;
using System.Numerics;

namespace SinoTheWalker
{
    class SinoTheWalker
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(':').Select(int.Parse).ToArray();
            var hours = input[0];
            var minutes = input[1];
            var seconds = input[2];
            var start = new DateTime(2016, 1, 1, hours, minutes, seconds);

            BigInteger steps = long.Parse(Console.ReadLine());
            BigInteger secPerSteps = long.Parse(Console.ReadLine());
            var result = (steps * secPerSteps)%(3600*24);

            int h = (int)result / 3600;
            int m = ((int)result - h*3600)/60;
            int s = (int)result - h * 3600 - m * 60;

            TimeSpan sp = new TimeSpan(h, m, s);

            var arriveTime = start.Add(sp);

            Console.WriteLine("Time Arrival: {0:00}:{1:00}:{2:00}", arriveTime.Hour, arriveTime.Minute, arriveTime.Second);
        }
    }
}
