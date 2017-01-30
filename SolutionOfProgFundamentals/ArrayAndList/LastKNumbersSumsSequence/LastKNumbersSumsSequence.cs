using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastKNumbersSumsSequence
{
    class LastKNumbersSumsSequence
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            long[] arr = new long[n];
            arr[0] = 1;
            for (int i = 1; i < n; i++)
            {
                arr[i] = SumOfK(arr, k, i);
            }
            Console.WriteLine(string.Join(" ", arr));
        }

        private static long SumOfK(long[] arr, int k, int pos)
        {
            long result = 0;
            if (k<1)
            {
                result = 0;
            }
            else if(k>pos)
            {
                for (int i = 0; i < pos; i++)
                {
                    result += arr[i];
                }
            }
            else
            {
                for (int i = 1; i <= k; i++)
                {
                    result += arr[pos - i];
                }
            }
            return result;
        }
    }
}
