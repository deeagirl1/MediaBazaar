using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    class Administrator : Person
    {
        public Administrator(string firstName, string secondName) : base (firstName, secondName)
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
