namespace TrifonsQuest
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static long health = 0;
        private static int row = 0;
        private static int col = 0;
        private static char[,] matrix = new char[row, col];
        private static int turns = 0;
        
        public static void Main()
        {
            health = long.Parse(Console.ReadLine());
            FillTheMatrix();
            Play();

            Print();

        }

        private static void Print()
        {
            Console.WriteLine("Quest completed!");
            Console.WriteLine($"Health: {health}");
            Console.WriteLine($"Turns: {turns}");
        }

        private static void Play()
        {
            for (int i = 0; i < col; i++)
            {
                if (i%2==0)
                {
                    for (int j = 0; j < row; j++)
                    {
                        var action = matrix[j, i];
                        ProceedTurn(action, j, i);
                    }
                }
                else
                {
                    for (int j = row-1; j >=0; j--)
                    {
                        var action = matrix[j, i];
                        ProceedTurn(action, j, i);
                    }
                }
            }
        }

        private static void ProceedTurn(char action, int j, int i)
        {
            if (action.Equals('F'))
            {
                health -= turns / 2;
                turns++;
            }
            if (action.Equals('H'))
            {
                health += turns / 3;
                turns++;
            }
            if (action.Equals('T'))
            {
                turns += 3;
            }
            if (action.Equals('E'))
            {
                turns++;
            }
            if (health<=0)
            {
                Console.WriteLine($"Died at: [{j}, {i}]");
                Environment.Exit(0);
            }
        }

        private static void FillTheMatrix()
        {
            var matrixData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            row = matrixData[0];
            col = matrixData[1];
            matrix = new char[row, col];
            for (int i = 0; i < row; i++)
            {
                var input = Console.ReadLine();
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
        }
    }
}
