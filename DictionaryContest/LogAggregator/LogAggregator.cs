namespace LogAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LogAggregator
    {
        static Dictionary<string, Dictionary<string, int>> logs = new Dictionary<string, Dictionary<string, int>>();

        static void Main()
        {
            var num = int.Parse(Console.ReadLine());            

            while (num>0)
            {
                var input = Console.ReadLine().Split();
                var user = input[1];
                var ip = input[0];
                var time = int.Parse(input[2]);
                Proceed(user, ip, time);

                num--;
            }

            Print();
        }

        private static void Print()
        {
            foreach (var user in logs.OrderBy(n => n.Key))
            {
                Console.Write("{0}: {1} [{2}]", 
                    user.Key, 
                    user.Value.Values.Sum(), 
                    string.Join(", ", user.Value.Keys.OrderBy(n => n)));
                Console.WriteLine();                
            }            
        }

        private static void Proceed(string user, string ip, int time)
        {
            if (logs.ContainsKey(user))
            {
                if (logs[user].ContainsKey(ip))
                {
                    logs[user][ip] += time;
                }
                else
                {
                    logs[user][ip] = time;
                }
            }
            else
            {
                logs[user] = new Dictionary<string, int>();
                logs[user][ip] = time;
            }
        }
    }
}
