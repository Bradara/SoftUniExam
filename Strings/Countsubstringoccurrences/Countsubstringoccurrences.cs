namespace Countsubstringoccurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Countsubstringoccurrences
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var searchFor = Console.ReadLine();

            var count = 0;
            var index = text.IndexOf(searchFor, StringComparison.CurrentCultureIgnoreCase);

            while (index>=0)
            {
                count++;
                index = text.IndexOf(searchFor, index + 1, StringComparison.CurrentCultureIgnoreCase);
            }

            Console.WriteLine(count);
        }
    }

    
}
