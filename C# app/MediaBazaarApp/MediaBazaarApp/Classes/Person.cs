using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    abstract class Person : IAccount 
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;

        public Person() { }

        public Person(int id, string firstName, string lastName, string email, string password)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
        }

        public int ID
        {
            get { return this._id; }
            set { this._id = value; }
        }
        public string Login
        {
            get { return this.Email; }
            set { this.Email = value; }
        }        
        public string Password
        {
            get { return this._password; }
            set { this._password= value; }
        }

        public string Email 
        {
            get { return this._email; }
            set { this._email = value; }
        }

        public string FirstName 
        {
            get { return this._firstName; }
            set { this._firstName = value; }
        }

        public string LastName
        {
            get { return this._lastName; }
            set { this._lastName = value; }
        }

        public override string ToString() => $"{this.ID} {this.FirstName} {this.LastName}";
    }
}
