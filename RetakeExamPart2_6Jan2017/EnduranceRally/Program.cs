namespace EnduranceRally
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class EnduranceRally
    {
        class Player
        {
            public string Name { get; }
            public double Fuel { get; set; }
            public int Reached { get; set; }

            public Player(string name)
            {
                Name = name;
                Fuel = name[0];
            }

            public void IncreaseFuel(double amount)
            {
                if (Fuel > 0)
                {
                    Fuel += amount;
                }
            }

            public void DecreaseFuel(double amount, int i)
            {
                if (Fuel > 0)
                {
                    Fuel -= amount;
                    if (Fuel <= 0)
                    {
                        Reached = i;
                    }
                }
            }

        }
        static void Main()
        {
            var names = Console.ReadLine().Split();
            var players = new Player[names.Length];

            for (int i = 0; i < names.Length; i++)
            {
                Player p = new Player(names[i]);
                players[i] = p;
            }

            var tracks = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var checkpoints = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Play(players, tracks, checkpoints);

            PrintResult(players);
        }

        private static void PrintResult(Player[] players)
        {
            foreach (var player in players)
            {
                if (player.Fuel > 0)
                {
                    Console.WriteLine($"{player.Name} - fuel left {player.Fuel:f2}");
                }
                else
                {
                    Console.WriteLine($"{player.Name} - reached {player.Reached}");
                }
            }
        }

        private static void Play(Player[] players, double[] tracks, int[] checkpoints)
        {
            for (int i = 0; i < tracks.Length; i++)
            {
                if (checkpoints.Contains(i))
                {
                    foreach (var player in players)
                    {
                        player.IncreaseFuel(tracks[i]);
                    }
                }
                else
                {
                    foreach (var player in players)
                    {
                        player.DecreaseFuel(tracks[i], i);
                    }
                }
            }
        }
    }
}
