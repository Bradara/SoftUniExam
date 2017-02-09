namespace StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    class StudentGroups
    {
        static List<City> cities = new List<City>();

        static void Main()
        {
            string input;
            string cityName = string.Empty;

            while (!(input = Console.ReadLine()).Equals("End"))
            {
                if (input.Contains("=>"))
                {
                    var inputSplit = input.Split(new char[] { '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
                    cityName = inputSplit[0].Trim();
                    var capacity = int.Parse(inputSplit[1].Trim().Split().First());

                    var city = new City()
                    {
                        Name = cityName,
                        Capacity = capacity,
                        Students = new List<Student>()
                    };
                    cities.Add(city);
                }
                else
                {
                    var inputSplit = input.Split('|');
                    var name = inputSplit[0].Trim();
                    var email = inputSplit[1].Trim();
                    var registrationDate = DateTime.ParseExact(inputSplit[2].Trim(), "d-MMM-yyyy", CultureInfo.InvariantCulture);

                    Student st = new Student(name, email, registrationDate);
                    var index = cities.FindIndex(c => c.Name == cityName);
                    cities[index].Students.Add(st);
                }
            }

            Print();
        }

        private static void Print()
        {
            Console.WriteLine($"Created {cities.Select(c => c.Groups).Sum()} groups in {cities.Count} towns:");

            foreach (var city in cities.OrderBy(c => c.Name))
            {
                for (int i = 0; i < city.Groups; i++)
                {
                    Console.Write($"{city.Name} => ");
                    Console.WriteLine(string.Join(", ", city.Students.OrderBy(s => s.RegistrationDate)
                                                                        .ThenBy(s => s.Name)
                                                                        .ThenBy(s => s.Email)
                                                                        .Skip(i * city.Capacity)
                                                                        .Take(city.Capacity).Select(s => s.Email)));
                }
            }
        }
    }

    class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Student(string name, string email, DateTime registrationDate)
        {
            Name = name;
            Email = email;
            RegistrationDate = registrationDate;
        }
    }

    class City
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public int Capacity { get; set; }
        public int Groups
        {
            get
            {
                if (Students.Count % Capacity == 0)
                {
                    return Students.Count / Capacity;
                }
                else
                {
                    return Students.Count / Capacity + 1;
                }
            }
        }
    }
}

