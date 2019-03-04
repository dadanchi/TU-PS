using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class Program
    {
        static void printError(string message)
        {
            Console.WriteLine("Error: " + message);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Username:");
            string username = "Admin";//Console.ReadLine();
            Console.WriteLine("Password:");
            string password = "Admin123";//Console.ReadLine();
            LoginValidation validator = new LoginValidation(username, password, printError);
            User user = null;
            if (validator.ValidateUserInput(ref user))
            {
                Console.WriteLine("Username: {0}, Password: {1}, FN: {2}, RoleCode: {3}", user.UserName, user.Password, user.FacultyNumber, user.Role);
                switch (LoginValidation.CurrentUserRole)
                {
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("Current user is logged as Anonymous");
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("Current user is inspecting");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("Current user is a professor");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("Current user is a student");
                        break;
                    case UserRoles.ADMIN:
                        Console.WriteLine("An admin has logged");
                        ControlAdminPanel();
                        break;
                }
            }
        }

        private static void ControlAdminPanel()
        {
            Console.WriteLine("Choose:");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Change user's role");
            Console.WriteLine("2: Change user's validation date");
            Console.WriteLine("3: View all users");
            Console.WriteLine("4: View log activity");
            Console.WriteLine("5: View CUrrent session log activity");
            int command;
            var allUsers = UserData.AllUsersUsernames();
            while ((command = int.Parse(Console.ReadLine())) != 0)
            {
                switch (command)
                {
                    case 1:
                        Console.WriteLine("Enter username");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter role value");
                        int role = int.Parse(Console.ReadLine());
                        UserData.AssignUserRole(allUsers[username], (UserRoles)role);
                        break;
                    case 2:
                        Console.WriteLine("Enter username");
                        username = Console.ReadLine();
                        Console.WriteLine("Enter validation date");
                        DateTime validationDate = DateTime.Parse(Console.ReadLine());
                        UserData.SetUserActiveTo(allUsers[username], validationDate);
                        break;
                    case 3:
                        foreach (var user in allUsers)
                        {
                            Console.WriteLine(user.Key);
                        }
                        break;
                    case 4:
                        using (StreamReader reader = new StreamReader(Path.Combine(Environment.CurrentDirectory, @"..\..\test.txt")))
                        {
                            StringBuilder builder = new StringBuilder();
                            string line;
                            while((line = reader.ReadLine()) != null)
                            {
                                builder.AppendLine(line);
                            }

                            Console.WriteLine(builder.ToString());
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter filter");
                        string filter = Console.ReadLine();
                        Console.WriteLine(Logger.GetCurrentSessionActivities(filter));
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Choose:");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Change user's role");
                Console.WriteLine("2: Change user's validation date");
                Console.WriteLine("3: View all users");
                Console.WriteLine("4: View log activity");
                Console.WriteLine("5: View CUrrent session log activity");
            }
        }
    }
}