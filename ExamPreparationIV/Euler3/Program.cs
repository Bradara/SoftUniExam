using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler3
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = 600851475143;
            var primeArr = 1;

            for (int i = 2; i < Math.Sqrt(num); i++)
            {
                if (CheckPrime(i))
                {
                    if (num%i == 0)
                    {
                        primeArr = i;
                    }
                }
                
            }

            Console.WriteLine(primeArr);
        }

        private static bool CheckPrime(int i)
        {
            bool isPrime = true;

            for (int j = 2; j < Math.Sqrt(i); j++)
            {
                if (i%j == 0)
                {
                    isPrime = false;
                }
            }

            return isPrime;
        }
    }
}
