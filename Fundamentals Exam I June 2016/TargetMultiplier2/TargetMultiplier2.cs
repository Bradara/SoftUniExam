namespace TargetMultiplier2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TargetMultiplier2
    {
        static void Main(string[] args)
        {
            var rc = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var row = rc[0];
            var col = rc[1];
            var matrix = new int[row, col];

            ReadMatrix(row, matrix);

            var target = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Multiply(matrix, target);

            Print(matrix);
        }

        private static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                    if (j < matrix.GetLength(1) - 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void Multiply(int[,] matrix, int[] target)
        {
            var startRow = target[0] - 1 <= 0 ? 0 : target[0] - 1;
            var endRow = target[0] + 1 >= matrix.GetLength(0) - 1 ? matrix.GetLength(0) - 1 : target[0] + 1;
            var startCol = target[1] - 1 <= 0 ? 0 : target[1] - 1;
            var endCol = target[1] + 1 >= matrix.GetLength(1) - 1 ? matrix.GetLength(1) - 1 : target[1] + 1;

            var targetValue = matrix[target[0], target[1]];
            var sum = 0;

            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCol; j <= endCol; j++)
                {
                    if (i == target[0] && j == target[1])
                    {
                        continue;
                    }
                    sum += matrix[i, j];
                    matrix[i, j] *= targetValue;
                }
            }

            matrix[target[0], target[1]] *= sum;
        }

        private static void ReadMatrix(int row, int[,] matrix)
        {
            for (int i = 0; i < row; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
        }
    }
}
