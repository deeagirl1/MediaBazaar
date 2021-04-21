using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MediaBazaarApp
{
    /// <summary>
    /// Interaction logic for Depot.xaml
    /// </summary>
    public partial class Depot : Window
    {
        public Depot()
        {
            InitializeComponent();
        }


        List<Item> items = new List<Item>();
        public void AddItem()
        {
            items.Add(new Item("item1", "dept1", 100, 200, 3));
             inventoryListView.ItemsSource = items;

            //Also update database
        }



        //Load items from database
        public void LoadItems()
        {
            throw new NotImplementedException();
        }


        public class Item
        {
            public string Name { get; set; }

            public string Department { get; set; }

            public double CostPrice { get; set; }
            public double SellingPrice { get; set; }
            public int Stock { get; set; }
            public Item(string name, string dept, double cost, double sellingPrice, int stock)
            {
                Name = name;
                Department = dept;
                CostPrice = cost;
                SellingPrice = sellingPrice;
                Stock = stock;
            }
        }
    }
}
