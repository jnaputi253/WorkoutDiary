using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutDiary.Models;

namespace WorkoutDiary.Database
{
    public class DbRepository
    {
        private Db _database;

        public DbRepository()
        {
            _database = new Db();
        }

        public bool ContainsUsername(string username)
        {
            return _database.ContainsUsername(username);
        }

        public void AddNewUser(Person person)
        {
            _database.InsertNewUser(person);
        }
    }
}
