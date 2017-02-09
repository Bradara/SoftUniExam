namespace AdvertisementMessage
{
    using System;

    class AdvertisementMessage
    {
        static void Main()
        {
            string[] phrases = new string[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            string[] events = new string[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] author = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = new string[] {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};

            Random rnd = new Random();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int index = rnd.Next(100);
                Console.WriteLine("{0} {1} {2} – {3}", phrases[index%phrases.Length],
                                                      events[index%events.Length],
                                                      author[index%author.Length],
                                                      cities[index%cities.Length]);
            }


        }
    }
}
