using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class DepartmentMediator
    {
        IDepartment DAL;

        public DepartmentMediator(IDepartment DAL)
        {
            this.DAL = DAL;
        }
        public IReadOnlyList<Department> GetAll()
        {
           return this.DAL.GetAll();
        }
        public void Add(Department department)
        {
            this.DAL.Create(department);
        }
        public void Update(Department department)
        {
            this.DAL.Update(department);
        }
        public IReadOnlyList<Department> GetDepartments()
        {
            return this.DAL.GetAll();
        }

    }
}
