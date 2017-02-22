using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetherRealms
{
    class NetherRealms
    {
        public class Demon
        {
            public string Name { get; set; }
            public decimal Damage { get; }
            public int Health { get; }

            public Demon(string name)
            {
                Name = name;

                var healthName = string.Empty;
                var damageName = string.Empty;
                for (int i = 0; i < name.Length; i++)
                {
                    var ch = name[i];
                    if (char.IsDigit(ch)||ch.Equals('*')||ch.Equals('/')||ch.Equals('+')||ch.Equals('-')||ch.Equals('.'))
                    {
                        damageName += ch;
                        healthName += ' ';
                    }
                    else
                    {
                        damageName += ' ';
                        healthName += ch;
                    }
                }
                Damage = CalcDamage(damageName);
                Health = CalcHealth(healthName);
            }

            private int CalcHealth(string name)
            {
                var health = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    if (name[i].Equals(' '))
                    {
                        continue;
                    }
                    health += name[i];
                }

                return health;
            }

            private decimal CalcDamage(string name)
            {
                var nums = name.Split(new []{' ', '*', '/'}, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();

                var operand = string.Empty;
                for (int i = 0; i < name.Length; i++)
                {
                    if (name[i].Equals('/')||name[i].Equals('*'))
                    {
                        operand += name[i];
                    }
                }

                var damage = 0m;
                for (int i = 0; i < nums.Length; i++)
                {
                    damage += nums[i];
                }

                for (int i = 0; i < operand.Length; i++)
                {
                    if (operand[i].Equals('*'))
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }

                return damage;
            }
        }
        static void Main()
        {
            var demons = new List<Demon>();

            var input = Console.ReadLine().Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                var demon = new Demon(input[i]);
                demons.Add(demon);
            }

            foreach (var demon in demons.OrderBy(d => d.Name))
            {
                Console.WriteLine("{0} - {1} health, {2:f2} damage", demon.Name, demon.Health, demon.Damage);
            }
        }
    }
}
