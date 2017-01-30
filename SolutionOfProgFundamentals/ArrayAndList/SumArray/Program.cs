using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split();
            int[] arr1Num = new int[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1Num[i] = int.Parse(arr1[i]);
            }
            string[] arr2 = Console.ReadLine().Split();
            int[] arr2Num = new int[arr2.Length];
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2Num[i] = int.Parse(arr2[i]);
            }
            List<int> listSum = null;
            listSum = SumArrais(arr1Num, arr2Num);
            Console.WriteLine(string.Join(" ", listSum));

        }

        private static List<int> SumArrais(int[] arr1Num, int[] arr2Num)
        {
            List<int> result = new List<int>();
            //if (arr1Num.Length > arr2Num.Length)
            int pos1, pos2;

            for (int i = 0; i < (arr1Num.Length > arr2Num.Length ? arr1Num.Length : arr2Num.Length); i++)
            {
                pos1 = i % arr1Num.Length;
                pos2 = i % arr2Num.Length;
                result.Add(arr1Num[pos1] + arr2Num[pos2]);
            }
            return result;
        }
    }
}
