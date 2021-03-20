using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class Shift
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Shift(int ID)
        {
            this.ID = ID;
            this.Name = Name;
        }
        public Shift(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
}
