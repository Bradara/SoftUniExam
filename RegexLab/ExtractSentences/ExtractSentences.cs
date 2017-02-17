namespace ExtractSentences
{
    using System;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            var key = Console.ReadLine();

            var input = Console.ReadLine();

            var rx = new Regex(@"([^A-z]|^)+?"+key+@"([^A-z]|$)+");

            var splitInput = input.Split(new[] {'.', '?', '!'}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var sentence in splitInput)
            {
                if (rx.IsMatch(sentence))
                {
                    Console.WriteLine(sentence.Trim());
                }
            }

        }
    }
}
