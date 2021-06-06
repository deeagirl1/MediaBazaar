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
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        private Classes.Calendar calendar;
        private Person person;
        private Company company;
        private List<ShopWorker> employees;
        public ManagerWindow(Company company, Person person)
        {
            try
            {
                Loaded += OnLoad;
                InitializeComponent();
                this.company = company;
                this.person = person;
                Loaded += OnLoad;

                this.employees = this.company.ShopWorkers.ToList();
                this.lvShopWorkers.ItemsSource = this.employees;
                this.lblUserString.Content = $"Hello , {person.FirstName}";
                this.dpDate.SelectedDate = DateTime.Now;
                this.dpStartDate.SelectedDate = DateTime.Now;
                this.dpEndDate.SelectedDate = DateTime.Now;

                this.loadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadProducts()
        {
            this.cmbProducts.ItemsSource = this.company.Products.ToList();
        }


        private void OnLoad(object sender, RoutedEventArgs e)
        {
            try
            {
                calendar = new Classes.Calendar(this, company.ShiftSchedule.ToList());
                this.lblMonthYear.Content = $"{this.calendar.Year}, {this.calendar.Month}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.employees = this.company.ShopWorkers.ToList();
                this.lvShopWorkers.ItemsSource = this.employees;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnNextMonthClick(object sender, RoutedEventArgs e)
        {
            calendar.NextMonth();
            this.lblMonthYear.Content = $"{this.calendar.Year}, {this.calendar.Month}";
        }

        private void btnPrevMonthClick(object sender, RoutedEventArgs e)
        {
            calendar.PreviousMonth();
            this.lblMonthYear.Content = $"{this.calendar.Year}, {this.calendar.Month}";
        }

        private void btnChangePassword_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.tbNewPassRepeat.Text == this.tbNewPass.Text)
                {
                    this.company.AccountManager.ChangePassword(this.person.Username,
                                        this.tbCurrentPass.Text, this.tbNewPass.Text);
                    MessageBox.Show("Sucessfully changed");
                }
                else throw new ArgumentException("Passwords do not match");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnGetInfo1_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                DateTime date = Convert.ToDateTime(this.dpDate.SelectedDate.Value.Date);
                this.lblTotalEmployees.Content = this.company.Statistics.GetTotalEmployeesForDate(date);
                this.lblTotalSalaryPaid.Content = this.company.Statistics.GetTotalSalaryPaidForDate(date);
                this.lblTotalHoursWorked.Content = this.company.Statistics.GetTotalHoursWorkedForDate(date);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnGetInfo2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime start = Convert.ToDateTime(this.dpStartDate.SelectedDate.Value.Date);
                DateTime end = Convert.ToDateTime(this.dpEndDate.SelectedDate.Value.Date);
                this.lblAverageEmployeesPerShiftForPeriod.Content = this.company.Statistics.GetAverageEmployeePerShiftForPeriod(start, end);
                this.lblTotalSalaryPaidForPeriod.Content = this.company.Statistics.GetTotalSalaryPaidForPeriod(start, end);
                this.lblAverageSalaryForPeriod.Content = this.company.Statistics.GetAverageSalaryForPeriod(start, end);
                this.lblHoursWorkedForPeriod.Content = this.company.Statistics.GetHoursWorkedForPeriod(start, end);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefreshCalendar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                calendar = new Classes.Calendar(this, company.ShiftSchedule.ToList());
                this.lblMonthYear.Content = $"{this.calendar.Year}, {this.calendar.Month}";
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
                calendar.NextMonth();
                this.lblMonthYear.Content = $"{this.calendar.Year}, {this.calendar.Month}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                calendar.PreviousMonth();
                this.lblMonthYear.Content = $"{this.calendar.Year}, {this.calendar.Month}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetPRoductStat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product prd = (Product)this.cmbProducts.SelectedItem;
                this.lblAvgAmountPerPurchase.Content =
                     this.company.Statistics.GetAvgItemPerPurchase(prd);
                this.lblTotalProfit.Content =
                     this.company.Statistics.GetProfitPerProduct(prd) + " €";
                this.lblTotalSalesPerProduct.Content =
                    this.company.Statistics.GetTotalSalesPerProduct(prd);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
