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
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        private Company company;
        private Product product;
        public EditProduct(Company company,Product product)
        {

            InitializeComponent();
            try
            {
                this.company = company;
                this.product = product;
                foreach (Department d in this.company.Departments)
                {
                    this.cmbDepartment.Items.Add(d);
                }
                this.cmbDepartment.SelectedIndex = 0;
                this.tb_Name.Text = this.product.Name;
                this.tb_CostPrice.Text = this.product.CostPrice.ToString();
                this.tb_SellingPrice.Text = this.product.SellingPrice.ToString();
                this.cmbDepartment.SelectedItem = this.product.Department;
                this.tb_Lenght.Text = this.product.Length.ToString();
                this.tb_Quantity.Text = this.product.Quantity.ToString();
                this.tb_Width.Text = this.product.Width.ToString();
                this.tb_Height.Text = this.product.Height.ToString();
                this.tb_Restock.Text = this.product.MinThreshold.ToString();
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }


        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.product.Name = tb_Name.Text;
                this.product.CostPrice = Convert.ToDecimal(tb_CostPrice.Text);
                this.product.SellingPrice = Convert.ToDecimal(tb_SellingPrice.Text);
                this.product.Department = (Department)cmbDepartment.SelectedItem;
                this.product.Height = Convert.ToDecimal(tb_Height.Text);
                this.product.Length = Convert.ToDecimal(tb_Lenght.Text);
                this.product.Width = Convert.ToDecimal(tb_Width.Text);
                this.product.MinThreshold = Convert.ToInt32(tb_Restock.Text);
                this.product.Quantity = Convert.ToInt32(tb_Quantity.Text);
                this.company.Products.Update(product);
                this.Close();
            }
            catch (ArgumentException ex)
            {
               MessageBox.Show(ex.Message);
            }

        }
    }
}
