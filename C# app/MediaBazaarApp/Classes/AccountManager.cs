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
                case 4:
                    return new DepotWorker(ID, FirstName, LastName, Email, username, Password);
                case 5:
                    return new Cashier(ID, FirstName, LastName, Email, username, Password);
                case 6:
                    return new DepartmentManager(ID, FirstName, LastName, Email, username, Password);
            }
            throw new ArgumentException("Invalid credentials supplied");
        }

        public void ChangePassword(string username, string currentPass, string newPass)
        {
            string sql = " UPDATE person SET Password=@Password WHERE Username = @Username; ";

            MySqlParameter[] prms = new MySqlParameter[2];

            prms[0] = new MySqlParameter("@Password", newPass);
            prms[1] = new MySqlParameter("@Username",username);

            if(this.IsValid(username,currentPass)!=null)
                this.ExecuteQuery(sql, prms);
        }

        public string Add(Person person)
        {
            string sql = " INSERT INTO person(FirstName, LastName, Email, Username, Password, AccessLevel) " +
                         " VALUES (@FirstName, @LastName, @Email, @Username, @Password, @AccessLevel); ";

            string pass = PasswordGenerator.GeneratePassword();

            MySqlParameter[] prms = new MySqlParameter[6];

            int accessLevel = 0;
            if (person is Administrator)
                accessLevel = 2;
            if (person is Manager)
                accessLevel = 3;
            if (person is DepotWorker)
                accessLevel = 4;
            if (person is Cashier)
                accessLevel = 5;
            if (person is DepartmentManager)
                accessLevel = 6;

            prms[0] = new MySqlParameter("@FirstName", person.FirstName);
            prms[1] = new MySqlParameter("@LastName", person.LastName);
            prms[2] = new MySqlParameter("@Email", person.Email);
            prms[3] = new MySqlParameter("@Username", person.Email);
            prms[4] = new MySqlParameter("@Password", pass);
            prms[5] = new MySqlParameter("@AccessLevel", accessLevel);

            this.ExecuteQuery(sql, prms);

            return pass;
        }

        public void Update(Person person)
        {
            string sql = " UPDATE person SET FirstName = @FirstName, LastName = @LastName, Email = @Email, AccessLevel = @AccessLevel" +
                         " WHERE ID = @ID ";
          

            MySqlParameter[] prms = new MySqlParameter[5];

            int accessLevel = 0;
            if (person is Administrator)
                accessLevel = 2;
            if (person is Manager)
                accessLevel = 3;
            if (person is DepotWorker)
                accessLevel = 4;
            if (person is Cashier)
                accessLevel = 5;
            if (person is DepartmentManager)
                accessLevel = 6;

            prms[0] = new MySqlParameter("@FirstName", person.FirstName);
            prms[1] = new MySqlParameter("@LastName", person.LastName);
            prms[2] = new MySqlParameter("@Email", person.Email);
            prms[3] = new MySqlParameter("@AccessLevel", accessLevel);
            prms[4] = new MySqlParameter("@ID", person.ID);

            this.ExecuteQuery(sql, prms);

           
        }

        public List<User> GetAllUsers()
        {
            string sql = $"SELECT p.ID, p.FirstName, p.LastName, p.AccessLevel, p.Email " +
                         $"FROM person p " +
                         $"WHERE p.AccessLevel = 2 OR p.AccessLevel = 3 OR p.AccessLevel = 4 OR p.AccessLevel = 5 OR p.AccessLevel = 6; ";
         
            MySqlCommand cmd = new MySqlCommand(sql, this.GetConnection());
            MySqlDataReader reader = null;
            
            List<User> users = new List<User>();
            try
            {
                reader = this.OpenExecuteReader(cmd);
                while (reader.Read())
                {
                    User user = new User(Convert.ToInt32(reader["ID"]),
                        Convert.ToString(reader["FirstName"]),
                        Convert.ToString(reader["LastName"]),
                        Convert.ToInt32(reader["AccessLevel"]),
                        Convert.ToString(reader["Email"]));
                        
                    users.Add(user);

                }
            }
            finally
            {
                this.CloseExecuteReader(reader);
            }
            return users;
        }


        
    }
}
