namespace MinerTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MinerTask
    {
        static void Main(string[] args)
        {
            var resources = new Dictionary<string, int>();

            while (true)
            {
                var name = Console.ReadLine();
                if (name.Equals("stop"))
                {
                    break;
                }
                var quantity = int.Parse(Console.ReadLine());
                if (quantity.Equals("stop"))
                {
                    break;
                }
                if (resources.ContainsKey(name))
                {
                    resources[name] += quantity;
                }
                else
                {
                    resources[name] = quantity;
                }
            }

            foreach (var item in resources)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}
