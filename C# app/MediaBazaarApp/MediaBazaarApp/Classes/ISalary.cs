using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    interface ISalary
    {
        decimal GetSalary();
        void SetSalary(decimal amount);
        void IncreaseSalary(decimal amount);
        void ReduceSalary(decimal amount);
        string GetBankAccount();
        void SetBankAccount(string account)
    }
}
