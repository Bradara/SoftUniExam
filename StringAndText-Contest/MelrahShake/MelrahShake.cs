namespace MelrahShake
{
    using System;

    public class StartUp
    {
        public static string pattern = string.Empty;
        public static string melrahString = string.Empty;

        public static void Main()
        {
            melrahString =Console.ReadLine();
            pattern = Console.ReadLine();

            CheckIt();

            Console.WriteLine(melrahString);
        }

        private static void CheckIt()
        {
            if (pattern.Length == 0)
            {
                Console.WriteLine("No shake.");
                return;
            }

            var count = 0;
            var index = melrahString.IndexOf(pattern);

            while (index >= 0)
            {
                count++;
                index = melrahString.IndexOf(pattern, index + 1);
            }

            if (count > 1)
            {
                ShakeIt();
                CheckIt();
            }
            else
            {
                Console.WriteLine("No shake.");
            }
        }

        private static void ShakeIt()
        {
            var firstIndex = melrahString.IndexOf(pattern);
            var len = pattern.Length;
            melrahString = melrahString.Remove(firstIndex, len);
            var lastIndex = melrahString.LastIndexOf(pattern);
            melrahString = melrahString.Remove(lastIndex, len);

            var patternIndex = len / 2;
            pattern = pattern.Remove(patternIndex, 1);

            Console.WriteLine("Shaked it.");
        }
    }
}
