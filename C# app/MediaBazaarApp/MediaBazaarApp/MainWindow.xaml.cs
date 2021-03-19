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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MediaBazaarApp.Classes;
using MediaBazaarApp.Popups;

namespace MediaBazaarApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Classes.Calendar calendar;
        private Person person;
        private Company company;
        private Add_Employee addEmployeeForm;
        private EditEmployee editEmployeeForm;

        private List<ShopWorker> employees;
        public MainWindow(Company company, Person person)
        {
            Loaded += OnLoad;
            InitializeComponent();
            this.company = company;
            this.person = person;
            Loaded += OnLoad;

            this.employees = this.company.ShopWorkers.ToList();
            this.lvShopWorkers.ItemsSource = this.employees;
            this.lblUserString.Content = $"Hello, {this.person.FirstName}";



            MessageBox.Show(person.Username);

            ShopWorker emp = new ShopWorker(33,
                                                    "A",
                                                    "A",
                                                    "A7fdsf74",
                                                    "B37fsdf74",
                                                    "C",
                                                    new Department(2, "Electronics"),
                                                    new Address("S", "S", "S", "S", "S", ""),
                                                    new DateTime(1990, 05, 30),
                                                    "VBMN321321",
                                                    new Status(2, ""),
                                                    new DateTime(2020, 05, 30),
                                                    new DateTime(),
                                                    new Contract(2, true, 32),
                                                    Convert.ToDecimal(15.55));

            //this.company.ShopWorkers.Edit(emp);
            //this.company.ShopWorkers.Add(emp);
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            calendar = new Classes.Calendar(this);
            this.lblMonthYear.Content = $"{this.calendar.Year}, {this.calendar.Month}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            calendar.NextMonth();
            this.lblMonthYear.Content = $"{this.calendar.Year}, {this.calendar.Month}";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            calendar.PreviousMonth();
            this.lblMonthYear.Content = $"{this.calendar.Year}, {this.calendar.Month}";
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            this.addEmployeeForm = new Add_Employee(this.company);
            this.addEmployeeForm.Show();
        }

        private void btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            this.employees = this.company.ShopWorkers.ToList();
            this.lvShopWorkers.ItemsSource = this.employees;
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (this.lvShopWorkers.SelectedItem != null)
            {
                ShopWorker worker = ((ShopWorker)this.lvShopWorkers.SelectedItem);
                this.editEmployeeForm = new EditEmployee(this.company,worker);
                this.editEmployeeForm.Show();
            }
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
