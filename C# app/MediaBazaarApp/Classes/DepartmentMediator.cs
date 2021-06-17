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
        public void Update(Department department, ShopWorker exShopWorker)
        {
            this.DAL.Update(department, exShopWorker);
        }
        public IReadOnlyList<Department> GetDepartments()
        {
            return this.DAL.GetAll();
        }
        public IReadOnlyList<ShopWorker> GetEmployeesToBeAssignedToDepManagers()
        {
            return this.DAL.GetEmployeesToBeAssignedToDepManagers();
        }
        public DepartmentManager GetManager(Department department)
        {
            return this.DAL.GetDepManager(department);
        }
        public IReadOnlyList<ShopWorker> GetEmployees(Department department)
        {
            return this.DAL.GetEmployees(department);
        }

        public Department GetDepartmentByManagerID(int id)
        {
            return this.DAL.GetDepartmentByManagerID(id);
        }

    }
}
