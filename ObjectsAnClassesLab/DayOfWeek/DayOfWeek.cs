namespace DayOfWeek
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class DayOfWeek
    {
        static void Main()
        {
            var input = Console.ReadLine().Split('-').Select(int.Parse).ToArray();

            var day = input[0];
            var month = input[1];
            var year = input[2];

            DateTime date = new DateTime(year, month, day);

            Console.WriteLine(date.DayOfWeek);
        }
    }
}
