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
        public Shift Shift { get; set; }
        public DateTime date { get; set; }
        public int Day { get => date.Day; }
        public int Month { get => date.Month; }
        public int Year { get => date.Year; }
        public List<ShopWorker> ShopWorkers { get; set; }
                                 = new List<ShopWorker>();


        public WorkShift(DateTime time, Shift shift)
        {
            Shift = shift;
            date = time;
        }
        
        public int CompareTo(WorkShift other)
        {
            if (this.date > other.date) return 1;
            else if (this.date < other.date) return -1;
            else return 0;
        }


        /// <summary>
        /// Shows a new window where you can edit the WorkShift object
        /// </summary>
        public void ShowDialog()
        {

        }
    }
}
