using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class Contract
    {
        public int ID { get; set; }
        public bool Fixed { get; set; }
        private int hours;
        public int ShiftsCount
        {
            get { if (Fixed == true) return this.hours / 8; else { return 5; }; }
        }
        public int Hours
        {
            get { return this.hours; }
            set { if (this.Fixed) this.hours = value; else this.hours = 0;}
        }
        public Contract(int ID,bool Fixed, int Hours)
        {
            this.ID = ID;
            this.Fixed = Fixed;
            this.Hours = Hours;
        }

        public override string ToString()
        {
            if (this.Fixed)
                return $"FIXED {this.hours}";
            else
                return $"ZERO HOUR";
        }
    }
}
