using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveNegativeFromList
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            List<int> list = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                list.Add(int.Parse(arr[i]));
            }
            list = RemoveNegative(list);
            list = ReverseList(list);
            if (list.Count>0)
            {
                Console.WriteLine(string.Join(" ", list));
            }
            else
            {
                Console.WriteLine("empty");
            }
            
        }

        private static List<int> ReverseList(List<int> list)
        {            
            List<int> result = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                result.Add(list[list.Count - 1 - i]);
            }
            return result;
        }

        private static List<int> RemoveNegative(List<int> list)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i]>=0)
                {
                    result.Add(list[i]);
                }
            }
      
            return result;
        }
    }
}
