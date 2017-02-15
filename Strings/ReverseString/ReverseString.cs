namespace ReverseString
{
    using System;

    class ReverseString
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var output = string.Empty;

            for (int i = input.Length -1 ; i >= 0; i--)
            {
                output += input[i];
            }

            Console.WriteLine(output);

        }
    }
}
