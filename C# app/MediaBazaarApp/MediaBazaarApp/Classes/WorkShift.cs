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
        public DateTime Date { get; set; }
        public int Day { get => Date.Day; }
        public int Month { get => Date.Month; }
        public int Year { get => Date.Year; }
        public List<ShopWorker> ShopWorkers { get; set; }
                                 = new List<ShopWorker>();
        private Popups.WorkShiftWindow window;

        public WorkShift(DateTime time, Shift shift)
        {
            Shift = shift;
            Date = time;
        }
        
        public int CompareTo(WorkShift other)
        {
            if (this.Date > other.Date) return 1;
            else if (this.Date < other.Date) return -1;
            else return 0;
        }


        /// <summary>
        /// Shows a new window where you can edit the WorkShift object
        /// </summary>
        public void ShowDialog()
        {
            if(window==null)
            {
                window = new Popups.WorkShiftWindow(this);
            }
            window.Show();
        }
    }
}
