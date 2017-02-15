namespace MergeFiles
{
    using System;
    using System.IO;

    class MergeFiles
    {
        static void Main()
        {
            var input1 = "input1.txt";
            var input2 = "input2.txt";

            var input1Lines = File.ReadAllLines(input1);
            var input2Lines = File.ReadAllLines(input2);

            var outPut = string.Empty;

            for (int i = 0; i < input1Lines.Length; i++)
            {
                outPut += input1Lines[i] + Environment.NewLine;
                outPut += input2Lines[i] + Environment.NewLine;
            }

            File.WriteAllText("result.txt", outPut);
        }
    }
}
