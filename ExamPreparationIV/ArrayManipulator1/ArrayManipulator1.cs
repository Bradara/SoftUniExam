using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;

namespace ArrayManipulator1
{
    class ArrayManipulator1
    {
        static void Main()
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToList();

            var command = Console.ReadLine();

            while (command != "end")
            {
                var commandSplit = command.Split();
                var operand = commandSplit[0];

                switch (operand)
                {
                    case "exchange":
                        var index = int.Parse(commandSplit[1]);
                        if (IsValid(array, index))
                        {
                            Exchange(array, index);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "max":
                        var oddOrEvenMax = commandSplit[1];
                        if (array.Any(n => n % 2 == 0) && oddOrEvenMax == "even")
                        {
                            var maxEven = array.Where(n => n % 2 == 0).Max();
                            Console.WriteLine(array.LastIndexOf(maxEven));
                        }
                        else if (array.Any(n => n % 2 != 0) && oddOrEvenMax == "odd")
                        {
                            var maxOdd = array.Where(n => n % 2 != 0).Max();
                            Console.WriteLine(array.LastIndexOf(maxOdd));
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                        break;
                    case "min":
                        var oddOrEvenMin = commandSplit[1];
                        if (array.Any(n => n % 2 == 0) && oddOrEvenMin == "even")
                        {
                            var min = array.Where(n => n % 2 == 0).Min();
                            Console.WriteLine(array.LastIndexOf(min));
                        }
                        else if (array.Any(n => n % 2 != 0) && oddOrEvenMin == "odd")
                        {
                            var min = array.Where(n => n % 2 != 0).Min();
                            Console.WriteLine(array.LastIndexOf(min));
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                        break;
                    case "first":
                        var count = int.Parse(commandSplit[1]);
                        var oddOrEvenFirst = commandSplit[2];
                        if (oddOrEvenFirst =="odd"&&count>0&&count<=array.Count)
                        {
                            Console.WriteLine("[{0}]", string.Join(", ", array.Where(n => n % 2 != 0).Take(count)));
                        }
                        else if (oddOrEvenFirst == "even" && count > 0 && count <= array.Count)
                        {
                            Console.WriteLine("[{0}]", string.Join(", ", array.Where(n => n % 2 == 0).Take(count)));
                        }
                        else
                        {
                            Console.WriteLine("Invalid count");
                        }
                        break;
                    case "last":
                        count = int.Parse(commandSplit[1]);
                        var oddOrEvenLast = commandSplit[2];
                        if (oddOrEvenLast == "odd" && count > 0 && count <= array.Count)
                        {
                            Console.WriteLine("[{0}]", string.Join(", ", array.Where(n => n % 2 != 0).Reverse().Take(count).Reverse()));
                        }
                        else if (oddOrEvenLast == "even" && count > 0 && count <= array.Count)
                        {
                            Console.WriteLine("[{0}]", string.Join(", ", array.Where(n => n % 2 == 0).Reverse().Take(count).Reverse()));
                        }
                        else
                        {
                            Console.WriteLine("Invalid count");
                        }
                         break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("[{0}]", string.Join(", ", array));
           
        }

        private static void Exchange(List<int> array, int index)
        {
            var result = array.Skip(index+1).ToList();

            array.RemoveRange(index+1,array.Count-index-1);
            array.InsertRange(0, result);
        }

        private static bool IsValid(List<int> array, int index)
        {
            if (index >= 0 && index < array.Count)
            {
                return true;
            }

            return false;
        }
    }
}
