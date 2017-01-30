namespace WinningTicket
{
    using System;
    class WinningTicket
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(new char[]{ ' ', ','}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var input in inputs)
            {
                Proceed(input);
            }

           
        }

        private static void Proceed(string input)
        {
            if (input.Length!=20)
            {
                Console.WriteLine("invalid ticket");
            }
        }
    }
}
