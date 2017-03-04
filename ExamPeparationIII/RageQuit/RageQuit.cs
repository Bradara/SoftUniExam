using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RageQuit
{
    class RageQuit
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var rx = new Regex(@"(\D+)(\d+)");
            var result = new StringBuilder();
            var matches = rx.Matches(input);

            foreach (Match match in matches)
            {
                var text = match.Groups[1].ToString();
                var count = int.Parse(match.Groups[2].ToString());
                for (int i = 0; i < count; i++)
                {
                    result.Append(text.ToUpper());
                }
            }

            Console.WriteLine("Unique symbols used: {0}",result.ToString().Distinct().Count());
            

            Console.WriteLine(result);
        }
    }
}
