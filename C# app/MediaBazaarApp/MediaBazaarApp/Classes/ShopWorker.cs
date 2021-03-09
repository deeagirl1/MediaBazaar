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
