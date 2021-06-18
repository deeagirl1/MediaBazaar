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
    /// Interaction logic for EditEmployee.xaml
    /// </summary>
    public delegate void RefreshHandler();
    public partial class EditEmployee : Window
    {
        private ShopWorker worker;
        private Company company;
        public RefreshHandler EmployeeEdited;

        public EditEmployee(Company company, ShopWorker worker)
        {
            try
            {
                InitializeComponent();
                this.company = company;
                this.worker = worker;
                this.cbx_Department.ItemsSource = this.company.Departments.GetDepartments();
                this.cbx_Contract.ItemsSource = this.company.Contracts;
                this.cbx_Status.ItemsSource = this.company.GetEditableStatuses();
                
                foreach(Department d in this.cbx_Department.Items)
                {
                    if(d.ID == worker.WorksAt.ID)
                        this.cbx_Department.SelectedItem = d;
                }
                   
                fillFields();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void fillFields()
        {
            try
            {

                if (worker.isDepManger == false)
                {
                    this.tb_Country.Text = this.worker.HomeAddress.Country;
                    this.tb_City.Text = this.worker.HomeAddress.City;
                    this.tb_Street.Text = this.worker.HomeAddress.Street;
                    this.tb_AddressAddition.Text = this.worker.HomeAddress.Addition;
                    this.tb_ZipCode.Text = this.worker.HomeAddress.ZipCode;
                    this.tb_StreetNumber.Text = this.worker.HomeAddress.StreetNumber;
                    this.tb_Email.Text = this.worker.Email;
                    this.tb_HourlyWage.Text = Convert.ToString(this.worker.HourlyWage);
                    this.tb_AccountNumber.Text = this.worker.BankAccount;
                    this.cbx_Department.SelectedItem = this.company.GetDepartmentByID(this.worker.WorksAt.ID);
                    this.cbx_Contract.SelectedItem = this.company.GetContractByID(this.worker.Contract.ID);
                    this.cbx_Status.SelectedItem = this.company.GetStatusByID(this.worker.Status.ID);
                    this.tb_day_LastWorkingDay.Text = Convert.ToString(this.worker.LastWorkingDay.Day);
                    this.tb_month_LastWorkingDay.Text = Convert.ToString(this.worker.LastWorkingDay.Month);
                    this.tb_year_LastWorkingDay.Text = Convert.ToString(this.worker.LastWorkingDay.Year);
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DateTime lastDay;
                if (string.IsNullOrEmpty(tb_year_LastWorkingDay.Text) && string.IsNullOrEmpty(tb_month_LastWorkingDay.Text) && string.IsNullOrEmpty(tb_day_LastWorkingDay.Text))
                {
                    lastDay = new DateTime();
                }
                else
                {
                    lastDay = new DateTime(Convert.ToInt32(tb_year_LastWorkingDay.Text), Convert.ToInt32(tb_month_LastWorkingDay.Text), Convert.ToInt32(tb_day_LastWorkingDay.Text));
                }

                this.worker.HomeAddress.Country = this.tb_Country.Text;
                this.worker.HomeAddress.City = this.tb_City.Text;
                this.worker.HomeAddress.Street = this.tb_Street.Text;
                this.worker.HomeAddress.Addition = this.tb_AddressAddition.Text;
                this.worker.HomeAddress.ZipCode = this.tb_ZipCode.Text;
                this.worker.HomeAddress.StreetNumber = this.tb_StreetNumber.Text;
                this.worker.Email = this.tb_Email.Text;
                this.worker.HourlyWage = Convert.ToDecimal(this.tb_HourlyWage.Text);
                this.worker.BankAccount = this.tb_AccountNumber.Text;
                this.worker.WorksAt = ((Department)this.cbx_Department.SelectedItem);
                this.worker.Contract = ((Contract)this.cbx_Contract.SelectedItem);
                this.worker.Status = ((Status)this.cbx_Status.SelectedItem);
                this.company.ShopWorkers.Edit(worker);
                this.Close();
                this.EmployeeEdited.Invoke();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
