using System;

namespace UniCodeCharacters
{

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                result += $"\\u{((int)input[i]).ToString("X4").ToLower()}";
            }

            Console.WriteLine(result);
        }
    }
}
