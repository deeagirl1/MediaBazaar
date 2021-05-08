using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class ProductRequestMediator
    {
        IProductRequestStorage DAL;
        public ProductRequestMediator(IProductRequestStorage DAL)
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
        public void Accept(ProductRequest request)
        {
            if (request.RequestStatus.ID == 1)
            {
                this.DAL.UpdateStatus(request, 2);
                this.DAL.UpdateQuantity(request);
            }
            else throw new ArgumentException("Cannot change completed request!");
        }
        public void Reject(ProductRequest request)
        {
            if (request.RequestStatus.ID == 1)
                this.DAL.UpdateStatus(request, 3);
            else throw new ArgumentException("Cannot change completed request!");
        }
    }
}
