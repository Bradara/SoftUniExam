namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class WordCount
    {
        static void Main()
        {
            var wordsFile = "words.txt";
            var inputFile = "input.txt";

            var words = File.ReadAllText(wordsFile).Split();
            var input = File.ReadAllText(inputFile);

            var result = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                result.Add(words[i], 0);
            }


        }
    }
}
