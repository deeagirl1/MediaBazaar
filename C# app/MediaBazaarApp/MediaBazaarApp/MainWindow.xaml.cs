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
        private AddEmployee addEmployeeForm;
        private EditEmployee editEmployeeForm;

        private List<ShopWorker> employees;
        public MainWindow(Company company, Person person)
        {
            Loaded += OnLoad;
            InitializeComponent();
            this.company = company;
            Loaded += OnLoad;

            this.employees = this.company.ShopWorkers.ToList();
            this.lvShopWorkers.ItemsSource = this.employees;

            this.person = person;
            MessageBox.Show(person.LastName);
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
            //this.window = new AddEmployee(company);
            //this.window.Show();
        }

        private void btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            this.employees = this.company.ShopWorkers.ToList();
            this.lvShopWorkers.ItemsSource = this.employees;
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            this.editEmployeeForm = new EditEmployee(this.company);

        }
    }
}
