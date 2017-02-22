using System.Linq;
using System;

namespace LAdyBug
{

    class LAdyBug
    {
        static void Main()
        {
            var fieldSize = int.Parse(Console.ReadLine());
            var bugIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var field = new int[fieldSize];

            for (int i = 0; i < fieldSize; i++)
            {
                if (bugIndexes.Contains(i))
                {
                    field[i] = 1;
                }
                else
                {
                    field[i] = 0;
                }
            }

            var command = string.Empty;
            while (!(command = Console.ReadLine()).Equals("end"))
            {
                var input = command.Split();
                var index = int.Parse(input[0]);
                var direction = input[1];
                var flyLength = int.Parse(input[2]);
                if (index >= 0 && index < fieldSize && field[index] == 1)
                {
                    if (direction == "left")
                    {
                        field[index] = 0;

                        FlyLeft(field, flyLength, index);
                    }
                    if (direction == "right")
                    {
                        field[index] = 0;

                        FlyRight(field, flyLength, index);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", field));
        }

        private static void FlyRight(int[] field, int flyLength, int i)
        {
            var newPosition = i + flyLength;
            if (newPosition < field.Length)
            {
                bool isFly = true;

                while (isFly)
                {
                    if (field[newPosition] == 0)
                    {
                        field[newPosition] = 1;
                        isFly = false;
                    }
                    else
                    {
                        FlyRight(field, flyLength, newPosition);
                        return;
                    }
                }
            }
        }

        private static void FlyLeft(int[] field, int flyLength, int i)
        {
            var newPosition = i - flyLength;
            if (newPosition >= 0)
            {
                bool isFly = true;

                while (isFly)
                {
                    if (field[newPosition] == 0)
                    {
                        field[newPosition] = 1;
                        isFly = false;
                    }
                    else
                    {
                        FlyLeft(field,flyLength, newPosition);
                        return;
                    }
                }
            }
            return;
        }
    }
}
