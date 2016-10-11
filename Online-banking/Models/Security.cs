using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Online_banking.Models
{
    public class Security
    {

        public static byte[] Create_Hash(string inString)
        {
            byte[] input, output;
            SHA256 algorithm = SHA256.Create();
            input = Encoding.UTF8.GetBytes(inString);
            output = algorithm.ComputeHash(input);
            return output;
        }

        public static bool Validate_User(User user)
        {
            
            using (var db = new ModelContext())
            {

                ModelContext.User user_exist = db.Users.FirstOrDefault(u => u.personalIdentification == user.personal_Identification);
                                 
                // If result is less or more than 1 something is wrong
                if(user_exist == null)
                {
                    return false;
                }

                string salt = user_exist.salt;

                byte[] hashed_password = Create_Hash(user.password + salt);

                if (hashed_password.SequenceEqual(user_exist.password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // Created by Tor
        public static string Create_Salt()
        {
            byte[] randomArray = new byte[10];
            string randomString;

            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomArray);
            randomString = Convert.ToBase64String(randomArray);
            return randomString;
        }
    }
}