namespace VehiclePark
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class VehiclePark
    {
        public static void Main()
        {
            List<string> park = Console.ReadLine().Split().ToList();
            int count = 0;
            string order = Console.ReadLine();

            while (!order.Equals("End of customers!"))
            {
                var input = order.Split();
                string c = input[0][0].ToString().ToLower();
                string custemerNeed = c + input[2];

                if (park.Contains(custemerNeed))
                {
                    var priceOfOrder = (int)c[0] * int.Parse(input[2]);
                    Console.WriteLine("Yes, sold for {0}$", priceOfOrder);
                    count++;
                    park.Remove(custemerNeed);
                }
                else
                {
                    Console.WriteLine("No");
                }

                order = Console.ReadLine();
            }

            Console.WriteLine("Vehicles left: {0}", string.Join(", ", park));
            Console.WriteLine("Vehicles sold: {0}", count);
        }
    }
}
