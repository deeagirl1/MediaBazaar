using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class Administrator : Person
    {
        public Administrator(string firstName, string lastName, string email, string username, string password) :
          base(firstName, lastName, email, username, password)
        { }
        public Administrator(int id, string firstName, string lastName, string email,string username, string password) :
            base(id, firstName, lastName, email,username, password)
        { }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
