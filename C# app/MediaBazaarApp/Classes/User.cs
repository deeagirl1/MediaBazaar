
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class User : Person
    {
        public User(int id, string firstName, string lastName, string email) : base(id, firstName, lastName, email)
        {
            

        }
        public User(int id, string firstName, string lastName) : base(id,firstName,lastName)
        {
            

        }
        public User(int id, string firstName, string lastName, int accessLevel) : base(id,firstName,lastName,accessLevel)
        {

            

        }
        public User(string firstName, string lastName, string email, string username, string password) : base(firstName, lastName, email, username, password)
        { }
        
        public User(string firstName, string lastName, string email) : base(firstName,lastName,email)
        {

            
        }
        public User(int id, string firstName, string lastName, string email, string username, string password) : base(id,firstName,lastName,email,username,password)
        {
          
        }
        public override string ToString() => $"{this.ID} {this.FirstName} {this.LastName}";
    }
}

