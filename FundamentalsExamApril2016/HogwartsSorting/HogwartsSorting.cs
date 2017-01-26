using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogwartsSorting
{
    class HogwartsSorting
    {
        enum Houses
        {
            Gryffindor, Slytherin, Ravenclaw, Hufflepuff
        }
        class Student
        {
            public string Name { get; set; }
            public string FacultyNum { get; }
            public Houses House { get; }

            public Student(string name)
            {
                this.Name = name;
                this.FacultyNum = CalcFacultyNum(name);
                this.House = (Houses)GetHouses(FacultyNum);
            }

            private string CalcFacultyNum(string name)
            {
                string[] input = name.Split();
                int point = 0;
                string inicials = string.Empty;

                foreach (var n in input)
                {
                    for (int i = 0; i < n.Length; i++)
                    {
                        if (i==0)
                        {
                            inicials += n[i].ToString();
                        }
                        point += (int)n[i];
                    }
                }

                return point + inicials;
            }

            private int GetHouses(string facultyNum)
            {
                int point = int.Parse(string.Join("",facultyNum.Take(facultyNum.Length-2).ToArray()));
                return point % 4;
            }
        }
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int numberOfStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStudents; i++)
            {
                string input = Console.ReadLine();
                students.Add(new Student(input));
            }

            foreach (var student in students)
            {
                Console.WriteLine("{0} {1}", student.House, student.FacultyNum);
            }
            Console.WriteLine();
            
            for (int i = 0; i < 4; i++)
            {
                Houses nameofHouse = (Houses)i;
                int count = students.Where(s => s.House == nameofHouse).ToArray().Count();
                Console.WriteLine("{0}: {1}", nameofHouse, count);
            }
        }
    }
}
