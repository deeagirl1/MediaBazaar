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
        public string Name { get; set; }
        public Department Department { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Height{ get; set; }
        public decimal Length{ get; set; }
        public decimal Width{ get; set; }
        public int MinThreshold { get; set; }
        public bool RequestNeeded { get { return true; } }
        public string FullName
        {
            get { return this.ID + " -- " + this.Name; }
        }
        public Product(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        public Product(string name, Department department, decimal costPrice, decimal sellingPrice,
            decimal height, decimal length, decimal width, int minThreshold)
        {
            this.Name = name;
            this.Department = department;
            this.CostPrice = costPrice;
            this.SellingPrice = sellingPrice;
            this.Height = height;
            this.Length = length;
            this.Width = width;
            this.MinThreshold = minThreshold;
        }

        public Product(int iD, string name, Department department, decimal costPrice, decimal sellingPrice,
            int quantity, decimal height, decimal length, decimal width, int minThreshold)
        {
            this.ID = iD;
            this.Name = name;
            this.Department = department;
            this.CostPrice = costPrice;
            this.SellingPrice = sellingPrice;
            this.Quantity = quantity;
            this.Height = height;
            this.Length = length;
            this.Width = width;
            this.MinThreshold = minThreshold;
        }
        public Product() { }
    }
}
