using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter faculty number");
            string fn = Console.ReadLine();

            if (StudentData.IsThereStudent(fn))
            {
                Student student = StudentData.TestStudents.Where(s => s.FacultyNumber == fn).First();
                string certificate = StudentData.PrepareCertificate(student);
                StudentData.SaveCertificate(certificate, student.Firstname + " " + student.Lastname + " " + student.FacultyNumber + ".txt");
            }
        }
    }
}
