using System;
using System.Collections.Generic;
using System.Linq;

namespace RoliTheCoder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var eventsID = new Dictionary<int, string>();
            var eventsParticipants = new Dictionary<string, List<string>>();
            while (true)
            {
                var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (line[0] == "Time")
                    break;
                var id = int.Parse(line[0]);
                var eventName = line[1].Substring(1);
                var participants = line.Skip(2).Distinct().ToList();

                if (eventsID.ContainsKey(id) && eventsID.ContainsValue(eventName) && line[1][0] == '#')
                {
                    foreach (var p in participants)
                    {
                        if (!eventsParticipants[eventName].Contains(p))
                        {
                            eventsParticipants[eventName].Add(p);
                        }
                    }
                    
                }
                else if (!eventsID.ContainsKey(id) && line[1][0] == '#' && !eventsID.ContainsValue(eventName))
                {
                    eventsID[id] = eventName;
                    eventsParticipants[eventName] = new List<string>();
                    eventsParticipants[eventName].AddRange(participants);
                }

            }

            var orderedList = eventsParticipants.OrderByDescending(s => s.Value.Count).ThenBy(s => s.Key);
            foreach (var participant in orderedList)
            {
                var participantsCount = participant.Value.Distinct().Count();
                Console.WriteLine($"{participant.Key} - {participantsCount}");

                foreach (var item in participant.Value.Distinct().OrderBy(s => s))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}