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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        private ShopWorker worker;
        private Company company;

        public AddEmployee(Company company)
        {
            InitializeComponent();
            this.company = company;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb_FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
                string firstName = tb_FirstName.Text;
                string lastName = tb_LastName.Text;
                string email = tb_Email.Text;
                int year = Convert.ToInt32(tb_year.Text);
                int month = Convert.ToInt32(tb_month.Text);
                int day = Convert.ToInt32(tb_day.Text);
                Address address = new Address(tb_Country.Text, tb_City.Text, tb_Street.Text, tb_StreetNumber.Text, tb_ZipCode.Text);
                Department department = (Department)cbx_Department.SelectedItem;
                Contract contract = (Contract) cbx_Contract.SelectedItem;

                DateTime birthDate = new DateTime(year, month, day);
                DateTime hireDate = dp_HireDate.DisplayDate;
                DateTime lastHireDate = dp_LastHireDate.DisplayDate;
            
            
            
                worker = new ShopWorker(1, firstName, lastName, email, birthDate, hireDate, lastHireDate, address);
                company.ShopWorkers.Add(worker);
                MessageBox.Show("Succesfully added!");
                this.Close();
            
        }
    }
}
