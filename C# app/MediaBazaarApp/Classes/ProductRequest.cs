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
        public Product Product { get; }
        private int quantity;
        public int Quantity
        {
            get { return this.quantity; }
            set {
                if (value > 0)
                    this.quantity = value;
                else throw new ArgumentException("Value must be greater than zero");
            }
        }
        public DateTime DateTime { get; }
        public RequestStatus RequestStatus { get; }
        public ProductRequest(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }
        public ProductRequest(int ID, Product product, int quantity, DateTime dateTime, RequestStatus status)
        {
            this.ID = ID;
            this.Product = product;
            this.Quantity = quantity;
            this.DateTime = dateTime;
            this.RequestStatus = status;
        }
    }
}
