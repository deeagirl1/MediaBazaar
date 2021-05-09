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
using MediaBazaarApp.Classes;
using MediaBazaarApp.Popups;

namespace MediaBazaarApp
{
    /// <summary>
    /// Interaction logic for CashierWindow.xaml
    /// </summary>
    public partial class CashierWindow : Window
    {
        private Company company;
        private Person person;
        private ProductSubstraction window;
        public CashierWindow(Company company, Person person)
        {
            try
            {
                InitializeComponent();
                this.company = company;
                this.person = person;
                showProducts(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void showProducts()
        {
            try
            {
                this.lvProducts.ItemsSource = this.company.Products.ToList();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        private void lvProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //this.window = new ProductSubstraction(product);
            //this.window.Show();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            this.showProducts();
        }

        private void btnSell_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.lvProducts.SelectedItem != null)
                {
                    Product product = ((Product)this.lvProducts.SelectedItem);
                    if(product.Quantity > 0)
                        new ProductSubstraction(product).Show();
                    else MessageBox.Show("Out of stock!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
