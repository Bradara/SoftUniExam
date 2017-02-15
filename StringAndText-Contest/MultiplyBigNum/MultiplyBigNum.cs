namespace MultiplyBigNum
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var str1 = Console.ReadLine().TrimStart('0');
            var num2 = int.Parse(Console.ReadLine());


            var inMind = 0;
            var result = string.Empty;

            for (int i = 0; i < str1.Length; i++)
            {
                var index = str1.Length - 1 - i;
                var num = int.Parse(str1[index].ToString());
                var product = num * num2 + inMind;
                result = product % 10 + result;
                inMind = product / 10;
            }
            if (inMind>0)
            {
                result = inMind + result;
            }

            if (num2 == 0) result = 0.ToString();
            Console.WriteLine(result);

        }


    }
}
