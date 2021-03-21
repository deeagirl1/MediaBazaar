using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Department(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
