namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class LineNumbers
    {
        static void Main()
        {
            var lines = File.ReadAllLines("input.txt");
            var output = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                output.Add($"{i + 1}. {lines[i]}");
            }

            File.WriteAllLines("result.txt", output);
        }
    }
}
