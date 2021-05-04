using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class Product
    {
        public int ID { get; }
        public string Name { get; set;}
        public string Department { get; set; }
        public double CostPrice { get; set; }
        public double SellingPrice { get; set; }

     

        public Product(int id,string name, string department, double costPrice, double sellingPrice)
        {
            this.ID = id;
            this.Name = name;
            this.Department = department;
            this.CostPrice = costPrice;
            this.SellingPrice = sellingPrice;
        }

        public Product(string name, string department, double costPrice, double sellingPrice)
        {
      
            this.Name = name;
            this.Department = department;
            this.CostPrice = costPrice;
            this.SellingPrice = sellingPrice;
        }



    }
}
