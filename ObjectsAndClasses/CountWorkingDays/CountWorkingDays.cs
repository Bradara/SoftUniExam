namespace CountWorkingDays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Globalization;

    class CountWorkingDays
    {
        static void Main(string[] args)
        {
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            string[] holidays = new string[] {"0101", "0303", "0105", "0605", "2405", "0609", "2209", "0111", "2412", "2512", "2612"};
            int count = 0;

            for (DateTime i = startDate; i <= endDate; i = i.AddDays(1))
            {
                string dayMonth = $"{i.Day:00}" + $"{i.Month:00}";
                if (i.DayOfWeek.ToString().Equals("Saturday")|| i.DayOfWeek.ToString().Equals("Sunday")||holidays.Contains(dayMonth))
                {
                    continue;
                }

                count++;
            }

            Console.WriteLine(count);
        }
    }
}