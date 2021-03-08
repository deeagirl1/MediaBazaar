using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class ShopWorker : ISalary, IComparable<ShopWorker>
    {
        
        private bool nightShifts;
        private string role;
        private WorkingDays workingDays;
        private ContractType type;
        private Departments departments;
        private DateTime birthDate;
        private Address homeAddress;
        private DateTime hireTime;

        public int CompareTo(ShopWorker other)
        {
            throw new NotImplementedException();
        }

        public string GetBankAccount()
        {
            throw new NotImplementedException();
        }

        public decimal GetSalary()
        {
            throw new NotImplementedException();
        }

        public void IncreaseSalary(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void ReduceSalary(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void SetBankAccount(string account)
        {
            throw new NotImplementedException();
        }

        public void SetSalary(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
