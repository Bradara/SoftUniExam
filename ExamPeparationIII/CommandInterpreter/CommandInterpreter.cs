using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CommandInterpreter
{
    class CommandInterpreter
    {
        static void Main()
        {
            var array = Console.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var commandInput = Console.ReadLine();

            while (commandInput != "end")
            {
                var commandSplit = commandInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = commandSplit[0];
                var start = 0;
                var count = 0;
                if (command == "reverse")
                {
                    start = int.Parse(commandSplit[2]);
                    count = int.Parse(commandSplit[4]);

                    if (isValid(array, start, count))
                    {
                        array.Reverse(start, count);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                if (command == "sort")
                {
                    start = int.Parse(commandSplit[2]);
                    count = int.Parse(commandSplit[4]);

                    if (isValid(array, start, count))
                    {
                        array.Sort(start, count, StringComparer.InvariantCulture);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                if (command == "rollLeft")
                {
                    count = int.Parse(commandSplit[1]) % array.Count;
                    if (isValid(array, start, count))
                    {
                        RollLeft(array, count);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                if (command == "rollRight")
                {
                    count = int.Parse(commandSplit[1]) % array.Count;
                    if (isValid(array, start, count))
                    {
                        RollRight(array, count);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }

                commandInput = Console.ReadLine();
            }

            Console.WriteLine("[{0}]", string.Join(", ", array));
        }

        private static void RollRight(List<string> array, int count)
        {
            var result = array.Skip(array.Count - count).ToList();
            result.AddRange(array.Take(array.Count-count));
            array.RemoveRange(0, array.Count);
            array.AddRange(result);
        }

        private static void RollLeft(List<string> array, int count)
        {
            var result = array.Skip(count).ToList();
            result.AddRange(array.Take(count));
            array.RemoveRange(0, array.Count);
            array.AddRange(result);
        }

        private static bool isValid(List<string> array, int start, int count)
        {
            if (start >= 0 && start < array.Count && count >= 0 && start + count <= array.Count)
            {
                return true;
            }

            return false;
        }
    }
}
