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
          
              
                this.cmbDepartments.ItemsSource = this.company.Departments.GetDepartments();
                this.cmbDepartments1.ItemsSource = this.company.Departments.GetDepartments();
           

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
                this.lbPeoplePresentSpecificDates.Content = this.company.Statistics.PeoplePresentForSpecificDates(start, end);
                this.lbAttendanceRateSpecificDate.Content = this.company.Statistics.GetAttendaceRateSpecificDate(start, end);
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
                Department department = (Department)this.cmbDepartments.SelectedItem;
                this.lblTotalProfitProduct.Content =
                    this.company.Statistics.GetAverageSalaryDepartment(department);
                this.lbPeoplePerDepartment.Content =
                    this.company.Statistics.NrOfEmployees(department);
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnGetProductStat_Click_1(object sender, RoutedEventArgs e)
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
              //  this.lblMostSold.Content =
                //    this.company.Statistics.GetMostSoldProductByDate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetInfoDepartments_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Department department = (Department)this.cmbDepartments1.SelectedItem;
                DateTime start = Convert.ToDateTime(this.dpStartDateDepartment.SelectedDate.Value.Date);
                DateTime end = Convert.ToDateTime(this.dpEndDateDepartment.SelectedDate.Value.Date);
                this.lbSalesPerDepartment.Content = this.company.Statistics.GetTotalSalesPerDepartment(department, start, end);
                this.lbTotalSalariesPaidPerDepartment.Content = this.company.Statistics.GetTotalSalariesPaidPerDepartment(department, start, end) + "€";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
