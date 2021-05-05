using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class ProductRequstMediator
    {
        IProductRequestStorage DAL;
        public ProductRequstMediator(IProductRequestStorage DAL)
        {
            this.DAL = DAL;
        }

        public IReadOnlyList<ProductRequest> GetAll()
        {
            return this.DAL.GetAll();
        }

        public void Request(ProductRequest request)
        {
            this.DAL.Create(request);
        }
    }
}
