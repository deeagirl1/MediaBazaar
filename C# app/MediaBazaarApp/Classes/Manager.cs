using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class Manager : Person
    {
        public Manager(string firstName, string lastName, string email) :
           base(firstName, lastName, email)
        { }
        public Manager(int id,string firstName, string lastName) :
         base(id,firstName, lastName)
        { }
        public Manager(int id, string firstName, string lastName, string email,string username, string password) :
            base(id, firstName, lastName, email, username, password)
        { }
        public Manager(string firstName, string lastName) :
           base(firstName, lastName)
        { }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
