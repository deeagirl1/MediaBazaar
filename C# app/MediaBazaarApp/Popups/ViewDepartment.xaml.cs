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
    /// Interaction logic for ViewDepartment.xaml
    /// </summary>
    public partial class ViewDepartment : Window
    {
        private Company company;
        private Department department;
        public ViewDepartment(Company company, Department department)
        {
            try
            {
                InitializeComponent();
                this.company = company;
                this.department = department;
                tb_Name.IsEnabled = false;
                tb_DepartmentManager.IsEnabled = false;
                this.lvDepartments.ItemsSource = this.company.Departments.GetEmployees(department);
                tb_Name.Text = this.department.Name;


                tb_DepartmentManager.Text = this.department.DepartmentManager.FullName;
                
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
