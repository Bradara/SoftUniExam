using System;
using System.Linq;
using System.Numerics;

namespace My_Console_Template1
{

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();
            var baseN = input[0];
            var numBase10 = input[1];
            var result = string.Empty;
            var isZero = numBase10 == 0 ? true : false;

            while (numBase10 > 0)
            {
                result = numBase10 % baseN + result;
                numBase10 /= baseN;
            }

            if (isZero)
            {
                result = 0.ToString();
            }
            Console.WriteLine(result);
        }
    }
}
