using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundAwayFromZero
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrStr = Console.ReadLine().Split(' ');
            double[] arrNum = new double[arrStr.Length];
            for (int i = 0; i < arrNum.Length; i++)
            {
                arrNum[i] = double.Parse(arrStr[i]);
            }
            foreach (var item in arrNum)
            {
                Console.WriteLine("{0} => {1}", item, Math.Round(item,MidpointRounding.AwayFromZero));
            }
        }
    }
}
