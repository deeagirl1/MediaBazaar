using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    class Manager : Person
    {
        public Manager(string a, string b) : base(a, b)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
