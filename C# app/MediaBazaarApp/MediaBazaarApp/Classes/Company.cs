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
    }
}
