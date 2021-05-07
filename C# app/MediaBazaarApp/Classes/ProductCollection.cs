using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class ProductCollection
    {
        IProductStorage DAL;
        public delegate void ProductStockHandler(Product product);
        public event ProductStockHandler warningThresholdEvent;
        public ProductCollection(IProductStorage DAL)
        {
            this.DAL = DAL;
        }
        public List<Product> ToList()
        {
            return this.DAL.GetAll();
        }
        public Product GetProduct(int id)
        {
            return this.DAL.GetByID(id);
        }
        public void Add(Product product)
        {
            
            this.DAL.Create(product);
           
        }
        public void Update(Product product)
        {
            this.DAL.Update(product);
            if (this.warningThresholdEvent != null)
            { this.warningThresholdEvent(product); }
        }
    }
}
