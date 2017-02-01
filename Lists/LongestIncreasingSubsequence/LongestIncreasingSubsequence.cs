namespace LongestIncreasingSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LongestIncreasingSubsequence
    {
        static List<int> inputArray;
        static List<int> sequenceIndex = new List<int>();
        static List<int> result = new List<int>();
        static int index = 0;

        static void Main()
        {
            inputArray = Console.ReadLine().Split().Select(int.Parse).ToList();

            CheckForSequence();


            while (index < inputArray.Count - 1)
            {
                CheckForSequence(index);
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static void CheckForSequence(int startIndex = -1)
        {
            var lastResNum = result.Count == 0 ? int.MinValue : result.Last();
            for (int i = startIndex+1; i < inputArray.Count; i++)
            {
                if (inputArray[i] > lastResNum)
                {
                    var count = 1;
                    for (int j = i + 1; j < inputArray.Count; j++)
                    {
                        if (inputArray[i] < inputArray[j])
                        {
                            count++;
                        }
                    }

                    if (i > startIndex && result.Count > 0)
                    {
                        sequenceIndex[i] = count;
                    }
                    if (result.Count == 0)
                    {
                        sequenceIndex.Add(count);
                    }
                }
            }

            if (sequenceIndex.Max() == 0)
            {
                index = inputArray.Count - 1;
                return;
            }
            
            index = sequenceIndex.IndexOf(sequenceIndex.Max());
            var temp = inputArray[index];
            result.Add(temp);
            ZeroToIndex();
        }

        private static void ZeroToIndex()
        {
            for (int i = 0; i < inputArray.Count; i++)
            {
                sequenceIndex[i] = 0;
            }
        }
    }
}
