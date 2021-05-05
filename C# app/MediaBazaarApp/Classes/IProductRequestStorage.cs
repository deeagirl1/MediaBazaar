using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public interface IProductRequestStorage
    {
        void Create(ProductRequest productRequest);
        List<ProductRequest> GetAll();
    }
}
