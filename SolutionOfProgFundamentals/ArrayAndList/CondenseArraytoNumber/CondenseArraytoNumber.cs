using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondenseArraytoNumber
{
    class CondenseArraytoNumber
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            int[] arrNum = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arrNum[i] = int.Parse(arr[i]);
            }
            int[] arrCondenced =null;
            if (arrNum.Length < 2)
            {
                Console.WriteLine(arrNum[0] + "is already condensed to number");
            }
            else
            {
                while (arrNum.Length > 1)
                {
                    arrCondenced = new int[arrNum.Length - 1];
                    for (int i = 0; i < arrNum.Length - 1; i++)
                    {
                        arrCondenced[i] = arrNum[i] + arrNum[i + 1];
                    }
                    arrNum = arrCondenced;
                }
            }
            Console.WriteLine(arrNum[0]);
        }
    }
}
