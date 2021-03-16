using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MediaBazaarApp.Classes
{
    public class AccountManager : DBmanager
    {
        private List<IAccount> accounts;

        public AccountManager()
        {
            accounts = new List<IAccount>();
        }

        public object CheckCredentials(IAccount account)
        {
           // string sql = $"SELECT *";
            MySqlParameter[] prms = new MySqlParameter[2];

            string password = account.Password.GetHashCode().ToString();
            prms[0] = new MySqlParameter("@login", account.Login);
            prms[1] = new MySqlParameter("@password", password);

            return this.ReadScalar(sql, prms);
        }

        public Object GetStatus(IAccount account)
        {
           // string sql = "SELECT *";
            MySqlParameter[] prms = new MySqlParameter[1];
            prms[0] = new MySqlParameter("@id", account.ID);
            return this.ReadScalar(sql, prms);
        }

        public bool Add(IAccount account)
        {
            if (this.exists(account))
                return false;
            this.accounts.Add(account);
            return true;
        }
        public bool Remove(IAccount account)
        {
            this.accounts.RemoveAll(a => a.ID == account.ID);
            return true;
        }

        private bool exists(IAccount account)
        {
            foreach(IAccount a in this.accounts)
            {
                if (a.ID == account.ID) { return true; }
            }
            return false;
        }
        public IAccount isValid(string login, string password)
        {
            foreach(IAccount a in this.accounts)
            {
                if(a.Login == login &&
                    a.Password == password)
                {
                    return a;
                }
            }
            return null;
        }
    }
}
