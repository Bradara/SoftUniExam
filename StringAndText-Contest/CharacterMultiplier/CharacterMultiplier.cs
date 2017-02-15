namespace CharacterMultiplier
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var str1 = input[0];
            var str2 = input[1];

            var len = str1.Length <= str2.Length ? str1.Length : str2.Length;
            var longStr = str1.Length <= str2.Length ? str2 : str1;
            var sum = 0;

            for (int i = 0; i < len; i++)
            {
                sum += str1[i] * str2[i];
            }
            for (int i = len; i < longStr.Length; i++)
            {
                sum += longStr[i];
            }


            Console.WriteLine(sum);
        }
    }
}
