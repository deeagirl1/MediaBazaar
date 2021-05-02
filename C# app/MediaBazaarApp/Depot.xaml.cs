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
        List<Item> InventoryItems = new List<Item>();

        public Depot()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            inventoryListView.Items.Clear();
        }

        public void AddItem()
        {
            InventoryItems.Add(new Item("item1", "dept1", 100, 200, 3));
            inventoryListView.ItemsSource = InventoryItems;

            //Also update database
        }

        public void SetItems(Item[] items)
        {
            inventoryListView.ItemsSource = items;
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
