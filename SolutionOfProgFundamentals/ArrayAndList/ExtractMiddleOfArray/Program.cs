using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractMiddleOfArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            int[] arrNum = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arrNum[i] = int.Parse(arr[i]);
            }
            int[] arrExtract = new int[arr.Length % 2 + 2];
            if (arr.Length>1)
            {               
                for (int i = arr.Length/2-1, j = 0; i <= (arr.Length/2+ arr.Length%2); j++, i++)
                {
                    arrExtract[j] = arrNum[i];
                }
                Console.WriteLine("{"+$" { string.Join(", ", arrExtract)} " +"}");
            }
            else
            {
                Console.WriteLine("{" + $" {arrNum[0]} " + "}");
            }
            
        }
    }
}
