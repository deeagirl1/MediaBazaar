using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public interface IProductStorage
    {
        List<Product> GetAll();
        Product GetByID(int id);
        void Create(Product product);
        void Update(Product product);
        void SubtractAmount(Product product, int difference);

        List<Product> GetProductsByDepartment(Department department);
    }
}
