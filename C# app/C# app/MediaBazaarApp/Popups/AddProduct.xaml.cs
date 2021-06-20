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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        private Company company;
        public RefreshHandler ProductAdded;
        public AddProduct()
        {
            InitializeComponent();
            try
            {
                this.company = new Company();
                foreach (Department d in this.company.Departments.GetDepartments())
                {
                    this.cmbDepartment.Items.Add(d);
                }
                this.cmbDepartment.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = this.tb_Name.Text;
                decimal costPrice = Convert.ToDecimal(this.tb_CostPrice.Text);
                decimal sellingPrice = Convert.ToDecimal(this.tb_SellingPrice.Text);
                int restock = Convert.ToInt32(this.tb_Restock.Text);
                int quantity = Convert.ToInt32(this.tb_Quantity.Text);
                decimal Height = Convert.ToDecimal(this.tb_Height.Text);
                decimal Length = Convert.ToDecimal(this.tb_Lenght.Text);
                decimal Width = Convert.ToDecimal(this.tb_Width.Text);
               
                Department department = (Department)this.cmbDepartment.SelectedItem;

                this.company.Products.Add(new Product(name, department, costPrice,
                                   sellingPrice, Height, quantity, Length, Width, restock));


                this.Close();
                this.ProductAdded.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
