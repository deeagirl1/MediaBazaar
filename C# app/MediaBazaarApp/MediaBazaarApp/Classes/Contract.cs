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

        public int Hours
        {
            get { return this.hours; }
            set { if (this.Fixed) this.hours = value; else this.hours = 0;}
        }

        public Contract(int ID, bool Fixed)
        {
            this.ID = ID;
            this.Fixed = Fixed;
            this.Hours = 0;
        }


        public Contract(int ID,bool Fixed, int Hours)
        {
            this.ID = ID;
            this.Fixed = Fixed;
            this.Hours = Hours;
        }


    }
}
