namespace IndexOfLetters
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class IndexOfLetters
    {
        private static void Main()
        {
            var inFile = "input.txt";

            var data = File.ReadAllLines(inFile);
            var result = new List<Dictionary<char, int>>();

            for (int i = 0; i < data.Length; i++)
            {
                var input = data[i];
                var lettersByFreq = new Dictionary<char, int>();
                for (int k = 0; k < input.Length; k++)
                {
                    
                        lettersByFreq[input[k]] = input[k] - 'a';
              
                }

                result.Add(lettersByFreq);
            }

            var fileResult = "../../result.txt";
            foreach (var item in result)
            {
                foreach (var c in item)
                {
                    var output = $"{c.Key} -> {c.Value}" + Environment.NewLine;
                    File.AppendAllText(fileResult, output);
                }
                File.AppendAllText(fileResult, (new string('-', 10) + Environment.NewLine));
                
            }
        }
    }
}
