using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class ShopWorker : Person, ISalary, IComparable<ShopWorker>
    {
        private DepartmentManager manager;
        public Department WorksAt { get; set; }
        public Address HomeAddress { get; set; }
        public DateTime BirthDate { get; set; }
        public string BankAccount { get; set; }
        public DateTime HireTime { get; set; }  
        public DateTime LastWorkingDay { get; set; }
        public Contract Contract { get; set; }

        public bool isDepManger { get; set; }

        //public DepartmentManager Manager { get; set; }
        
        public Status Status { get; set; }
        private decimal hourlyWage;

        public ShopWorker() { }

        public decimal HourlyWage 
        {
            get { return this.hourlyWage; }
            set {
                if (value > 0 && value <= 100) this.hourlyWage = value;
                else throw new ArgumentException("Wage upper limit: 100");
            }
        }

        public string FullName 
        {
            get { return $"{this.FirstName} {this.LastName}"; }
        }



        public ShopWorker(int id,string firstName, string lastName) : base(id,firstName, lastName)
        {
        }
        public ShopWorker(int id, string firstName, string lastName, string email, DateTime birthDate, DateTime hireDate,Address address) : base (id, firstName, lastName, email)
        {

            this.BirthDate = birthDate.Date;
            this.HireTime = hireDate;
            this.HomeAddress = address;
        }

        public ShopWorker(int id, string firstName, string lastName, string email,string username, string password) :
            base(id, firstName, lastName, email, username, password)
        { }

        public ShopWorker(int id, string firstName, string lastName, string email,string username, string password,
            Department Department, Address HomeAddress, DateTime BirthDate,
            string BankAccount,Status status, DateTime HireTime,DateTime LastWorkingDay, Contract Contract,  decimal HourlyWage) :
            base(id, firstName, lastName, email,username, password)
        {
            this.WorksAt = Department;
            this.HomeAddress = HomeAddress;
            this.BirthDate = BirthDate;
            this.BankAccount = BankAccount;
            this.HireTime = HireTime;
            this.LastWorkingDay = LastWorkingDay;
            this.Contract = Contract;
            this.HourlyWage = HourlyWage;
            this.Status = status;
        }
        public ShopWorker(string firstName, string lastName, string email) :
      base(firstName, lastName, email)
        { }
        public ShopWorker(string firstName, string lastName, string email, string username, string password) :
          base(firstName, lastName, email, username, password)
        { }
     
        public ShopWorker(string firstName, string lastName) :
          base(firstName, lastName)
        { }
        public ShopWorker(string firstName, string lastName, Department department) :
         base(firstName, lastName)
        {
            
            //this.Manager = department.DepartmentManager;
            this.isDepManger = true;
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

        public override string ToString()
        {
            return $"{ID}, {FirstName}, {LastName}";
        }
    }
}
