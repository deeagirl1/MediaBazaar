using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes.Person
{
    interface IAccount
    {
        string GetLogin();
        void SetLogin(string login);
        string GetPassword();
        void SetPassword(string password);
    }
}
