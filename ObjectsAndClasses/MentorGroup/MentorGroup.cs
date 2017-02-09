namespace MentorGroup
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    class MentorGroup
    {

        static List<Student> students = new List<Student>();

        static void Main()
        {
            var inputDate = string.Empty;

            while (!(inputDate = Console.ReadLine()).Equals("end of dates"))
            {
                AddDate(inputDate);
            }

            var inputComment = string.Empty;

            while (!(inputComment = Console.ReadLine()).Equals("end of comments"))
            {
                AddComment(inputComment);
            }

            Print();
        }

        private static void Print()
        {
            foreach (var student in students.OrderBy(s => s.Name))
            {
                Console.WriteLine(student.Name);
                Console.WriteLine("Comments:");

                foreach (var comment in student.Comments)
                {
                    Console.WriteLine($"- {comment}");
                }

                Console.WriteLine("Dates attended:");
                foreach (var date in student.Dates.OrderBy(d => d))
                {
                    Console.WriteLine($"-- {date:dd/MM/yyyy}");
                }

            }
        }

        private static void AddComment(string inputComment)
        {
            var inputCommentSplit = inputComment.Split('-');
            var name = inputCommentSplit[0];
            var comment = inputCommentSplit[1];

            if (students.Any(s => s.Name == name))
            {
                var index = students.FindIndex(s => s.Name == name);
                students[index].Comments.Add(comment);
            }
        }

        private static void AddDate(string inputDate)
        {
            var inputDateSplit = inputDate.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var name = inputDateSplit[0];
            var dates = inputDateSplit.Skip(1)
                .Take(inputDateSplit.Length - 1)
                .Select(n => DateTime.ParseExact(n, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                .ToList();

            if (students.Any(c => c.Name == name))
            {
                var index = students.FindIndex(s => s.Name == name);
                foreach (var date in dates)
                {
                    students[index].Dates.Add(date);
                }
            }
            else
            {
                Student st = new Student(name, dates);
                students.Add(st);
            }
        }
        class Student
        {
            public string Name { get; set; }
            public List<DateTime> Dates { get; set; }
            public List<string> Comments { get; set; }

            public Student(string name, List<DateTime> date)
            {
                Name = name;
                Dates = date;
                Comments = new List<string>();
            }
        }
    }
}
