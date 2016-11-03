using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutDiary.Database
{
    public class DatabaseCreator
    {
        private string _dbDirectory = "../../../data/database";

        internal string GetDbDirectory()
        {
            return _dbDirectory;
        }

        public void CreateDbDirectory()
        {
            if(!Directory.Exists(_dbDirectory))
            {
                Directory.CreateDirectory(_dbDirectory);
                DirectoryInfo info = new DirectoryInfo(_dbDirectory);
                HideDirectory(info);

                info = new DirectoryInfo(_dbDirectory);
                HideDirectory(info);
            }
            
            CheckIfDbFilesExist();
            CreateDatabases();
        }

        private void HideDirectory(DirectoryInfo info)
        {
            if ((info.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
            {
                info.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }
        }

        private void CheckIfDbFilesExist()
        {
            if (!File.Exists($"{_dbDirectory}/User.db3"))
            {
                File.Create($"{_dbDirectory}/User.db3");
            }

            if (!File.Exists($"{_dbDirectory}/WorkoutLog.db3"))
            {
                File.Create($"{_dbDirectory}/WorkoutLog.db3");
            }
        }

        private void CreateDatabases()
        {
            CreateUserDb();
            CreateWorkoutLogDb();
        }

        private void CreateUserDb()
        {
            string query = @"CREATE TABLE IF NOT EXISTS User (
                            Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            Username NVARCHAR(100) NULL,
                            Password NVARCHAR(100) NULL)";
            InitializeDb(query, "User.db3");
        }

        private void CreateWorkoutLogDb()
        {
            string query = @"CREATE TABLE IF NOT EXISTS WorkoutLog (
                            Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            Username NVARCHAR(100) NULL,
                            Workout NVARCHAR(100) NULL,
                            WorkoutLength INTEGER NULL,
                            CaloriesBurned INTEGER NULL,
                            AverageHeartRate INTEGER NULL,
                            Date DATETIME)";
            InitializeDb(query, "WorkoutLog.db3");
        }

        private void InitializeDb(string query, string dbFile)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection($"data source={_dbDirectory}/{dbFile};New=True; Version=3"))
                {
                    connection.Open();
                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
