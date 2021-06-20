using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class AutoScheduler
    {
        private ShiftSchedule schedule;
        private EmployeeList employeeList;
        public AutoScheduler()
        {
            this.schedule = new ShiftSchedule();
            this.employeeList = new EmployeeList();
        }
        public void Schedule(DateTime start, DateTime end, int amount)
        {
            foreach (DateTime dateTime in this.eachShiftTime(start, end))
            {
                if (this.schedule.ShiftExists(dateTime) != null)
                {
                    WorkShift w = this.schedule.ShiftExists(dateTime);
                    this.assignEmployees(w, amount);
                    this.schedule.Update(w);
                }
                else
                {
                    WorkShift w = this.schedule.GetWorkShift(dateTime);
                    this.assignEmployees(w, amount);
                    this.schedule.Add(w);
                }
            }
        }

        private IEnumerable<DateTime> eachShiftTime(DateTime from, DateTime thru)
        {
            TimeSpan start = new TimeSpan(7, 0, 0);
            TimeSpan end = new TimeSpan(23, 0, 0);
            from = from.Date + start;
            thru = thru.Date + end;
            for (var dayTime = from; dayTime <= thru; dayTime = dayTime.AddHours(8))
                yield return dayTime;
        }
        private void assignEmployees(WorkShift workShift, int amount)
        {
            List <ShopWorker> people = this.employeeList.GetAvailiableEmployees(workShift);
            int limit = 0;
            if (people.Count < amount)
                limit = people.Count;
            else limit = amount;
            for(int i = 0; i<limit; i++)
            {
                workShift.AssignedEmployees.Add(people[i]);
            }
        }
    }
}
