namespace AverageGrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AverageGrades
    {
        class Student
        {
            public string Name { get; set; }
            public List<double> Grades { get; set; }
            public double AverageGrade { get;}

            public Student(string name, double grade)
            {
                Name = name;
                Grades.Add(grade);
                AverageGrade = CalcAverage();
            }
            public Student(string name, List<double> grades)
            {
                Name = name;
                Grades = grades;
                AverageGrade = CalcAverage();
            }

            public double CalcAverage()
            {
                return Grades.Average();
            }
        }

        static List<Student> students = new List<Student>();

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                InputStudent();
            }

            foreach (var item in students.Where(s => s.AverageGrade>=5.0).OrderBy(s => s.Name).ThenByDescending(s => s.AverageGrade))
            {
                Console.WriteLine($"{item.Name} -> {item.AverageGrade:F2}");
            }
        }

        private static void InputStudent()
        {
            var input = Console.ReadLine().Split();

            var name = input[0];
            var grades = input.Skip(1).Take(input.Length - 1).ToList().Select(double.Parse).ToList(); ;
            students.Add(new Student(name, grades));
        }
    }
}
