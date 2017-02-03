﻿namespace LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LegendaryFarming
    {
        static Dictionary<string, int> materials = new Dictionary<string, int>();        
        static bool isGain = false;

        static void Main()
        {
            materials["fragments"] = 0;
            materials["shards"] = 0;            
            materials["motes"] = 0;

            while (!isGain)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < input.Length; i+=2)
                {
                    var quantity = int.Parse(input[i]);
                    var material = input[i+1].ToLower();
                    Add(material, quantity);
                    CheckForGain();
                    if (isGain)
                    {
                        break;
                    }
                }

                
            }

            Print();
        }

        private static void Print()
        {
            foreach (var item in materials.Take(3).OrderByDescending(n => n.Value))
            {                
                  Console.WriteLine("{0}: {1}", item.Key, item.Value);
                                
            }
            foreach (var item in materials.Skip(3).Take(materials.Count-3).OrderBy(n => n.Key))
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }
        }

        private static void CheckForGain()
        {
            if (materials["shards"]>250)
            {
                Console.WriteLine("Shadowmourne obtained!");
                isGain = true;
                materials["shards"] -= 250;
            }
            if (materials["fragments"] > 250)
            {
                Console.WriteLine("Valanyr  obtained!");
                isGain = true;
                materials["fragments"] -= 250;
            }
            if (materials["motes"] > 250)
            {
                Console.WriteLine("Dragonwrath  obtained!");
                isGain = true;
                materials["motes"] -= 250;
            }           
        }

        private static void Add(string material, int quantity)
        {
            if (materials.ContainsKey(material))
            {
                materials[material] += quantity;
            }
            else
            {
                materials[material] = quantity;
            }
        }
    }
}
