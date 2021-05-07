using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class ProductRequest
    {
        public int ID { get; }
        public Product Product{ get; }
        public int Quantity { get; }
        public DateTime DateTime { get; }

        public RequestStatus RequestStatus { get; }

        public ProductRequest(int ID, Product product, int quantity, DateTime dateTime)
        {
            this.ID = ID;
            this.Product = product;
            this.Quantity = quantity;
            this.DateTime = dateTime;
        }
       
    }
}
