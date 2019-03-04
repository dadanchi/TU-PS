using System;

namespace StudentRepository
{
    public class Student
    {
        public Student(string firstname, string middlename, string lastname, string faculty, string specialty, 
            string educationLevel, string status, string facultyNumber, string course, string stream, 
            string group, DateTime authenticationDueDate, DateTime finalPaymentDueDate)
        {
            Firstname = firstname;
            Middlename = middlename;
            Lastname = lastname;
            Faculty = faculty;
            Specialty = specialty;
            EducationLevel = educationLevel;
            Status = status;
            FacultyNumber = facultyNumber;
            Course = course;
            Stream = stream;
            Group = group;
            AuthenticationDueDate = authenticationDueDate;
            FinalPaymentDueDate = finalPaymentDueDate;
        }

        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Faculty { get; set; }
        public string Specialty { get; set; }
        public string EducationLevel { get; set; }
        public string Status { get; set; }
        public string FacultyNumber { get; set; }
        public string Course { get; set; }
        public string Stream { get; set; }
        public string Group { get; set; }
        public DateTime AuthenticationDueDate { get; set; }
        public DateTime FinalPaymentDueDate { get; set; }
    }
}
