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

namespace MediaBazaarApp.Popups
{
    /// <summary>
    /// Interaction logic for RejectReason.xaml
    /// </summary>
    public partial class RejectReason : Window
    {
        private ProductRequest req;
        private Company company;

        public RejectReason(ProductRequest req, Company company)
        {
            try
            {
                InitializeComponent();
                this.req = req;
                this.company = company;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSendReason_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string comment = tbDescription.Text;
                this.company.Requests.Reject(req, comment);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
