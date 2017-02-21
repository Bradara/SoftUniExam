using System.Collections.Generic;
using System.Linq;

namespace SoftUniKaraoke
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var participants = new Dictionary<string, List<string>>();
            var songs = new List<string>();

            ReadParticipants(participants);
            ReadSongs(songs);
            ReadStagePerformance(songs, participants);

            PrintAward(participants, songs);

        }

        private static void PrintAward(Dictionary<string, List<string>> participants, List<string> songs)
        {
            if (participants.Values.All(p => p.Count<1))
            {
                Console.WriteLine("No awards");
            }
            foreach (var participant in participants.OrderByDescending(p => p.Value.Count).ThenBy(p => p.Key).Where(p => p.Value.Count>0))
            {
                Console.WriteLine("{0}: {1} awards", participant.Key, participant.Value.Count);
                foreach (var award in participant.Value.OrderBy(a => a))
                {
                    Console.WriteLine("--{0}", award);
                }
            }
        }

        private static void ReadStagePerformance(List<string> songs, Dictionary<string, List<string>> participants)
        {
            var input = Console.ReadLine();

            while (!input.Equals("dawn"))
            {
                var inputSplit = input.Split(',').Select(p => p.Trim()).ToArray();
                var participant = inputSplit[0];
                var song = inputSplit[1];
                var award = inputSplit[2];

                if (participants.ContainsKey(participant) && songs.Contains(song))
                {
                    if (!participants[participant].Contains(award))
                    {
                        participants[participant].Add(award);
                    }
                }

                input = Console.ReadLine();
            }
        }

        private static void ReadSongs(List<string> songs)
        {
            var input = Console.ReadLine().Split(',').Select(s => s.Trim()).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                if (!songs.Contains(input[i]))
                {
                    songs.Add(input[i]);
                }
            }
        }

        private static void ReadParticipants(Dictionary<string, List<string>> participants)
        {
            var input = Console.ReadLine().Split(',').Select(p => p.Trim()).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                if (!participants.ContainsKey(input[i]))
                {
                    participants[input[i]] = new List<string>();
                }
            }
        }
    }
}
