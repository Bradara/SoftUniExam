using System.Collections.Generic;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace QueerMess
{
    public class StartUp
    {
        public static Dictionary<string, List<string>> Result = new Dictionary<string, List<string>>();
        //private static Regex _rx = new Regex(@"([\w\s]+)=(.+?[\s]*.+)", RegexOptions.Singleline);

        public static void Main()
        {
            var line = Console.ReadLine();


            while (!line.Equals("END"))
            {
                line = CleanLine(line);
                var input = line.Split(new[] { '&', '?' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => n.Trim()).ToArray();

                foreach (var item in input)
                {
                    Proceed(item);
                }

                Print();

                line = Console.ReadLine();
            }
        }

        private static string CleanLine(string line)
        {
            var text = line.Replace('+', ' ')
                     .Replace("%20", " ");

            while (text.IndexOf("  ", StringComparison.Ordinal) > 0)
            {
                text = text.Replace("  ", " ");
            }

            return text;
        }

        private static void Print()
        {
            foreach (var item in Result)
            {
                Console.Write("{0}=[{1}]", item.Key, string.Join(", ", item.Value));
            }

            Console.WriteLine();
            Result = new Dictionary<string, List<string>>();
        }

        private static void Proceed(string item)
        {
            if (item.Contains("="))
            {
                var text = item.Split('=');
                var key = text[0].Trim();
                var value = text[1].Trim();
                if (!Result.ContainsKey(key))
                {
                    Result[key] = new List<string> { value };
                }
                else
                {
                    if (!Result[key].Contains(value))
                    {
                        Result[key].Add(value);
                    }
                }
            }
            else
            {
                return;

            }
        }
    }
}
