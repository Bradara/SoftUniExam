using System;
using System.Text;
using System.Text.RegularExpressions;

namespace UseYourChain
{
    public class StartUp
    {
        private static string result = string.Empty;

        public static void Main()
        {

            var input = Console.ReadLine();
            //var inputSplit = input.Split(new[] { "</p>" }, StringSplitOptions.RemoveEmptyEntries);

            //for (var i = 0; i < inputSplit.Length - 1; i++)
            //{
            //    var lineSplit = inputSplit[i].Split(new[] { "<p>" }, StringSplitOptions.RemoveEmptyEntries);
            //    Proceed(lineSplit.Length > 1 ? lineSplit[1] : lineSplit[0]);
            //}

            var rx = new Regex(@"(?<=<p>).*?(?=<\/p>)", RegexOptions.Singleline);

            var matches = rx.Matches(input);

            foreach (Match match in matches)
            {
                Proceed(match.ToString());
            }

            Console.WriteLine(result);
        }

        private static void Proceed(string match)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < match.Length; i++)
            {
                var charNum = (int)match[i];
                if (charNum >= 97 && charNum <= 109)
                {
                    sb.Append((char)(match[i] + 13));
                    continue;
                }
                if (charNum > 109 && charNum < 123)
                {
                    sb.Append((char)(match[i] - 13));
                    continue;
                }
                if (charNum >= 48 && charNum <= 57)
                {
                    sb.Append(match[i]);
                    continue;
                }
                sb.Append(" ");
            }

            while (sb.ToString().IndexOf("  ") >= 0)
            {
                sb.Replace("  ", " ");
            }

            result += sb.ToString();
        }
    }
}
