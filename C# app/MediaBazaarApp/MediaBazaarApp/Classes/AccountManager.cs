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

        public Object GetStatus(IAccount account)
        {
            string sql = "SELECT *";
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
        public Person IsValid(string username, string password)
        {
            string sql = $"SELECT * FROM PERSON WHERE Username = @username AND Password = @password";

            MySqlCommand cmd = new MySqlCommand(sql, this.GetConnection());
            MySqlDataReader reader = null;

            cmd.Parameters.Add(new MySqlParameter("@username", username));
            cmd.Parameters.Add(new MySqlParameter("@password", password));

            int ID = 0;
            string FirstName = "";
            string LastName = "";
            string Email = "";
            string Username = "";
            string Password = "";
            int AccessLevel = 0;

            try
            {
                reader = this.OpenExecuteReader(cmd);

                while (reader.Read())
                {
                    ID = (Convert.ToInt32(reader["ID"]));
                    FirstName = (Convert.ToString(reader["FirstName"]));
                    LastName = (Convert.ToString(reader["LastName"]));
                    Email = (Convert.ToString(reader["Email"]));
                    Username = (Convert.ToString(reader["Username"]));
                    Password = (Convert.ToString(reader["Password"]));
                    AccessLevel = (Convert.ToInt32(reader["AccessLevel"]));
                }
            }
            finally
            {
                this.CloseExecuteReader(reader);
            }

            switch (AccessLevel) 
            {
                case 2:
                    return new Administrator(ID, FirstName, LastName, Email, Username, Password);
                case 3:
                    return new Manager(ID, FirstName, LastName, Email, Username, Password);
            }
            throw new ArgumentException("Invalid credentials supplied");
        }
    }
}
