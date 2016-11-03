using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace WorkoutDiary.EncryptionServices
{
    public static class EncryptionService
    {
        public static string Encrypt(string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);
            byte[] hashedData;

            using (SHA512 sha = new SHA512Managed())
            {
                hashedData = sha.ComputeHash(data);
            }

            return Encoding.UTF8.GetString(hashedData).Trim();
        }
    }
}
