using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public interface IProductRequestStorage
    {
        void UpdateStatus(ProductRequest request, int Status, string comment);
        void UpdateStatus(ProductRequest request, int Status);
        void UpdateQuantity(ProductRequest request);
        void CreateComment(ProductRequest request, string comment);
        void Create(ProductRequest productRequest);
        List<ProductRequest> GetAll();
    }
}
