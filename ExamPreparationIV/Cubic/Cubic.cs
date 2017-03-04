using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Cubic
{
    class Cubic
    {
        class Message
        {
            public string Encoded { get; set; }
            public string Decoded { get; set; }

            public Message(string encoded, string decoded)
            {
                Encoded = encoded;
                Decoded = decoded;
            }
        }

        static List<Message> messages = new List<Message>();

        static void Main()
        {
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Over!")
            {
                var length = int.Parse(Console.ReadLine());
                var rx = new Regex(@"(^\d+)([A-z]{" + length + @"})([\d\W]*?$)");
                if (rx.IsMatch(input))
                {
                    var match = rx.Match(input);
                    var encoded = match.Groups[2].ToString();
                    var codeLeft = match.Groups[1].ToString();
                    var codeRight = match.Groups[3].ToString();

                    Decode(encoded, codeLeft, codeRight);
                }
            }

            Print();
        }

        private static void Print()
        {
            foreach (var message in messages)
            {
                Console.WriteLine("{0} == {1}", message.Encoded, message.Decoded);
            }
        }

        private static void Decode(string encoded, string codeLeft, string codeRight)
        {
            var result = string.Empty;

            for (int i = 0; i < codeLeft.Length; i++)
            {
                var index = int.Parse(codeLeft[i].ToString());
                if (index >= 0 && index < encoded.Length)
                {
                    result += encoded[index];
                }
                else
                {
                    result += " ";
                }
            }

            for (int i = 0; i < codeRight.Length; i++)
            {
                var c = codeRight[i];
                if (char.IsDigit(c))
                {
                    var index = int.Parse(c.ToString());
                    if (index >= 0 && index < encoded.Length)
                    {
                        result += encoded[index];
                    }
                    else
                    {
                        result += " ";
                    }
                }
            }

            var messege = new Message(encoded, result);
            messages.Add(messege);
        }
    }
}
