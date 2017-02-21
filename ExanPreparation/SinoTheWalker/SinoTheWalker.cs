namespace SinoTheWalker
{
    using System;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            var timeLeave = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            long steps = int.Parse(Console.ReadLine());
            long secPerSteps = int.Parse(Console.ReadLine());
            var timeTravel = steps * secPerSteps % (24 * 60 * 60);

            var timeArive = timeLeave.AddSeconds(timeTravel);

            Console.WriteLine($"Time Arrival: {timeArive.Hour:00}:{timeArive.Minute:00}:{timeArive.Second:00}");
        }
    }
}
