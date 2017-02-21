using System;
using System.Linq;

namespace WinningTicket
{
    public class StartUp
    {
        private static char[] simbols = new[] { '@', '#', '$', '^' };
        static char winChar = '0';
        static int[] winPoints = new[] { 0, 0 };

        public static void Main()
        {
            var input = Console.ReadLine().Split(',').Select(t => t.Trim());

            foreach (var ticket in input)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    CheckTicket(ticket);
                    Print(ticket);
                }
            }
        }

        private static void Print(string ticket)
        {
            if (b)
            {
                
            }


            //if (winPoints[0] < 6 || winPoints[1] < 6)
            //{
            //    Console.WriteLine("ticket \"{0}\" - no match", ticket);
            //    winChar = '0';
            //    winPoints[0] = 0;
            //    winPoints[1] = 0;
            //    return;
            //}
            //if (winPoints[0] == 10 && winPoints[1] == 10)
            //{
            //    Console.WriteLine("ticket \"{0}\" - 10{1} Jackpot!", ticket, winChar);
            //    winChar = '0';
            //    winPoints[0] = 0;
            //    winPoints[1] = 0;
               
            //}
            //else
            //{
            //    Console.WriteLine("ticket \"{0}\" - {1}{2}", ticket, winPoints[0], winChar);
            //    winChar = '0';
            //    winPoints[0] = 0;
            //    winPoints[1] = 0;
              
            //}
        }

        private static void CheckTicket(string ticket)
        {
            var ticketLeft = ticket.Substring(0, 10);
            var ticketRight = ticket.Substring(10, 10);

            CheckLeft(ticketLeft);
            CheckRight(ticketRight);
        }

        private static void CheckRight(string ticketRight)
        {
            var maxCount = 1;
            var currentChar = '0';
            var count = 1;
            for (int i = 1; i < ticketRight.Length; i++)
            {
                currentChar = ticketRight[i];
                var previousChar = ticketRight[i - 1];
                if (currentChar == previousChar && currentChar == winChar)
                {
                    count++;
                    if (count > maxCount)
                    {
                        maxCount = count;
                    }
                }
                else
                {
                    count = 1;
                }
            }

            if (maxCount > 5)
            {
                winPoints[1] = maxCount;
            }
        }

        private static void CheckLeft(string ticketLeft)
        {
            var maxCount = 0;
            var currentChar = '0';
            var count = 1;
            for (int i = 1; i < ticketLeft.Length; i++)
            {
                currentChar = ticketLeft[i];
                var previousChar = ticketLeft[i - 1];
                if (currentChar == previousChar && simbols.Contains(currentChar))
                {
                    count++;
                    if (count > maxCount)
                    {
                        maxCount = count;
                        winChar = previousChar;
                    }
                }
                else
                {
                    count = 1;
                }
            }

            if (maxCount > 5)
            {
                winPoints[0] = maxCount;
            }
        }
    }
}
