using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class WorkShift : IComparable<WorkShift>
    {
        public int ID { get; set; }
        public Shift shift { get; set; }
        public DateTime date { get; set; }
        public List<ShopWorker> AssignedEmployees { get; set; }
        public WorkShift(DateTime date, Shift shift)
        {
            this.ID = ID;
            this.date = date;
            this.shift = shift;
            this.AssignedEmployees = new List<ShopWorker>();
        }

        public WorkShift(int ID, DateTime date, Shift shift)
        {
            this.ID = ID;
            this.date = date;
            this.shift = shift;
            this.AssignedEmployees = new List<ShopWorker>();
        }
        public int CompareTo(WorkShift other)
        {
            if (this.date > other.date) return 1;
            else if (this.date < other.date) return -1;
            else return 0;
        }
        public override string ToString()
        {
            string a = "";
            foreach (ShopWorker s in this.AssignedEmployees)
            {
                a = a + $"{s.ID} {s.FirstName}";
            }
            return ($"{this.ID}" + a);
        }
    }
}
