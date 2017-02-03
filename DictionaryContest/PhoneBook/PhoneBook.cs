namespace PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PhoneBook
    {
        static Dictionary<string,string> phoneBook = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            var input = Console.ReadLine();           

            while (!input.Equals("END"))
            {
                if (input.Equals("ListAll"))
                {
                    PrintAll();
                }
                else
                {
                    Proceed(input);
                }                

                input = Console.ReadLine();
            }
        }

        private static void PrintAll()
        {
            foreach (var item in phoneBook.OrderBy(n => n.Key))
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }

        private static void Proceed(string input)
        {
            var inputArr = input.Split();
            var command = inputArr[0];
            var data = inputArr.Skip(1). Take(2).ToArray();
            if (command.Equals("A"))
            {
                Add(data);
            }
            if (command.Equals("S"))
            {
                Search(data);
            }
        }

        private static void Search(string[] data)
        {
            var name = data[0];

            if (phoneBook.ContainsKey(name))
            {
                Console.WriteLine("{0} -> {1}", name, phoneBook[name]);
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.", name);
            }
        }

        private static void Add(string[] data)
        {
            var name = data[0];
            var phone = data[1];
            phoneBook[name] = phone;
        }
    }
}
