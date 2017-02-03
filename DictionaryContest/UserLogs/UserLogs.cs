namespace UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class UserLogs
    {
        static Dictionary<string, Dictionary<string, int>> logs = new Dictionary<string, Dictionary<string, int>>();

        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (!input.Equals("end"))
            {
                var inputSplit = input.Split();
                var user =string.Join("", inputSplit[2].Skip(5).Take(inputSplit[2].Length-5));
                var messege = inputSplit[1];
                var ip =string.Join("", inputSplit[0].Skip(3).Take(inputSplit[0].Length-3));
                Add(user, ip);

                input = Console.ReadLine();
            }

            Print();
        }

        private static void Print()
        {
            foreach (var user in logs.OrderBy(n => n.Key))
            {
                Console.WriteLine("{0}:", user.Key);
                var output = new List<string>();
                foreach (var ip in user.Value)
                {
                    output.Add($"{ip.Key} => {ip.Value}");
                }
                Console.WriteLine("{0}.", string.Join(", ", output));
            }
        }

        private static void Add(string user, string ip)
        {
            if (logs.ContainsKey(user))
            {
                if (logs[user].ContainsKey(ip))
                {
                    logs[user][ip]++;
                }
                else
                {
                    logs[user][ip] = 1;
                }
            }
            else
            {
                logs[user]=new Dictionary<string, int>();
                logs[user][ip] = 1;
            }
        }
    }
}
