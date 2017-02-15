namespace MostFrequentNumber
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var inFile = "input.txt";

            var data = File.ReadAllLines(inFile);
            var result = string.Empty;

            for (int i = 0; i < data.Length; i++)
            {
                var maxCount = 0;
                var currentCount = 0;
                var maxNum = 0;
                var input = data[i].Split().Select(int.Parse).ToArray();
                for (int j = 0; j < input.Length-1; j++)
                {
                    currentCount = 1;
                    var currentNum = input[j];
                    for (int k = j+1; k < input.Length; k++)
                    {
                        if (currentNum == input[k])
                        {
                            currentCount++;
                        }
                    }

                    if (currentCount>maxCount)
                    {
                        maxNum = currentNum;
                        maxCount = currentCount;
                    }

                }

                result += maxNum + Environment.NewLine;
            }

            File.WriteAllText("../../result.txt", result);
        }
    }
}
