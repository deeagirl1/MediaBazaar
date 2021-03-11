using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class Manager : Person
    {
        public Manager(int id, string firstName, string lastName, string email, string password) :
            base(id, firstName, lastName, email, password)
        { }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
