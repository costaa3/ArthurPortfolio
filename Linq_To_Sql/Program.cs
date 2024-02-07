using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Linq_To_Sql
{
    internal class Program
    {
        static LinqToSqlDataClassDataContext dataContext;

        static void Main(string[] args)
        {
            
            string DbConnectionString = ConfigurationManager.ConnectionStrings["Linq_To_Sql.Properties.Settings.masterConnectionString"].ConnectionString;

            dataContext = new LinqToSqlDataClassDataContext(DbConnectionString);


            //ClearAllUniversities();
            //AddUniversity("Beijing tech");
            //AddUniversity("Yale");

            //AddStudents();
            //ShowAllStudents();
            //AddLectures(true);
            AppendStudentLectureAssociation();
            Console.ReadLine();
        }

        public static void displayAllUniversities()
        {
            var res = dataContext.Universities.ToList();

            foreach (var univer in res)
            {
                Console.WriteLine( $"Universiry id:{univer.Id} | University Name {univer.Name}");

            }
        }

        private static void ClearAllUniversities()
        {
            dataContext.ExecuteCommand("Delete from University");
            dataContext.SubmitChanges();
        }


        public static void AddUniversity(string university)
        {
            University university1 = new University() { 
                Name = university,
            };

            dataContext.Universities.InsertOnSubmit(university1 );
            dataContext.SubmitChanges();
        }

        public static void AddStudent(string studentName,University university)
        {

            Student student1 = new Student() { Name = "Carla", Gender = "Female", UniversityId = university.Id };

        }

        public static void ShowAllStudents()
        {
            foreach (Student student in dataContext.Students)
            {

                Console.WriteLine($"{student.Name} is a student at {student.University.Name} and he is {student.Gender}");

            }
            

        }

        public static void AddStudents()
        {

            University YaleUniversity = dataContext.Universities.FirstOrDefault(u => u.Name == "Yale");
            University BeijingTech = dataContext.Universities.FirstOrDefault(u => u.Name == "Beijing tech");


            List<Student> Students = new List<Student>
            {
                new Student() { Name = "Carla", Gender = "Female", UniversityId = YaleUniversity.Id },
                new Student() { Name = "Toni", Gender = "Male", UniversityId = BeijingTech.Id },
                new Student() { Name = "Leyle", Gender = "Female", UniversityId = YaleUniversity.Id },
                new Student() { Name = "Jame", Gender = "Trans-Gender", UniversityId = BeijingTech.Id }
            };


            dataContext.Students.InsertAllOnSubmit(Students);
            dataContext.SubmitChanges();
        }

        public static void AddLectures(bool showLectures = false)
        {

            List<Lecture> Lectures = new List<Lecture> {
                new Lecture(){Name="Math"} ,
                new Lecture(){Name="Portuguese"} ,
                new Lecture(){Name="English"} ,
                new Lecture(){Name="Physics"} ,
                new Lecture(){Name="Computer engineering"}

                };

            dataContext.Lectures.InsertAllOnSubmit(Lectures);
            dataContext.SubmitChanges();

            if (showLectures)
            {
                foreach (Lecture lecture in dataContext.Lectures)
                {
                    Console.WriteLine($"This is a {lecture.Name} Lecture");
                }
            }
        }

        public static void AppendStudentLectureAssociation()
        {
            Student Carla = dataContext.Students.FirstOrDefault(s=> s.Name.Equals("Carla"));
            Student Toni = dataContext.Students.FirstOrDefault(s=> s.Name.Equals("Toni"));
            Student Leyle = dataContext.Students.FirstOrDefault(s=> s.Name.Equals("Leyle"));
            Student Jame = dataContext.Students.FirstOrDefault(s=> s.Name.Equals("Jame"));

            List<StudentLecture> studentLectures = new List<StudentLecture>();
            Lecture Math = dataContext.Lectures.FirstOrDefault(n=>n.Name.Equals("Math"));
            Lecture Portuguese = dataContext.Lectures.FirstOrDefault(n=>n.Name.Equals("Portuguese"));
            Lecture English = dataContext.Lectures.FirstOrDefault(n=>n.Name.Equals("English"));
            Lecture Physics = dataContext.Lectures.FirstOrDefault(n=>n.Name.Equals("Physics"));
            Lecture ComputerEngineering = dataContext.Lectures.FirstOrDefault(n=>n.Name.Equals("Computer engineering"));

            studentLectures.Add(new StudentLecture() { Lecture = Math, Student = Carla });
            studentLectures.Add(new StudentLecture() { Lecture = Portuguese, Student = Carla });
            studentLectures.Add(new StudentLecture() { Lecture = English, Student = Carla });
            studentLectures.Add(new StudentLecture() { Lecture = Portuguese, Student = Leyle });
            studentLectures.Add(new StudentLecture() { Lecture = Math, Student = Leyle });
            studentLectures.Add(new StudentLecture() { Lecture = Math, Student = Leyle });
            studentLectures.Add(new StudentLecture() { Lecture = ComputerEngineering, Student = Jame });
            studentLectures.Add(new StudentLecture() { Lecture = English, Student = Jame });
            studentLectures.Add(new StudentLecture() { Lecture = Physics, Student = Jame });
            studentLectures.Add(new StudentLecture() { Lecture = Portuguese, Student = Jame });


            dataContext.StudentLectures.InsertAllOnSubmit(studentLectures);
            dataContext.SubmitChanges();



            foreach (Student student in dataContext.Students)
            {
                Console.WriteLine($"This is {student.Name}");
                foreach (var lecture in student.StudentLectures)
                {
                    Console.WriteLine($"{lecture.Lecture.Name}");
                }

            }

        }
    }
}
