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
        public int DepartmentManagerID { get; set; }
        public Manager DepartmentManager { get; set; }

        public Department(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
        public Department( string Name)
        {
           
            this.Name = Name;
        }
        public Department(int ID, string Name, int managerID)
        {
            this.ID = ID;
            this.Name = Name;
            this.DepartmentManagerID = managerID;
        }
        public Department(int ID, string Name, Manager manager)
        {
            this.ID = ID;
            this.Name = Name;
            this.DepartmentManager = manager;
        }
        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
