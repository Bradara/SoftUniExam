namespace RandomizeWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RandomizeWords
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string[] input = Console.ReadLine().Split(' ');
            int len = input.Length;

            for (int i = 0; i < len; i++)
            {
                int randomIndex = rnd.Next(len);
                var temp = input[randomIndex];
                input[randomIndex] = input[i];
                input[i] = temp;
            }

            foreach (var item in input)
            {
                Console.WriteLine(item);
            }
        }
    }
}
