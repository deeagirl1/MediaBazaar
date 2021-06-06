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
    /// Interaction logic for EditDepartment.xaml
    /// </summary>
    public partial class EditDepartment : Window
    {
        private Company company;
        private Department department;
        public EditDepartment(Company company, Department department)
        {
            InitializeComponent();
            try
            {
                this.company = company;
                this.department = department;
                cmbDepartment.ItemsSource = this.company.Departments.GetManagers();
                tb_Name.Text = department.Name;
                this.lb_manager.Content = department.DepartmentManager;

            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnEditDepartment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.department.Name = tb_Name.Text;
                this.department.DepartmentManager = ((Manager)cmbDepartment.SelectedItem);
                this.company.Departments.Update(department);
                this.Close();
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

      
    }
}
