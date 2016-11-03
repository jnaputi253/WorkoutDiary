/// Class Name: RegistrationValidation.cs
/// Purpose: to validate the user inputs from the RegistrationWindow.  The functions will call
/// the appropriate repository function to validate the input.
/// Based on the comparison, the appropriate string value will be returned to be displayed to the user
/// indicating whether it was a success, or what type of issue occurred.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WorkoutDiary.Database;
using WorkoutDiary.Models;

namespace WorkoutDiary.Registration
{
    public class RegistrationValidation
    {
        private bool _usernameValid;
        private bool _passwordValid;
        private bool _passwordsMatch;
        private string _regex;
        private DbRepository _dbRepository;

        public RegistrationValidation()
        {
            _usernameValid = false;
            _passwordValid = false;
            _passwordsMatch = false;
            _regex = string.Empty;
            _dbRepository = new DbRepository(); 
        }

        public string IsValidUsername(string username)
        {
            // Last time I saw regex was in Summer quarter on regex assignment ;-;
            _regex = "^(?=.{5,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$";

            if(Regex.IsMatch(username, _regex))
            {
                // See if the username already exists.
                if(!_dbRepository.ContainsUsername(username))
                {
                    _usernameValid = true;

                    return "OK";
                }
                else
                {
                    _usernameValid = false;
                    return "The username is taken";
                }
            }
            else
            {
                _usernameValid = false;

                if(username.Length < 5 || username.Length > 20)
                {
                    return "Username must be 5 to 20 characters long";
                }
                else
                {
                    return "Invalid username";
                }
            }
        }

        public string IsValidPassword(string password)
        {
            _regex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&_])[A-Za-z\d$@$!%*?&]{8,20}";

            if(Regex.IsMatch(password, _regex))
            {
                _passwordValid = true;

                return "OK";
            }
            else
            {
                _passwordValid = false;

                if(password.Length < 8 || password.Length > 20)
                {
                    return "Must be 8 to 20 characters long";
                }
                else
                {
                    return "Must contain one uppercase letter, a special character, and a number";
                }
            }
        }

        public string PasswordsMatch(string password, string repeatPassword)
        {
            if(password.Equals(repeatPassword))
            {
                _passwordsMatch = true;

                return "OK";
            }
            else
            {
                _passwordsMatch = false;

                return "Passwords do not match";
            }
        }

        public bool ReleaseRegistrationButton()
        {
            if(_usernameValid && _passwordValid && _passwordsMatch)
            {
                return true;
            }

            return false;
        }

        public void AddUser(string username, string password)
        {
            var person = new Person(username, password);
            _dbRepository.AddNewUser(person);
        }
    }
}
