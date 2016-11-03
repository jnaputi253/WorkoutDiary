using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutDiary.Database
{
    internal static class DatabaseHandler
    {
        private const string _dbDirectory = "../../../data/database/";

        internal static string GetDbDirectory()
        {
            return _dbDirectory;
        }
    }
}
