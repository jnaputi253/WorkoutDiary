using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutDiary.EncryptionServices;

namespace WorkoutDiary.Models
{
    public class Person
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public Person(string username, string password)
        {
            Username = username;
            Password = EncryptionService.Encrypt(password);
        }
    }
}
