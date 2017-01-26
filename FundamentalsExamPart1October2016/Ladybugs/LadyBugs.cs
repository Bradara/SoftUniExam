namespace Ladybugs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class LadyBugs
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var field = new int[size];
            var ladybugsPos = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (var pos in ladybugsPos)
            {
                if (pos >= 0 && pos < field.Length)
                {
                    field[pos] = 1;
                }
            }
            var command = Console.ReadLine();

            while (!command.Equals("end"))
            {
                var input = command.Split();
                var index = int.Parse(input[0]);
                var direction = input[1];
                var length = int.Parse(input[2]);
                bool firstFly = true;

                if (field[index] == 1)
                    Fly(field, index, direction, length, firstFly);

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", field));
        }

        private static void Fly(int[] field, int index, string direction, int length, bool firstFly)
        {
            if(firstFly)
            field[index] = 0;

            if (direction.Equals("right"))
            {
                var newIndex = index + length;
                if (newIndex < field.Length && newIndex >= 0)
                {
                    if (field[newIndex] == 1)
                    {
                        Fly(field, newIndex, direction, 1, false);
                    }
                    else
                    {
                        field[newIndex] = 1;
                    }
                }
                else
                    return;
            }
            else if (direction.Equals("left"))
            {
                var newIndex = index - length;
                if (newIndex < field.Length && newIndex >= 0)
                {
                    if (field[newIndex] == 1)
                    {
                        Fly(field, newIndex, direction, 1, false);
                    }
                    else
                    {
                        field[newIndex] = 1;
                    }
                }
                else
                    return;
            }
        }
    }
}
