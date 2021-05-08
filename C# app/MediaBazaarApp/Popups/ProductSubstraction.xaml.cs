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
    /// Interaction logic for ProductSubstraction.xaml
    /// </summary>
    public partial class ProductSubstraction : Window
    {
        private Company company;
        private Product product;
        public ProductSubstraction(Product product)
        {
            try
            {
                InitializeComponent();
                this.product = product;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
