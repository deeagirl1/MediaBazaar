using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class ShopWorker : Person, ISalary, IComparable<ShopWorker>
    {
        public WorkingDays WorkingDays { get; set; }
        public Departments Department { get; set; }
        public Address HomeAddress { get; set; }
        public DateTime BirthDate { get; set; }
        public string BankAccount { get; set; }
        public DateTime HireTime { get; set; }
        public ContractType Contract { get; set; }
        public bool NightShifts { get; set; }
        public decimal HourlyWage { get; set; }
        public string Role { get; set; }

        public ShopWorker(int id, string firstName, string lastName, string email, string password) :
            base(id, firstName, lastName, email, password)
        { }

        public ShopWorker(int id, string firstName, string lastName, string email, string password,
            WorkingDays WorkingDays, Departments Department, Address HomeAddress, DateTime BirthDate,
            string BankAccount, DateTime HireTime, ContractType Contract, bool NightShifts, decimal HourlyWage, string Role) :
            base(id, firstName, lastName, email, password)
        {
            this.WorkingDays = WorkingDays;
            this.Department = Department;
            this.HomeAddress = HomeAddress;
            this.BirthDate = BirthDate;
            this.BankAccount = BankAccount;
            this.HireTime = HireTime;
            this.Contract = Contract;
            this.NightShifts = NightShifts;
            this.HourlyWage = HourlyWage;
            this.Role = Role;

        }

        void ISalary.Increase(decimal amount)
        {
            if (amount > 0)
                this.HourlyWage += amount;
        }

        void ISalary.Reduce(decimal amount)
        {
            if (amount > 0)
                this.HourlyWage += amount;
        }

        public int CompareTo(ShopWorker other)
        {
            throw new NotImplementedException();
        }

        
    }
}
