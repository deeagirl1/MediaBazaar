using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ShopWorker DepartmentManager { get; set; }

        public int NrOfEmployees { get; set; }

        public Department(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
        public Department(string Name)
        {
            this.Name = Name;
        }
      
        public Department(int ID, string Name, DepartmentManager manager)
        {
            this.ID = ID;
            this.Name = Name;
            this.DepartmentManager = manager;
        }
        public Department(int ID, string Name, DepartmentManager manager, int nrOfEmployees)
        {
            this.ID = ID;
            this.Name = Name;
            this.DepartmentManager = manager;
            this.NrOfEmployees = nrOfEmployees;
        }
        public Department(string Name, DepartmentManager manager)
        {
        
            this.Name = Name;
            this.DepartmentManager = manager;
        }
        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
