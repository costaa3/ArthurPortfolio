using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqWithLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var universityManager = new UniversityManager();
            //universityManager.MaleStudents();
            //universityManager.FemaleStudents();
            //universityManager.SortStudentsbByAge();
            //universityManager.GetStudentsFromUniversityId(1);
            universityManager.StudentAndUniversityNameCollection();
            Console.ReadLine();
        }

        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public int UniversityId { get; set; }

            public void Print()
            {

                Console.WriteLine($"Student {Name} with Id {Id},Gender {Gender}, Age {Age}, from university with Id{UniversityId}");

            }

        }

        public class UniversityManager
        {
            public List<University> universities;
            public List<Student> students;

            public UniversityManager()
            {
                universities = new List<University>() {
                new University() { Id = 1,Name = "Yale"},
                new University() { Id = 2,Name = "Beijing Tech"}
                };

                students = new List<Student>() {
                new Student() { Id = 1,Name="Carla",Gender = "Female",Age = 17,UniversityId = 1},
                new Student() { Id = 2,Name="Toni",Gender = "Male",Age = 21,UniversityId = 1},
                new Student() { Id = 3,Name="Leyla",Gender = "Female",Age = 19,UniversityId = 2},
                new Student() { Id = 4,Name="James",Gender = "Trans-Gender",Age = 25,UniversityId = 2},
                new Student() { Id = 5,Name="Linda",Gender = "Female",Age = 22,UniversityId = 2},
                };
            }

            public void MaleStudents()
            {
                IEnumerable<Student> maleStudents = from student in students where student.Gender == "Male" select student;
                Console.WriteLine("Male students:");
                students.Add(new Student() { Id = 3, Name = "John", Gender = "Male", Age = 17, UniversityId = 1 });
                foreach (Student student in maleStudents)
                {
                    student.Print();
                }
            }

            public void FemaleStudents()
            {
                Console.WriteLine("Female students:");

                IEnumerable<Student> FemaleStudents = from student in students where student.Gender == "Female" select student;
                PrintStudents(FemaleStudents);

            }


            public void SortStudentsbByAge()
            {
                var result = from student in students orderby student.Id select student;

                PrintStudents(result);
            }
            public void StudentsFromBeijing()
            {

                var result = from student in students join uni in universities on student.UniversityId equals uni.Id where uni.Name.Equals("Beijing Tech") select student;

                PrintStudents(result);
            }

            private static void PrintStudents(IEnumerable<Student> result)
            {
                foreach (Student student in result)
                {
                    {
                        student.Print();
                    }
                }
            }

            public void GetStudentsFromUniversityId(int universityId)
            {
                var result = from student in students join uni in universities on student.UniversityId equals uni.Id where uni.Id.Equals(universityId) select student;
                PrintStudents(result);
            }

            public void StudentAndUniversityNameCollection()
            {
                var resultOfAllNames = from student in students join university in universities on student.UniversityId equals university.Id select new { StudentName = student.Name, UniversityName = university.Name };
                foreach (var obj in resultOfAllNames)
                {
                    Console.WriteLine($"The student {obj.StudentName} is at university {obj.UniversityName} ");
                }


            }

        }



        public class University
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public void Print()
            {

                Console.WriteLine($"University {Name} with Id {Id}");

            }
        }
    }
}
