using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public abstract class Person : IAccount 
    {
        public int ID { get; set; }
        private string firstName;
        private string lastName;
        private string email;
        public string Password { get; set; }
        public string Username { get; set; }
        public int AccessLevel { get; set; }
        public string FirstName
        {
            get { return this.firstName; }
            set 
            {
                if (Regex.IsMatch(value, @"^.*[a-zA-Z]$"))
                    this.firstName = value;
                else throw new ArgumentException("Only letters allowed.");
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set 
            {
                if (Regex.IsMatch(value, @"^.*[a-zA-Z]$"))
                    this.lastName = value;
                else throw new ArgumentException("Only letters allowed.");
            }
        }
        public string Email
        {
            get { return this.email; }
            set 
            {
                if (Regex.IsMatch(value, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                    this.email = value;
                else throw new ArgumentException("Invalid email format.");
            }
        }
        public Person() { }
        public Person(int id, string firstName, string lastName,string email) 
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }
        public Person(string firstName, string lastName, string email, string username, string password)
        {

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.Username = username;
        }
        public Person(int id, string firstName, string lastName, string email,string username, string password)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.Username = username;
        }
        public override string ToString() => $"{this.ID} {this.FirstName} {this.LastName}";
    }
}
