using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Online_banking.Models
{
    public class Sikkerhet
    {

        private static byte[] Create_Hash(string inString)
        {
            byte[] input, output;
            SHA256 algorithm = SHA256.Create();
            input = Encoding.UTF8.GetBytes(inString);
            output = algorithm.ComputeHash(input);
            return output;
        }

        public bool Validate_User(User user)
        {

            using (var db = new ModelContext())
            {
                var isValid = from u in db.Users
                              where u.personalIdentification == user.personal_Identification
                              && u.password == user.password
                              select u;

                if (!isValid.Any())
                {
                    return false;
                }

                else
                {
                    return true;
                }
            }
        }
    }
}