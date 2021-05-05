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
        public int Quantity { get; set; }
        public int MinTreshold { get; set; }
        public string FullName 
        { 
            get { return this.ID + " -- " + this.Name; } 
        }
        public Product(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        public Product(int id,string name, string department, double costPrice,
            double sellingPrice, int quantity, int minTreshold)
        {
            this.ID = id;
            this.Name = name;
            this.Department = department;
            this.CostPrice = costPrice;
            this.SellingPrice = sellingPrice;
            this.Quantity = quantity;
            this.MinTreshold= minTreshold;
        }
        public Product(string name, string department, double costPrice,
            double sellingPrice, int quantity, int minTreshold)
        {
            this.Name = name;
            this.Department = department;
            this.CostPrice = costPrice;
            this.SellingPrice = sellingPrice;
            this.Quantity = quantity;
            this.MinTreshold = minTreshold;
        }
    }
}
