using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    class Person
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;

        public override string ToString() => firstName + " " + lastName;
    }
}
