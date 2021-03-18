using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public abstract class Person : IAccount 
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int AccessLevel { get; set; }

        
        public Person() { }
        public Person(int id, string firstName, string lastName,string email) 
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }
        public Person(int id, string firstName, string lastName, string email,string username, string password)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
        }
        public override string ToString() => $"{this.ID} {this.FirstName} {this.LastName}";
    }
}
