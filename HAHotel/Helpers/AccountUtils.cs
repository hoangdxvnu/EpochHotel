using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;

namespace HAHotel.Helpers
{
    public class AccountUtils
    {
        public static string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        public static bool VerifyPassword(string hashedPassword, string password)
        {
            return Crypto.VerifyHashedPassword(hashedPassword, password);
        }
    }
}