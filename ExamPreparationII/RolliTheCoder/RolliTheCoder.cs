using System;
using System.Collections.Generic;
using System.Linq;

namespace RolliTheCoder
{
    class RolliTheCoder
    {
        public class Event
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public List<string> ParticipantList { get; set; }

            public Event(int id, string name)
            {
                ID = id;
                Name = name;
                ParticipantList = new List<string>();
            }
        }
        static void Main()
        {
            var events = new List<Event>();

            var input = Console.ReadLine();

            while (!input.Equals("Time for Code"))
            {
                var inputSplit = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(inputSplit[0]);
                if (inputSplit[1][0].Equals('#') && !events.Exists(e => e.ID == id))
                {
                    var name = string.Join("", inputSplit[1].Skip(1).Take(inputSplit[1].Length - 1));
                    var someEvent = new Event(id, name);
                    var participants = inputSplit.Skip(2).Take(inputSplit.Length - 2);

                    foreach (var participant in participants)
                    {
                        someEvent.ParticipantList.Add(participant);
                    }
                    events.Add(someEvent);
                }
                else if (inputSplit[1][0].Equals('#'))
                {
                    var eventName = events.Where(e => e.ID == id).ElementAt(0);
                    var name = string.Join("", inputSplit[1].Skip(1).Take(inputSplit.Length));
                    if (eventName.Name == name)
                    {
                        var participants = inputSplit.Skip(2).Take(inputSplit.Length);

                        foreach (var participant in participants)
                        {
                            if (!eventName.ParticipantList.Contains(participant))
                            {
                                eventName.ParticipantList.Add(participant);
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var e in events.OrderByDescending(e => e.ParticipantList.Count).ThenBy(e => e.Name))
            {
                Console.WriteLine("{0} - {1}", e.Name, e.ParticipantList.Count);
                foreach (var participant in e.ParticipantList.OrderBy(a => a))
                {
                    Console.WriteLine(participant);
                }
            }
        }
    }
}
