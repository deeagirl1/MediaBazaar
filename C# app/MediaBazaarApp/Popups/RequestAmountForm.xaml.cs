using MediaBazaarApp.Classes;
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

namespace MediaBazaarApp.Popups
{
    /// <summary>
    /// Interaction logic for RequestAmountForm.xaml
    /// </summary>
    public partial class RequestAmountForm : Window
    {
        private Product product;
        private Company company;
        public RequestAmountForm(Product product)
        {
            InitializeComponent();
            this.company = new Company();
            this.product = product;
        }

        private void btnRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.company.Requests.Request(new ProductRequest(
                    this.product, Convert.ToInt32(this.tbAmount.Text)));
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
