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
    /// Interaction logic for DepartmentManagerWindow.xaml
    /// </summary>
    public partial class DepartmentManagerWindow : Window
    {
        private Company company;
        private Department department;
        private List<ShopWorker> employees;
    
        public DepartmentManagerWindow(Company company, Person person)
        {
            InitializeComponent();
            this.company = company;

            this.department = this.company.Departments.GetDepartmentByManagerID(person.ID);
            this.lvShopWorkers.ItemsSource = this.company.Departments.GetEmployees(department);
            this.lblDepartmentName.Content = "General statistics for: " + this.department.Name;

            this.cmbProducts.ItemsSource = this.company.Products.GetAllProductByDepartment(department);
        }

        private void btnGetPRoductStat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Department department = this.department;
                if (department.ID != 0)
                {
                    this.lblTotalProfitProduct.Content =
                        this.company.Statistics.GetAverageSalaryDepartment(department);
                    this.lbPeoplePerDepartment.Content =
                        this.company.Statistics.NrOfEmployees(department);
                }
                else
                {
                    this.lblTotalProfitProduct.Content =
                      this.company.Statistics.GetAverageSalaryDepartment();
                    this.lbPeoplePerDepartment.Content =
                        this.company.Statistics.NrOfEmployees();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnGetInfoDepartments_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Department department = this.department;
                DateTime start = Convert.ToDateTime(this.dpStartDateDepartment.SelectedDate.Value.Date);
                DateTime end = Convert.ToDateTime(this.dpEndDateDepartment.SelectedDate.Value.Date);
                if (end <= start)
                    throw new Exception("Invalid date format");

                if (department.ID != 0)
                {
                    this.lbSalesPerDepartment.Content = this.company.Statistics.GetTotalSalesPerDepartment(start, end, department);
                    this.lbTotalSalariesPaidPerDepartment.Content = this.company.Statistics.GetTotalSalariesPaidPerDepartment(start, end, department) + "€";
                    this.lblTotalProfitPerDepartment.Content = this.company.Statistics.GetProfitPerDepartment(start, end, department) + "€";
                    this.lblTotalTurnOver.Content = this.company.Statistics.GetTurnOverPerDepartment(start, end, department) + "€";
                }
                else
                {
                    this.lbSalesPerDepartment.Content = this.company.Statistics.GetTotalSalesPerDepartment(start, end);
                    this.lbTotalSalariesPaidPerDepartment.Content = this.company.Statistics.GetTotalSalariesPaidPerDepartment(start, end) + "€";
                    this.lblTotalProfitPerDepartment.Content = this.company.Statistics.GetProfitPerDepartment(start, end) + "€";
                    this.lblTotalTurnOver.Content = this.company.Statistics.GetTurnOverPerDepartment(start, end) + "€";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetProductStat_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.lblMostSold.Content =
                   this.company.Statistics.GetMostSoldProductByDepartmentForDate(department,
                       (DateTime)this.dtp_StartProduct.SelectedDate,
                       (DateTime)this.dtp_EndProduct.SelectedDate);
            this.lblLeastSold.Content =
                this.company.Statistics.GetLeastSoldProductByDepartmentForDate(department,
                    (DateTime)this.dtp_StartProduct.SelectedDate,
                    (DateTime)this.dtp_EndProduct.SelectedDate);
            this.lbMostProfitable.Content =
                this.company.Statistics.GetMostProfitableProductByDepartmentForDate(department,
                (DateTime)this.dtp_StartProduct.SelectedDate,
                (DateTime)this.dtp_EndProduct.SelectedDate);
            this.lbLeastProfitable.Content =
            this.company.Statistics.GetLeastProfitableProductByDepartmentForDate(department,
            (DateTime)this.dtp_StartProduct.SelectedDate,
            (DateTime)this.dtp_EndProduct.SelectedDate);
        }
    }
}
