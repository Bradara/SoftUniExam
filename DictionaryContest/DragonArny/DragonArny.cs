namespace DragonArny
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class DragonArny
    {
        static Dictionary<string, Dictionary<string,int[]>> dragons = new Dictionary<string, Dictionary<string, int[]>>();

        static void Main()
        {
            var numberOgDragons = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOgDragons; i++)
            {
                Proceed();
            }

            Print();
        }

        private static void Print()
        {
            foreach (var dragon in dragons)
            {
                var countNames = dragon.Value.Count;
                var avDamage = (double)dragon.Value.Values.Select(n =>n[0]).Sum()/countNames;
                var avHealth = (double)dragon.Value.Values.Select(n =>n[1]).Sum()/countNames;
                var avArmor = (double)dragon.Value.Values.Select(n =>n[2]).Sum()/countNames;
                Console.WriteLine("{0}::({1:f2}/{2:f2}/{3:f2})", dragon.Key, avDamage,avHealth, avArmor);
                foreach (var name in dragon.Value.OrderBy(n => n.Key))
                {
                    Console.WriteLine("-{0} -> damage: {1}, health: {2}, armor: {3}", 
                        name.Key, 
                        string.Join("", name.Value.Take(1).ToArray()), 
                        string.Join("", name.Value.Skip(1).Take(1).ToArray()), 
                        string.Join("", name.Value.Skip(2).Take(1).ToArray()));
                }
            }
        }

        private static void Proceed()
        {
            var input = Console.ReadLine().Split();
            var type = input[0];
            var name = input[1];
            var damage = input[2];
            var health = input[3];
            var armor = input[4];
            if (dragons.ContainsKey(type))
            {
                if (dragons[type].ContainsKey(name))
                {
                    dragons[type][name][0] = damage.Equals("null") ? 45 : int.Parse(damage);
                    dragons[type][name][1] = health.Equals("null") ? 250 : int.Parse(health);
                    dragons[type][name][2] = armor.Equals("null") ? 10 : int.Parse(armor);
                }
                else
                {                    
                    dragons[type][name] = new int[3];
                    dragons[type][name][0] = damage.Equals("null") ? 45 : int.Parse(damage);
                    dragons[type][name][1] = health.Equals("null") ? 250 : int.Parse(health);
                    dragons[type][name][2] = armor.Equals("null") ? 10 : int.Parse(armor);
                }
            }
            else
            {
                dragons[type] = new Dictionary<string, int[]>();
                dragons[type][name] = new int[3];
                dragons[type][name][0] = damage.Equals("null") ? 45 : int.Parse(damage);
                dragons[type][name][1] = health.Equals("null") ? 250 : int.Parse(health);
                dragons[type][name][2] = armor.Equals("null") ? 10 : int.Parse(armor);
            }

        }
    }
}
