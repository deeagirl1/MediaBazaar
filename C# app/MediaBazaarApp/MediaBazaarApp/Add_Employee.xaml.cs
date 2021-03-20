using System;
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
    /// Interaction logic for Add_Employee.xaml
    /// </summary>
    public partial class Add_Employee : Window
    {
        private ShopWorker worker;
        private Company company;

        public Add_Employee(Company company)
        {
            try
            {
                InitializeComponent();

                this.company = company;
                this.cbx_Contract.ItemsSource = this.company.Contracts;
                this.cbx_Department.ItemsSource = this.company.Departments;
                this.cbx_Status.ItemsSource = this.company.Statuses;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_AddEmployee_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                Address address = new Address(tb_Country.Text, tb_City.Text, tb_Street.Text, tb_StreetNr.Text, tb_AdditionalInfo.Text, "");
                worker = new ShopWorker();
                this.worker.HomeAddress = address;
                this.worker.FirstName = tb_FirstName.Text;
                this.worker.LastName = tb_LastName.Text;
                this.worker.Email = this.tb_Email.Text;
                DateTime lastDay;

                if (string.IsNullOrEmpty(tb_year_LastWorkingDay.Text) && string.IsNullOrEmpty(tb_month_LastWorkingDay.Text) && string.IsNullOrEmpty(tb_day_LastWorkingDay.Text))
                {
                    lastDay = new DateTime();
                }
                else
                {
                    lastDay = new DateTime(Convert.ToInt32(tb_year_LastWorkingDay.Text), Convert.ToInt32(tb_month_LastWorkingDay.Text), Convert.ToInt32(tb_day_LastWorkingDay.Text));
                }

                DateTime birthDate = new DateTime(Convert.ToInt32(tb_year.Text), Convert.ToInt32(tb_month.Text), Convert.ToInt32(tb_day.Text));
                DateTime firstDay = new DateTime(Convert.ToInt32(tb_year_FirstWorkingDay.Text), Convert.ToInt32(tb_month_FirstWorkingDay.Text), Convert.ToInt32(tb_day_FirstWorkingDay.Text));
                this.worker.BirthDate = birthDate;
                this.worker.HireTime = firstDay;
                this.worker.LastWorkingDay = lastDay;
                this.worker.HourlyWage = Convert.ToDecimal(this.tb_HourlyWage.Text);
                this.worker.BankAccount = this.tb_Accountumber.Text;
                this.worker.WorksAt = ((Department)this.cbx_Department.SelectedItem);
                this.worker.Contract = ((Contract)this.cbx_Contract.SelectedItem);
                this.worker.Status = ((Status)this.cbx_Status.SelectedItem);

                this.company.ShopWorkers.Add(worker);
                this.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }




            //worker = new ShopWorker(1, firstName, lastName, email, birthDate, hireDate, lastHireDate, address);
            //company.ShopWorkers.Add(worker);



        }

    }
}
