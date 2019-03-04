using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        private static List<User> testUsers = new List<User>(3);

        public static List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return testUsers;
            }
        }

        public static User IsUserPassCorrect(string username, string password)
        {            
            User user = TestUsers.Where(u => u.UserName.Equals(username) && u.Password.Equals(password)).FirstOrDefault();
            if(null != user)
            {
                Logger.LogActivity("Login successful");
            }

            return user;
        }

        public static void SetUserActiveTo(int id, DateTime validDate)
        {
            testUsers[id].ValidTo = validDate;
            Logger.LogActivity("Validation date changed for user " + testUsers[id].UserName);
        }

        public static void AssignUserRole(int id, UserRoles role)
        {
            testUsers[id].Role = (int)role;
            Logger.LogActivity("Role changed for user " + testUsers[id].UserName);
        }

        public static Dictionary<string, int> AllUsersUsernames()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            for (int i = 0; i < testUsers.Count; i++)
            {
                result.Add(testUsers[i].UserName, i);
            }

            return result;
        }

        private static void ResetTestUserData()
        {
            testUsers.Clear();

            testUsers.Add(new User("Admin", "Admin123", "123456", 1));
            testUsers.Add(new User("Student1", "Student1", "123457", (int)UserRoles.STUDENT));
            testUsers.Add(new User("Student2", "Student2", "123458", (int)UserRoles.STUDENT));

            foreach (var user in testUsers)
            {
                user.Created = DateTime.Now;
                user.ValidTo = DateTime.MaxValue;
            }
        }
    }
}
