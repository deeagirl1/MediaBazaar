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
        void Update(Department department);
        List<Department> GetDepartmentName();

    
    }
}
