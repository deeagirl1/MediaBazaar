using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class ShopWorker : Person, ISalary, IComparable<ShopWorker>
    {
        public Department WorksAt { get; set; }
        public Address HomeAddress { get; set; }
        public DateTime BirthDate { get; set; }
        public string BankAccount { get; set; }
        public DateTime HireTime { get; set; }  
        public ContractType Contract { get; set; }
        public bool NightShifts { get; set; }
        public decimal HourlyWage { get; set; }

        public ShopWorker() { }

        public ShopWorker(int id, string firstName, string lastName, string email, DateTime birthDate, DateTime hireDate) : base (id, firstName, lastName, email)
        {
            this.BirthDate = birthDate;
            this.HireTime = hireDate;
        }
        public ShopWorker(int id, string firstName, string lastName, string email, string password) :
            base(id, firstName, lastName, email, password)
        { }

        public ShopWorker(int id, string firstName, string lastName, string email, string password,
            Department Department, Address HomeAddress, DateTime BirthDate,
            string BankAccount, DateTime HireTime, ContractType Contract, bool NightShifts, decimal HourlyWage, string Role) :
            base(id, firstName, lastName, email, password)
        {
            this.WorksAt = Department;
            this.HomeAddress = HomeAddress;
            this.BirthDate = BirthDate;
            this.BankAccount = BankAccount;
            this.HireTime = HireTime;
            this.Contract = Contract;
            this.NightShifts = NightShifts;
            this.HourlyWage = HourlyWage;
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
