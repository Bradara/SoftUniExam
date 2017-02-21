using System.Collections.Generic;
using System.Linq;
using System;

namespace EnduranceRally
{
    public class StartUp
    {
        class Driver
        {
            public string Name { get; }
            public decimal Fuel { get; set; }
            public int IndexReached { get; set; }
            public bool IsRunning { get; set; }

            public Driver(string name)
            {
                Name = name;
                Fuel = name[0];
                IndexReached = 0;
                IsRunning = true;
            }
        }
        public static void Main()
        {
            var drivers = new List<Driver>();
            AddDriver(drivers);

            var trackLayout = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
            var checkPoint = Console.ReadLine().Split().Select(int.Parse).ToArray();

            StartRally(drivers, trackLayout, checkPoint);

            PrintResult(drivers);
        }

        private static void PrintResult(List<Driver> drivers)
        {
            foreach (var driver in drivers)
            {
                if (driver.Fuel > 0)
                {
                    Console.WriteLine("{0} - fuel left {1:f2}", driver.Name, driver.Fuel);
                }
                else
                {
                    Console.WriteLine("{0} - reached {1}", driver.Name, driver.IndexReached);
                }
            }
        }

        private static void StartRally(List<Driver> drivers, decimal[] trackLayout, int[] checkPoint)
        {
            for (int i = 0; i < trackLayout.Length; i++)
            {
                var trackLayoutValue = trackLayout[i];
                if (checkPoint.Contains(i))
                {
                    Refuel(drivers, trackLayoutValue);
                    continue;
                }

                BurnFuel(drivers, trackLayoutValue);
                CheckFuel(drivers, i);
            }
        }

        private static void CheckFuel(List<Driver> drivers, int i)
        {
            foreach (var driver in drivers.Where(d => d.IsRunning==true))
            {
                if (driver.Fuel <= 0)
                {
                    driver.IndexReached = i;
                    driver.IsRunning = false;
                }
            }
        }

        private static void BurnFuel(List<Driver> drivers, decimal trackLayoutValue)
        {
            foreach (var driver in drivers.Where(d => d.IsRunning==true))
            {
                driver.Fuel -= trackLayoutValue;
            }
        }

        private static void Refuel(List<Driver> drivers, decimal trackLayoutValue)
        {
            foreach (var driver in drivers)
            {
                if (driver.IsRunning)
                {
                    driver.Fuel += trackLayoutValue;
                }
            }
        }

        private static void AddDriver(List<Driver> drivers)
        {
            var input = Console.ReadLine().Split();

            for (int i = 0; i < input.Length; i++)
            {
                var name = input[i];

                var driver = new Driver(name);
                drivers.Add(driver);
            }
        }
    }
}
