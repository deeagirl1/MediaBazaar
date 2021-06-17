using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class DepartmentManager : ShopWorker
    {
       public Department Department { get; set; }
       public DepartmentManager(string firstName, string lastName, string email) :
       base(firstName, lastName, email)
        { }
        public DepartmentManager(string firstName, string lastName, string email, string username, string password) :
          base(firstName, lastName, email, username, password)
        { }
        public DepartmentManager(int id, string firstName, string lastName, string email, string username, string password) :
            base(id, firstName, lastName, email, username, password)
        { }
        public DepartmentManager(string firstName, string lastName) :
          base(firstName, lastName)
        { }
        public DepartmentManager(int id, string firstName, string lastName) :
          base(id,firstName, lastName)
        { }
        public DepartmentManager(string firstName, string lastName, Department department) :
         base(firstName, lastName)
        {
            this.Department = department;
            this.isDepManger = true;
            //this.Manager = department.DepartmentManager;
        }

        public override string ToString()
        {
        
            return $"{ID}, {FirstName}, {LastName}";
        
        }
    }
}
