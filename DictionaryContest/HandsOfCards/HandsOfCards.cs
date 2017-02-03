namespace HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class HandsOfCards
    {
        static string[] deck = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        static string[] cardsType = { "0", "C", "D", "H", "S" };//S -> 4, H-> 3, D -> 2, C -> 
        static Dictionary<string, List<string>> playerCards = new Dictionary<string, List<string>>();
        static Dictionary<string, int> playerPoints = new Dictionary<string, int>();
        static char[] separator = { ' ', ',', ':' };

        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (!input.Equals("JOKER"))
            {
                var inputSplit = input.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var name = inputSplit[0];
                var cards = inputSplit.Skip(1).Take(inputSplit.Length - 1).ToList();
                Add(name, cards);

                input = Console.ReadLine();
            }
            CalcPoint();
            Print();
        }

        private static void Print()
        {
            foreach (var player in playerPoints)
            {
                Console.WriteLine("{0}: {1}", player.Key, player.Value);
            }
        }

        private static void CalcPoint()
        {
            foreach (var player in playerCards)
            {
                playerPoints[player.Key] = Points(player.Value);
            }
        }

        private static int Points(List<string> cards)
        {
            var sum = 0;
            foreach (var card in cards.Distinct())
            {
                var power =string.Join("",card.Take(card.Length-1).ToArray());
                var type = card.Last().ToString();
                sum += Array.IndexOf(deck, power) * (int)Array.IndexOf(cardsType, type);
            }

            return sum;
        }

        private static void Add(string name, List<string> cards)
        {
            if (playerCards.ContainsKey(name))
            {
                foreach (var card in cards)
                {
                    //if (playerCards[name].Contains(card))
                    //{
                    //    continue;
                    //}
                    //else
                    {
                        playerCards[name].Add(card);
                    }
                }
            }
            else
            {
                playerCards[name] = cards;

            }
        }
    }
}
