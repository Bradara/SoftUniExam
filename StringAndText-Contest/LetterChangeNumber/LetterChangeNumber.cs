namespace LetterChangeNumber
{
    using System;

    public class StartUp
    {
        public static decimal TotalSum;

        public static void Main()
        {
            var input = Console.ReadLine()?.Split(new []{' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                Proceed(input[i]);
            }

            Console.WriteLine("{0:f2}",TotalSum);
        }

        private static void Proceed(string s)
        {
            var result = 0m;
            var len = s.Length;
            var firstChar = s[0];
            var lastChar = s[len - 1];
            var num = decimal.Parse(s.Substring(1, len - 2));

            if (char.IsUpper(firstChar))
            {
                result = num / (firstChar - 64);
            }
            if (char.IsLower(firstChar))
            {
                result = num * (firstChar - 96);
            }
            if (char.IsUpper(lastChar))
            {
                result -=lastChar - 64;
            }
            if (char.IsLower(lastChar))
            {
                result +=lastChar - 96;
            }

            TotalSum += result;
        }
    }
}
