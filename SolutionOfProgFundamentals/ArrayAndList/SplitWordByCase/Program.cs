using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWordByCase
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            string[] inputStr = ConvertToStr(input);
            List<string> upperCaseList = new List<string>();
            List<string> lowerCaseList = new List<string>();
            List<string> mixedCaseList = new List<string>();
            for (int i = 0; i < inputStr.Length; i++)
            {
                string word = inputStr[i];
                int countUp = 0, countLow = 0;
                for (int k = 0; k < word.Length; k++)
                {
                    if (word[k]>=(char)65&&word[k]<= (char)90 || word[k] >= (char)1040 && word[k] <= (char)1071)
                    {
                        countUp += 1;
                    }
                    else if (word[k] >= (char)97 && word[k] <= (char)122 || word[k] >= (char)1072 && word[k] <= (char)1103)
                    {
                        countLow += 1;
                    }
                }
                if (countUp == word.Length)
                {
                    upperCaseList.Add(word);
                }
                else if (countLow==word.Length)
                {
                    lowerCaseList.Add(word);
                }
                else
                {
                    mixedCaseList.Add(word);
                }
            }
            Console.WriteLine("Lower-case: "+ string.Join(", ", lowerCaseList));
            Console.WriteLine("Mixed-case: "+ string.Join(", ", mixedCaseList));
            Console.WriteLine("Upper-case: "+ string.Join(", ", upperCaseList));

        }

        private static string[] ConvertToStr(string input)
        {
            char[] separator = { ' ', ';', ':', ',', '.', '!', '(', ')', '"', '\'','[', ']', '/','\\'};
            string[] result = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);            
            return result;
        }
    }
}
