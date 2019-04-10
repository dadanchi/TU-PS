using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentRepository
{
    public class StudentValidation
    {
        public Student GetStudentDataByUser(User user)
        {
            if (string.IsNullOrEmpty(user.FacultyNumber))
            {
                throw new ArgumentException("User has no faculty number");
            }
            Student student = StudentData.TestStudents.Where(s => s.FacultyNumber == user.FacultyNumber).FirstOrDefault();
            if (null == student)
            {
                throw new ArgumentException($"Student with faculty number {user.FacultyNumber} was not found");
            }

            return student;
        }
    }
}
