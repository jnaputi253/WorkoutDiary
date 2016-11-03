using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutDiary;
using System.Data.SQLite;
using WorkoutDiary.Models;

namespace WorkoutDiary.Database
{
    public class Db
    {
        private string _dbDirectory;
        private const string USER_DB = "User.db3";
        private const string WORKOUT_LOG_DB = "WorkoutLog.db3";

        public Db()
        {
            // _dbDirectory = $"{dbDirectory}/../../../data/database/";
            _dbDirectory = DatabaseHandler.GetDbDirectory();
        }

        public bool ContainsUsername(string username)
        {
            string query = @"SELECT Username FROM User WHERE Username=?";
            string data = string.Empty;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"data source={_dbDirectory}/{USER_DB};New=True; Version=3"))
                {
                    connection.Open();

                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        var parameter = new SQLiteParameter(username);
                        command.Parameters.Add(parameter);

                           data = (string)command.ExecuteScalar();
                    }

                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return data != null;
        }

        public void InsertNewUser(Person person)
        {
            string query = $@"INSERT INTO User (Username, Password) VALUES ('{person.Username}', '{person.Password}')";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"data source={_dbDirectory}/{USER_DB};New=True;Vewsion=3"))
                {
                    connection.Open();

                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
