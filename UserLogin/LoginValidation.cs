using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        private string username;
        private string password;
        private string errorMessage;
        private ActionOnError actionOnError;

        public delegate void ActionOnError(string errorMsg);

        public LoginValidation(string username, string password, ActionOnError actionOnError)
        {
            this.username = username;
            this.password = password;
            this.actionOnError = actionOnError;
        }

        public static UserRoles CurrentUserRole { get; private set;}
        public static string CurrentUserName { get; private set; }

        public bool ValidateUserInput(ref User user)
        {
            CurrentUserName = "";

            if (username.Equals(string.Empty))
            {
                errorMessage = "Username is not provided";
                CurrentUserRole = UserRoles.ANONYMOUS;
                actionOnError(errorMessage);
                return false;
            }
            if(username.Length < 5)
            {
                errorMessage = "Username must be at least 5 symbols";
                CurrentUserRole = UserRoles.ANONYMOUS;
                actionOnError(errorMessage);
                return false;
            }
            if(password.Equals(string.Empty))
            {
                errorMessage = "Password is not provided";
                CurrentUserRole = UserRoles.ANONYMOUS;
                actionOnError(errorMessage);
                return false;
            }
            if (password.Length < 5)
            {
                errorMessage = "Password must be at least 5 symbols";
                CurrentUserRole = UserRoles.ANONYMOUS;
                actionOnError(errorMessage);
                return false;
            }

            user = UserData.IsUserPassCorrect(username, password);
            if (null == user)
            {
                errorMessage = "Не е намерен такъв потребител";
                CurrentUserRole = UserRoles.ANONYMOUS;
                actionOnError(errorMessage);
                return false;
            }

            CurrentUserRole = (UserRoles)user.Role;
            CurrentUserName = user.UserName;
            return true;
        }
    }
}
