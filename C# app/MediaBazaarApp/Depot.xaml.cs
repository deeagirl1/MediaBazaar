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

namespace MediaBazaarApp
{
    /// <summary>
    /// Interaction logic for Depot.xaml
    /// </summary>
    public partial class Depot : Window
    {
        private Company company;
        private Person person;

        public Depot(Company company,Person person)
        {
            try
            {
                
                InitializeComponent();
                this.company = company;
                this.person = person;
                showRequests();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showRequests()
        {
            try
            {
                this.lvRequests.ItemsSource = this.company.Requests.GetAll();
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProductRequest req = (ProductRequest)this.lvRequests.SelectedItem;
                this.company.Requests.Accept(req);
                MessageBox.Show("Succesfully");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnReject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProductRequest req = (ProductRequest)this.lvRequests.SelectedItem;
                this.company.Requests.Reject(req);
                MessageBox.Show("Succesfully");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            this.showRequests();
        }
    }
}
