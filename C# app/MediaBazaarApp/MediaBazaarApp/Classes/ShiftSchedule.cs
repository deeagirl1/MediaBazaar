using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class ShiftSchedule
    {
        private List<WorkShift> workShifts = new List<WorkShift>();

        public void Add(WorkShift shift)
        {
            workShifts.Add(shift);
        }

        public void Remove(WorkShift shift)
        {
            this.workShifts.RemoveAll(a => a.ID == shift.ID);
           
        }

        public void Update(WorkShift shift)
        {
            this.workShifts.Find(a => a.ID == shift.ID);
        }

        private int getShift(WorkShift shift)
        {
            foreach (WorkShift s in workShifts)
            {
                if(s.ID == shift.ID)
                {
                    return 1;
                }
            }

            return 0;
        }


        public IEnumerable<WorkShift> GetShiftsInPerioad(DateTime start, DateTime end)
        {
            foreach (WorkShift s in workShifts)
            {
                if(s.date >= start && s.date <= end)
                {
                    yield return s;
                }
               
            }
        }





        
    }
}
