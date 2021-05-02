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
            if(ID == 1) this.Name = "Morning";
            else if(ID == 2) this.Name = "Day";
            else if(ID == 3) this.Name = "Night";

        }
        public Shift(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
}
