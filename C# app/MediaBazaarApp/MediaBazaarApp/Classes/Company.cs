using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class Company
    {
        public readonly AccountManager AccountManager = new AccountManager();
        public readonly ShiftSchedule ShiftSchedule = new ShiftSchedule();
        public readonly EmployeeList ShopWorkers= new EmployeeList();
        public readonly List<Department> Departments = new List<Department>();
        public readonly List<Contract> Contracts = new List<Contract>();

        public Company()
        {
            this.Departments.Add(new Department(1, "Household"));
            this.Departments.Add(new Department(2, "Electroncis"));
            this.Departments.Add(new Department(3, "Cashiers"));
            this.Departments.Add(new Department(4, "Tools"));
            
            this.Contracts.Add(new Contract(1,true,32));
            this.Contracts.Add(new Contract(2,true,40));
            this.Contracts.Add(new Contract(3,false));

            this.ShiftSchedule.WorkShifts.Add(new WorkShift(DateTime.Now));
            this.ShiftSchedule.WorkShifts.Add(new WorkShift(DateTime.Now.AddHours(8)));
            this.ShiftSchedule.WorkShifts.Add(new WorkShift(DateTime.Now.AddHours(16)));
            this.ShiftSchedule.WorkShifts.Add(new WorkShift(DateTime.Now.AddHours(24)));
            this.ShiftSchedule.WorkShifts.Add(new WorkShift(DateTime.Now.AddHours(32)));
        }
    }
}
