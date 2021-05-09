using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
     public class Cashier : Person
    {
        public Cashier(string firstName, string lastName, string email) :
        base(firstName, lastName, email)
        { }
        public Cashier(string firstName, string lastName, string email, string username, string password) :
          base(firstName, lastName, email, username, password)
        { }
        public Cashier(int id, string firstName, string lastName, string email, string username, string password) :
            base(id, firstName, lastName, email, username, password)
        { }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
