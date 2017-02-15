namespace MagicExchangeableWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var str1 = input[0];
            var str2 = input[1];

            var len = str1.Length <= str2.Length ? str1.Length : str2.Length;
            var longStr = str1.Length < str2.Length ? str2 : str1;
            var isExchangeable = true;
            var chars = new Dictionary<char, char>();

            for (int i = 0; i < len; i++)
            {
                if (chars.ContainsKey(str1[i])&&chars.ContainsValue(str2[i]))
                {
                    if (chars[str1[i]] == str2[i]) continue;
                    isExchangeable = false;
                    break;
                }
                if (chars.ContainsKey(str1[i])&&!chars.ContainsValue(str2[i]))
                {
                    isExchangeable = false;
                    break;
                }
                if (chars.ContainsValue(str2[i])&&!chars.ContainsKey(str1[i]))
                {
                    isExchangeable = false;
                    break;
                }
                chars[str1[i]] = str2[i];
            }

            var mappedChar = longStr.Substring(0, len);
            for (int i = len; i < longStr.Length; i++)
            {
                if (!mappedChar.Contains(longStr[i]))
                {
                    isExchangeable = false;
                    break;
                }
            }

            Console.WriteLine(isExchangeable?"true":"false");

        }
    }
}
