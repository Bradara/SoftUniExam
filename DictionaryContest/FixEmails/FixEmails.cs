namespace FixEmails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FixEmails
    {
        static void Main(string[] args)
        {
            var emails = new Dictionary<string, string>();

            while (true)
            {
                var name = Console.ReadLine();

                if (name.Equals("stop"))
                {
                    break;            
                }
                var email = Console.ReadLine();
                var checkStr = string.Join("", email.Reverse().Take(2).ToArray());             

                if (checkStr.Equals("su")||checkStr.Equals("uk".Reverse()))
                {
                    continue;
                }

                emails[name] = email;
            }

            foreach (var item in emails)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}
