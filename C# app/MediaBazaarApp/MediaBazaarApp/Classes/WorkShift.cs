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


        /// <summary>
        /// MUST FIX DONT USE THIS CONSTRUCTOR, USE THE ONE WITH 2 PARAMETERS
        /// </summary>
        /// <param name="time"></param>
        public WorkShift(DateTime time)
        {
            if (time.TimeOfDay.Hours >= 8 && time.TimeOfDay.Hours < 16)
            {
                Shift = Shift.MORNING;
            }
            else
            {
                if (time.TimeOfDay.Hours >= 16 && time.TimeOfDay.Hours < 24)
                {
                    Shift = Shift.DAY;
                }
                else
                {
                    if (time.TimeOfDay.Hours <= 0 && time.TimeOfDay.Hours < 8)
                    {
                        Shift = Shift.NIGHT;
                    }
                }
            }
            date = time;
        }
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
    }
}
