using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    interface IAccount
    {
        int GetId();
        void SetId(int id);
        string GetLogin();
        void SetLogin(string login);
        string GetPassword();
        void SetPassword(string password);
    }
}
