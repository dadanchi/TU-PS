using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public User(string username, string password, string facultyNumber, int role)
        {
            this.UserName = username;
            this.Password = password;
            this.FacultyNumber = facultyNumber;
            this.Role = role;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string FacultyNumber { get; set; }
        public int Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
