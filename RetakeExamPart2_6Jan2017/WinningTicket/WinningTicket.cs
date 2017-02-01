namespace WinningTicket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class WinningTicket
    {
        static char[] delimeter = { ' ', ',' };
        static char[] winSymbols = { '@', '#', '$', '%', '^' };
        static int[] winPoints = new int[2];
        static char winChar;

        static void Main()
        {
            var input = Console.ReadLine();
            string[] tickets = input.Split(delimeter, StringSplitOptions.RemoveEmptyEntries);
           
            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    Proceed(ticket);
                    Print(ticket);
                }
            }
        }

        private static void Print(string input)
        {
            if (winPoints[0]!=winPoints[1]||winPoints[0]<6)
            {
                Console.WriteLine($"ticket \"{input}\" - no match");
            }
            else if (winPoints[0]>5&&winPoints[0]<10)
            {
                Console.WriteLine($"ticket \"{input}\" - {winPoints[0]}{winChar}");
            }
            else if (winPoints[0]==10)
            {
                Console.WriteLine($"ticket \"{input}\" - {winPoints[0]}{winChar} Jackpot!");
            }
            else
            {
                Console.WriteLine($"ticket \"{input}\" - no match");
            }

        }

        private static void Proceed(string input)
        {
            var leftHalf = input.Substring(0, 10);
            var rightHalf = input.Substring(10, 10);
            CheckLeft(leftHalf);
            CheckRight(rightHalf);
        }

        private static void CheckRight(string str)
        {
            int count = 0;
            
            for (int i = 0; i < 7; i++)
            {
                if (winChar == str[i] && str[i] == str[i + 1])
                {                   
                    count=1;
                    for (int j = i; j < str.Length - 1; j++)
                    {
                        if (str[j] == winChar && str[j + 1] == winChar)
                        {
                            count++;
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (count > 5)
                {
                    winPoints[1] = count;                            
                }
            }
        }

        private static void CheckLeft(string str)
        {
            winChar = '0';
            winPoints[0] = 0;
            winPoints[1] = 0;
            int count = 0;
            char c = '0';
            for (int i = 0; i < 7; i++)
            {
                if (winSymbols.Contains(str[i])&&str[i]==str[i+1])
                {
                    c = str[i];
                    count = 1;             
                    for (int j = i; j < str.Length-1; j++)
                    {
                        if (str[j] == c &&str[j+1]==c)
                        {
                            count++;
                            i++;                           
                        }
                        else
                        {                            
                            break;
                        }
                    }                    
                }
                if (count>5)
                {
                    winPoints[0] = count;
                    winChar = c;                    
                }
            }
        }
    }
}   