using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    public static class StudentData
    {
        private static List<Student> testStudents = new List<Student>();

        public static List<Student> TestStudent
        {
            get
            {
                ResetTestUser();
                return testStudents;
            }

            private set { }
        }

        public static bool IsThereStudent(string facultyNumber)
        {
            return (from s in testStudents
                    where s.FacultyNumber.Equals(facultyNumber)
                    select s).ToList().Count > 0;
        }

        private static void ResetTestUser()
        {
            testStudents.Add(new Student("Student1", "Student1", "Student1", "FKST", "KSI", "bakalavar",
                "student", "1212", "1", "3", "50", DateTime.MaxValue, DateTime.MaxValue));
            testStudents.Add(new Student("Student2", "Student2", "Student2", "FKST", "KSI", "bakalavar",
                "student", "1213", "1", "3", "50", DateTime.MaxValue, DateTime.MaxValue));
        }
    }
}
