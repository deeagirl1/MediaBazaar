using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    interface ISalary
    {
        decimal HourlyWage{ get; set; }
        string BankAccount { get; set; }
        void Increase(decimal amount);
        void Reduce(decimal amount);
       
    }
}
