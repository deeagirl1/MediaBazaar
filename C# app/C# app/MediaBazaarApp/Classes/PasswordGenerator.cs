using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public static class PasswordGenerator
    {
        public static string GeneratePassword()
        {
            int lenght = 8;
            char[] passwordGenerated = new char[lenght];
            Random rand = new Random();

            for (int i = 0; i < lenght; i++)
            {
                var passCharacter = rand.Next(65, 91);
                passwordGenerated[i] = (char)passCharacter;
            }
            var finishedPassword = new String(passwordGenerated);
            return finishedPassword;
        }
    }
}
