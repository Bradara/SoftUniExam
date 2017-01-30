using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] letter = new char[26];
            for (int i=0; i < 26; i++)
            {
                letter[i] = (char)(i+97);
            }
            string input = Console.ReadLine();
            foreach (char item in input)
            {
                
                Console.WriteLine($"{item} -> {Array.IndexOf(letter, item)}");
            }
        }

        //private static object RetrurnIndex(char item, char[] letter)
        //{
        //    int result = 0;
        //    for (int i = 0; i < letter.Length; i++)
        //    {
        //        if (letter[i]==item)
        //        {
        //            result = i;
        //        }

        //    }
        //    return result;

        //}
    }
}
