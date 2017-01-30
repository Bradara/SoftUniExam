using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOfWeek
{
    class DayOfWeek
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
            int dayNum = int.Parse(Console.ReadLine());
            if (dayNum<=7&&dayNum>0)
            {
                Console.WriteLine($"{daysOfWeek[dayNum-1]}");
            }
            else
            {
                Console.WriteLine("Invalid Day!");
            }
        }
    }
}
