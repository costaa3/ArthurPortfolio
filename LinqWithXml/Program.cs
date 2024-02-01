using System;
using System.Linq;
using System.Xml.Linq;

namespace LinqWithXml
{
    internal class Program
    {
        static void Main(string[] args)
        {

            GetStudentsInfo();

            Console.ReadLine();

        }

        private static void GetStudentsInfo()
        {
            string studentsXML =
                  @"<Students>
                            <Student>
                                <Name>Toni</Name>
                                <Age>21</Age>
                                <University>Yale</University>
                                <Semester>6</Semester>
                            </Student>
                            <Student>
                                <Name>Carla</Name>
                                <Age>17</Age>
                                <University>Yale</University>
                                <Semester>1</Semester>
                            </Student>
                            <Student>
                                <Name>Leyla</Name>
                                <Age>19</Age>
                                <University>Beijing Tech</University>
                                <Semester>3</Semester>
                            </Student>
                            <Student>
                                <Name>Frank</Name>
                                <Age>25</Age>
                                <University>Beijing Tech</University>
                                <Semester>10</Semester>
                            </Student>
                        </Students>";


            XDocument xmlDocument = new XDocument();
            xmlDocument = XDocument.Parse(studentsXML);


            var studentsInfo = from student in xmlDocument.Descendants("Student")
                               select new
                               {
                                   StudentName = student.Element("Name").Value,
                                   StudentAge = student.Element("Age").Value,
                                   StudentUniversity = student.Element("University").Value,
                                   StudentSemester = student.Element("Semester").Value,
                               };
            var studentsInfos = studentsInfo.SkipWhile(it => it.StudentName.Length < 5);
            var sortedStudents = from student in studentsInfo orderby student.StudentName select student;


            foreach (var student in studentsInfos)
            {
                Console.WriteLine($"The student {student.StudentName}, has {student.StudentAge} years old and goes to the {student.StudentUniversity}, and currently is on semester {student.StudentSemester}");
            }
        }
    }
}
