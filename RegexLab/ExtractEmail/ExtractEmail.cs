namespace ExtractEmail
{
    using System;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var rx = new Regex(@"(?<=\s)[A-Za-z]+[\w-_\.]+@[\w]+?[\.-]+[\w-\.]*[\w]+[\.-]*?[\w-]+\b");

            var matches = rx.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
