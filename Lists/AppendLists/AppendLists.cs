using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendLists
{
    class AppendLists
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] {'|' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> result = new List<int>();

            for (int i = input.Length-1; i >=0; i--)
            {
                var tokens = input[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(n =>int.Parse(n)).ToArray();
                foreach (var token in tokens)
                {
                    result.Add(token);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
