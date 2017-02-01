namespace BombNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BombNumbers
    {
        static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToList();
            var bomb = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var bombNum = bomb[0];
            var bombPower = bomb[1];

            while (input.Contains(bombNum))
            {
                var startRange = input.IndexOf(bombNum) - bombPower;
                var endRange = input.IndexOf(bombNum) + bombPower;
                for (int i = 0; i < input.Count; i++)
                {
                    if (i>=startRange&&i<=endRange)
                    {
                        input[i] = 0;
                    }
                }                
            }

            Console.WriteLine(input.Sum());
        }
    }
}
