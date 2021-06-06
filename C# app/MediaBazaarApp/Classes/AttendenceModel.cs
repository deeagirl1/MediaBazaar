using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class AttendenceModel
    {
        public ShopWorker  Employee {get;set;}
        public Nullable<DateTime> CheckIn {get;set;}
        public Nullable<DateTime> CheckOut {get;set;}

        public AttendenceModel(ShopWorker employee, Nullable<DateTime> checkIn, Nullable<DateTime> checkOut)
        {
            Employee = employee;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }
    }
}
