namespace BlurFilter
{
    using System;
    using System.Linq;

    internal class BlurFilter
    {
        private static void Main()
        {
            int blurAm = int.Parse(Console.ReadLine());
            string[] rowCol = Console.ReadLine().Split();
            int row = int.Parse(rowCol[0]);
            int col = int.Parse(rowCol[1]);
            long[,] picture = new long[row, col];
            FillThePicture(picture);
            int[] target = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Blur(picture, target, blurAm);
            PrintPicture(picture);
        }

        private static void PrintPicture(long[,] picture)
        {
            for (int i = 0; i < picture.GetLength(0); i++)
            {
                for (int j = 0; j < picture.GetLength(1); j++)
                {
                    Console.Write(picture[i,j]);
                    if (j<picture.GetLength(1)-1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void Blur(long[,] picture, int[] target, int blurAm)
        {
            int startRow = target[0] - 1 <= 0 ? 0 : target[0] - 1;
            int endRow = target[0] + 1 >= picture.GetLength(0)-1 ? picture.GetLength(0)-1 : target[0] + 1;
            int startCol = target[1] - 1 <= 0 ? 0 : target[1] - 1;
            int endCol = target[1] + 1 >= picture.GetLength(1) - 1 ? picture.GetLength(1) - 1 : target[1] + 1;

            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCol; j <= endCol; j++)
                {
                    picture[i, j] += blurAm;
                }

            }


        }

        private static void FillThePicture(long[,] picture)
        {
            for (int i = 0; i < picture.GetLength(0); i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < picture.GetLength(1); j++)
                {
                    picture[i, j] = input[j];
                }
            }
        }
    }
}