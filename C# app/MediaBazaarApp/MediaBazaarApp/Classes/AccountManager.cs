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

        public void ChangePassword(Person person)
        {
            string sql = " UPDATE person SET Password=@Password, WHERE ID = @ID; ";

            MySqlParameter[] prms = new MySqlParameter[2];

            prms[0] = new MySqlParameter("@Password", person.Password);
            prms[1] = new MySqlParameter("@ID",person.ID);

            this.ExecuteQuery(sql, prms);
        }

        public void Add(Person person)
        {
            string sql = " INSERT INTO person(FirstName, LastName, Email, Username, Password, AccessLevel) " +
                         " VALUES (@FirstName, @LastName, @Email, @Username, @Password, @AccessLevel); ";

            MySqlParameter[] prms = new MySqlParameter[4];

            int accessLevel = 0;
            if (person is Administrator)
                accessLevel = 1;
            if (person is Manager)
                accessLevel = 2;

            prms[0] = new MySqlParameter("@FirstName", person.FirstName);
            prms[1] = new MySqlParameter("@LastName", person.LastName);
            prms[2] = new MySqlParameter("@Email", person.Email);
            prms[3] = new MySqlParameter("@Username", person.Username);
            prms[4] = new MySqlParameter("@Password", person.Password);
            prms[5] = new MySqlParameter("@AccessLevel", accessLevel);

            this.ExecuteQuery(sql, prms);
        }
    }
}
