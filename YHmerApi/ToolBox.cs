using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public static class ToolBox
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string GenerateCode()
        {
            var rng = new Random();
            string idString = "";
            for (int i = 0; i < 2; i++)
            {
                int a = rng.Next(0, 26);
                char ch = (char)('A' + a);
                idString += ch;
            }

            for (int i = 0; i < 8; i++)
            {
                int a = rng.Next(0, 9);
                char ch = (char)('1' + a);
                idString += ch;
            }
            return idString;
        }
    }
}
