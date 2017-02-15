namespace OddLines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    class OddLines
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            string output = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (i%2 ==1)
                {
                    output += input[i] + "\r\n";
                }
            }

            File.WriteAllText("result.txt", output);
        }
    }
}
