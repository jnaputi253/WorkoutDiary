using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutDiary.Registration
{
    public class RegistrationForm
    {
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }


        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }


        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _passwordRepeat;

        public string PasswordRepeat
        {
            get { return _passwordRepeat; }
            set { _passwordRepeat = value; }
        }

        public RegistrationForm(string username, string email, string password, string passwordRepeat)
        {
            Username = username;
            Email = email;
            Password = password;
            PasswordRepeat = passwordRepeat;
        }
    }
}
