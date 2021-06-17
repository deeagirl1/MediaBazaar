using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public interface IDepartment
    {
        List<Department> GetAll();
        void Create(Department department);
        void Update(Department department, ShopWorker exManager);
        int NrOfEmployees(int depID);
        List<ShopWorker> GetEmployees(Department department);
        DepartmentManager GetDepManager(Department department);
        List<DepartmentManager> GetEmployeesToBeAssignedToDepManagers();
        Department GetDepartmentByManagerID(int id);



    }
}
