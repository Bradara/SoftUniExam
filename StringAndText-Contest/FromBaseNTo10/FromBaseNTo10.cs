using System;
using System.Linq;
using System.Numerics;

namespace FromBaseNTo10
{

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var baseN = int.Parse(input[0]);
            var numBaseN = input[1];
            BigInteger result = 0;

            for (int i = 0; i < numBaseN.Length; i++)
            {
                var num = int.Parse(numBaseN[numBaseN.Length - 1 - i].ToString());
                result += Power(baseN, i) * num;
            }

            Console.WriteLine(result);
        }

        private static BigInteger Power(int baseN, int i)
        {
            BigInteger result = 1;
            for (int j = 0; j < i; j++)
            {
                result *= baseN;
            }

            return result;
        }
    }
}
