using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniKaraoke
{
    class SoftUniKaraoke
    {
        static Dictionary<string, List<string>> singers = new Dictionary<string, List<string>>();
        static List<string> songs = new List<string>();

        static void Main()
        {
            var participants = Console.ReadLine().Split(',');
            foreach (var participant in participants)
            {
                if (!singers.ContainsKey(participant.Trim()))
                {
                    singers[participant.Trim()] = new List<string>();
                }
            }
            var songsIn = Console.ReadLine().Split(',');
            foreach (var song in songsIn)
            {
                if (!songs.Contains(song.Trim()))
                {
                    songs.Add(song.Trim());
                }
            }


            var input = Console.ReadLine();

            while (!input.Equals("dawn"))
            {
                Proceed(input);
                input = Console.ReadLine();
            }

            Print();
        }

        private static void Print()
        {
            if (singers.OrderByDescending(n => n.Value.Count).First().Value.Count == 0)
            {
                Console.WriteLine("No awards");
            }
            else
            {
                foreach (var singer in singers.OrderByDescending(n => n.Value.Count).ThenBy(n => n.Key))
                {
                    if (singer.Value.Count > 0)
                    {
                        Console.WriteLine("{0}: {1} awards", singer.Key, singer.Value.Count);
                        foreach (var item in singer.Value.OrderBy(n => n))
                        {
                            Console.WriteLine("--{0}", item);
                        }
                    }
                }
            }
        }

        private static void Proceed(string input)
        {
            var inputSplit = input.Split(',');

            var singer = inputSplit[0].Trim();
            var song = inputSplit[1].Trim();
            var award = inputSplit[2].Trim();

            if (singers.ContainsKey(singer)&&songs.Contains(song))
            {
                if (!singers[singer].Contains(award))
                {
                    singers[singer].Add(award);
                }                
            }
        }
    }
}
