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
        private int quantity;
        private decimal height;
        private decimal length;
        private decimal width;
        private int minThreshold;
        public int Quantity
        {
            get { return this.quantity; }
            set
            {
                if (value >= 0)
                    this.quantity = value;
                else throw new ArgumentException("Value must be greater than zero");
            }
        }
        public decimal Height
        {
            get {return this.height; }
            set
            {
                if (value > 0)
                    this.height = value;
                else throw new ArgumentException("Value must be greater than zero");
            }
        }
        public decimal Length 
        {
            get { return this.length; }
            set
            {
                if (value > 0)
                    this.length = value;
                else throw new ArgumentException("Value must be greater than zero");
            }
        }
        public decimal Width
        {
            get { return this.width; }
            set
            {
                if (value > 0)
                    this.width = value;
                else throw new ArgumentException("Value must be greater than zero");
            }
        }
        public int MinThreshold
        {
            get { return this.minThreshold; }
            set
            {
                if (value > 0)
                    this.minThreshold = value;
                else throw new ArgumentException("Value must be greater than zero");
            }
        }
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

        public override string ToString()
        {
            return $"{this.Name} -- {this.ID}";
        }
    }
}
