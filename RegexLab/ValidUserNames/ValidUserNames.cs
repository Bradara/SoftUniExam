namespace ValidUserNames
{
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;


    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ', '/', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            var rx = new Regex(@"^[A-Za-z][\w]{2,24}$");

            var matches = new List<string>();

            foreach (var item in input)
            {
                if (rx.IsMatch(item))
                {
                    matches.Add(item);
                }
            }

            var maxLength = 0;
            var index = 0;

            for (int i = 0; i < matches.Count-1; i++)
            {
                var length = matches[i].Length + matches[i + 1].Length;
                if (length>maxLength)
                {
                    maxLength = length;
                    index = i;
                }
            }

            Console.WriteLine(matches[index]);
            Console.WriteLine(matches[index+1]);
        }
    }
}
