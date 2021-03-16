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
        public List<WorkShift> WorkShifts { get => workShifts; }

        public void Add(WorkShift shift) { workShifts.Add(shift); }

        public void Remove(WorkShift shift)
        {
            this.workShifts.RemoveAll(a => a.ID == shift.ID);
        }

        public void Update(WorkShift shift)
        {
            int index = getShift(shift);
            if (index != -1)
                this.workShifts[index] = shift;
        }

        private int getShift(WorkShift shift)
        {
            for(int i = 0; i < this.workShifts.Count; i++)
            {
                if (workShifts[i].ID == shift.ID)
                    return i;
            }
            return -1;
        }

        public IEnumerable<WorkShift> GetShiftsInPerioad(DateTime start, DateTime end)
        {
            foreach (WorkShift s in workShifts)
            {
                if (s.Date >= start && s.Date <= end)
                {
                    yield return s;
                }
            }
        }
    }
}
