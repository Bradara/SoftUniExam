namespace TargetMultiplier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ArrayModifier
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split().Select(long.Parse).ToArray();

            var command = Console.ReadLine();

            while (!command.Equals("end"))
            {
                ProcessCommand(arr, command);

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", arr));
        }

        private static void ProcessCommand(long[] arr, string command)
        {
            var input = command.Split();
            if (input[0] == "decrease")
            {
                Decrease(arr);
            }
            if (input[0] == "swap")
            {
                SwapArr(arr, input[1], input[2]);
            }
            if (input[0] == "multiply")
            {
                MultiplyArr(arr, input[1], input[2]);
            }
        }

        private static void Decrease(long[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] -= 1;
            }
        }

        private static void MultiplyArr(long[] arr, string v1, string v2)
        {
            var index1 = int.Parse(v1);
            var index2 = int.Parse(v2);

            arr[index1] *= arr[index2];
        }

        private static void SwapArr(long[] arr, string v1, string v2)
        {
            var index1 = int.Parse(v1);
            var index2 = int.Parse(v2);

            var temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }
    }
}
