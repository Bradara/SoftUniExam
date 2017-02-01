


namespace SplitbyWordCasig
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SplitbyWordCasig
    {
        static void Main()
        {    //// , ; : . ! ( ) " ' \ / [ ] space
            var text = Console.ReadLine().Split(new char[] {'\'','"', ';', '(', ')', '\\', '/', '[', ']', ':', ',', ' ', '.', '!' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var upperCase = new List<string>();
            var lowerCase = new List<string>();
            var mixedCase = new List<string>();

            foreach (var word in text)
            {
                var countUp = 0;
                var countLow = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    if (char.IsUpper(word[i]))
                    {
                        countUp++;
                    }
                    else if (char.IsLower(word[i]))
                    {
                        countLow++;
                    }
                }

                if (countLow == word.Length)
                {
                    lowerCase.Add(word);
                }
                else if (countUp == word.Length)
                {
                    upperCase.Add(word);
                }
                else
                {
                    mixedCase.Add(word);
                }
            }

            Console.WriteLine("Lower-case: {0}", string.Join(", ", lowerCase));
            Console.WriteLine("Mixed-case: {0}", string.Join(", ", mixedCase));
            Console.WriteLine("Upper-case: {0}", string.Join(", ", upperCase));
        }
    }
}
