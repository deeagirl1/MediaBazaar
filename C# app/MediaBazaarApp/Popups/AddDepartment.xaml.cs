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
    /// Interaction logic for AddDepartment.xaml
    /// </summary>
    public partial class AddDepartment : Window
    {
        private Company company;
        private Department department;

        public AddDepartment(Company company)
        {
            InitializeComponent();
            try
            {
                this.company = new Company();
                this.cmbDepartment.ItemsSource = this.company.Departments.GetEmployeesToBeAssignedToDepManagers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = tb_Name.Text;
                DepartmentManager manager = ((DepartmentManager)this.cmbDepartment.SelectedItem);

                this.company.Departments.Add(new Department(name, manager));
                this.Close();
            }
            catch(Exception ex)
            {
              MessageBox.Show(ex.Message);
            }
        }
    }
}
