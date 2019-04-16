using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    public static class StudentData
    {
        private static List<Student> testStudents = new List<Student>();

        public static List<Student> TestStudents
        {
            get
            {
                ResetTestUser();
                return testStudents;
            }

            private set { }
        }

        public static string PrepareCertificate(Student student)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Dear, {student.Firstname} {student.Lastname}");
            builder.AppendLine($"You have successfully graduated from {student.Course} with the specialty {student.Specialty}");

            return builder.ToString();
        }

        public static void SaveCertificate(String certificate, String filename)
        {
            using (StreamWriter writer = new StreamWriter(filename, true)) 
            {
                string[] lines = certificate.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                for (int i = 0; i < lines.Length; i++)
                {
                    writer.WriteLine(lines[i]);
                }
            }
        }

        public static bool IsThereStudent(string facultyNumber)
        {
            return (from s in TestStudents
                    where s.FacultyNumber.Equals(facultyNumber)
                    select s).ToList().Count > 0;
        }

        private static void ResetTestUser()
        {
            testStudents.Add(new Student("Student1", "Student1", "Student1", "FKST", "KSI", "bakalavar",
                "student", "123457", "1", "3", "50", DateTime.MaxValue, DateTime.MaxValue));
            testStudents.Add(new Student("Student2", "Student2", "Student2", "FKST", "KSI", "bakalavar",
                "student", "1213", "1", "3", "50", DateTime.MaxValue, DateTime.MaxValue));
        }
    }
}
