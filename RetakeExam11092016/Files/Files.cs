namespace Files
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Files
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            var input = new List<string>();


            for (int i = 0; i < lines; i++)
            {
                input.Add(Console.ReadLine().Trim());
            }
            var filter = Console.ReadLine().Split();
            var extension = filter[0].Trim();
            var folder = filter[2].Trim();


            var pattern =@"^" + folder + @"\\*.*[\\](.+)(" + extension + @")[\s]*;[\s]*(\d+)$";
            Regex regex = new Regex(pattern);
            bool isMatch = false;
            var result = new Dictionary<string, long>();

            for (int i = 0; i < lines; i++)
            {
                if (regex.IsMatch(input[i]))
                {
                    var splitLine = regex.Split(input[i]).Where(n => !n.Equals("")).ToArray();
                    // string[] splitLine = regex.Match(input[i]).Groups;
                    // Match m = regex.Match(input[i]);
                    var fileName = splitLine[0] + splitLine[1];
                    var fileSize = regex.Match(input[i]).Groups[3].Value;
                    result[fileName] = long.Parse(fileSize);
                    isMatch = true;
                }
            }

            if (isMatch)
            {
                foreach (var file in result.OrderByDescending(n => n.Value).ThenBy(n => n.Key))
                {
                    Console.WriteLine("{0} - {1} KB", file.Key, file.Value);
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
