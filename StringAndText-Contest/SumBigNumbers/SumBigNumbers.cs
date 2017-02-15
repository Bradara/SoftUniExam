namespace SumBigNumbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var str1 = Console.ReadLine().TrimStart('0');
            var str2 = Console.ReadLine().TrimStart('0');

            var len = str1.Length <= str2.Length ? str1.Length : str2.Length;
            var str1Len = str1.Length;
            var str2Len = str2.Length;
            var longStr = str1.Length < str2.Length ? str2 : str1;
            var result = string.Empty;
            var inMind = 0;

            for (int i = 0; i <len; i++)
            {
                var num1 = int.Parse(str1[str1Len-1-i].ToString());
                var num2 = int.Parse(str2[str2Len-1-i].ToString());
                var sum = inMind + num1 + num2;
                result = sum%10 + result;
                inMind = sum / 10;
            }
            for (int i = longStr.Length - len - 1; i >= 0; i--)
            {
                var num1 = int.Parse(longStr[i].ToString());
                var sum = inMind + num1;
                result = sum%10 + result;
                inMind = sum / 10;
            }
            if (inMind>0)
            {
                result = inMind + result;
            }

            Console.WriteLine(result);
        }
    }
}
