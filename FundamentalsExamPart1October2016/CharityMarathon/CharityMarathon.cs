namespace CharityMarathon
{
    using System;
    class CharityMarathon
    {
        static void Main()
        {
            var days = int.Parse(Console.ReadLine());
            var runners = int.Parse(Console.ReadLine());
            var laps = int.Parse(Console.ReadLine());
            var trackLength = int.Parse(Console.ReadLine());
            var trackCapacity = int.Parse(Console.ReadLine());
            var moneyPerKM = decimal.Parse(Console.ReadLine());

            long participants = runners;

            if (trackCapacity*days<runners)
            {
                participants = days * trackCapacity;
            }

            var distanceRun = participants * laps * trackLength;

            var moneyEarned = distanceRun * moneyPerKM/1000;

            Console.WriteLine("Money raised: {0:f2}", moneyEarned);

        }
    }
}
