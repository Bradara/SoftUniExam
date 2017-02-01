namespace ArrayManipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class ArrayManipulator
    {
        private static List<int> arrOfInt = new List<int>();

        private static void Main()
        {
            arrOfInt = Console.ReadLine().Split().Select(int.Parse).ToList();
            var input = Console.ReadLine();

            while (!input.Equals("print"))
            {
                var splitIn = input.Split();
                if (splitIn.Length == 1)
                {
                    SumPairs();
                }
                else if (splitIn.Length == 2)
                {
                    Proceed2Element(splitIn);
                }
                else if (splitIn.Length > 2)
                {
                    Add(splitIn);
                }

                input = Console.ReadLine();
            }

            Print();
        }

        private static void Print()
        {
            Console.Write("[");
            Console.Write(string.Join(", ", arrOfInt));
            Console.WriteLine("]");
        }

        //private static void Proceed(string[] splitIn)
        //{
        //    if (splitIn.Length==1)
        //    {
        //        SumPairs(splitIn);
        //    }
        //    else if (splitIn.Length == 2)
        //    {
        //        Proceed2Element(splitIn);
        //    }
        //    else if (splitIn.Length>2)
        //    {
        //        Add(splitIn);
        //    }
        //}

        private static void Add(string[] splitIn)
        {
            var command = splitIn[0];
            var index = int.Parse(splitIn[1]);
            int[] element =new int[splitIn.Length - 2];
            for (int i = 2; i < splitIn.Length; i++)
            {
                element[i - 2] = int.Parse(splitIn[i]);
            }
            arrOfInt.InsertRange(index, element);
        }

        private static void Proceed2Element(string[] splitIn)
        {
            var command = splitIn[0];
            var index = int.Parse(splitIn[1]);
            if (command == "shift")
            {
                Shift(index);
            }
            if (command == "remove")
            {
                arrOfInt.RemoveAt(index);
            }
            if (command == "contains")
            {
                Console.WriteLine(arrOfInt.IndexOf(index));
            }
        }

        private static void Shift(int index)
        {
            var len = arrOfInt.Count;
            List<int> result = new List<int>();
            for (int i = index%len; i < len; i++)
            {
                result.Add(arrOfInt[i]);
            }
            for (int i = 0; i < index%len; i++)
            {
                result.Add(arrOfInt[i]);
            }
            arrOfInt = result;
        }

        private static void SumPairs()
        {
            List<int> result = new List<int>();

            for (int i = 0; i < arrOfInt.Count; i++)
            {
                if (i % 2 == 1)
                {
                    result.Add(arrOfInt[i] + arrOfInt[i - 1]);
                }
                if (i == arrOfInt.Count - 1 && i % 2 == 0)
                {
                    result.Add(arrOfInt[i]);
                }
            }
            arrOfInt = result;
        }
    }
}