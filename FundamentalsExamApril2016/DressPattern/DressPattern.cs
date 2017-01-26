using System;

namespace DressPattern
{
    class DressPattern
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            FirstLine(size);
            Sleeves(size);
            Body(size);
            Skirt(size);
        }

        private static void Skirt(int size)
        {

            for (int i = 0; i < 3*size; i++)
            {
                int dimOut = 3*size-i;
                int dimIn = 6*size+i*2;
                Console.WriteLine("{0}.{1}.{0}", new string('_', dimOut), new string('*', dimIn));
            }
            Console.WriteLine(new string('.', 12*size+2));
        }

        private static void Body(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(".{0}.", new string('*', 12*size));
            }
            Console.WriteLine("{0}{1}{0}", new string('.', 3*size), new string('*', 6*size+2));
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("{0}{1}{0}", new string('_', 3 * size), new string('o', 6 * size + 2));
            }
            
        }

        private static void Sleeves(int size)
        {
            for (int i = 0; i < size*2; i++)
            {
                int dimOut = 4*size-2-2*i ;
                int dimIn = 2+3*i;
                Console.WriteLine("{0}.{1}.{0}.{1}.{0}", new string('_', dimOut), new string('*', dimIn));
            }
        }

        private static void FirstLine(int size)
        {
            Console.WriteLine("{0}.{0}.{0}", new string('_', 4*size));
        }
    }
}
