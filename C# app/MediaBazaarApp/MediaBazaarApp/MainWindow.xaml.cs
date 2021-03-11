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

namespace MediaBazaarApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Classes.Calendar calendar;
        private Company company;
        private AddEmployee window;

        public List<ShopWorker> employees { get; set; }
        public MainWindow(Company company)
        {
            Loaded += OnLoad;
            InitializeComponent();
            this.company = company;
            employees = new List<ShopWorker>();

            ShopWorker employee1 = new ShopWorker();
            employee1.ID = 1;
            employee1.FirstName = "John";
            employee1.LastName = "Martson";
            ShopWorker employee2 = new ShopWorker();
            employee2.ID = 2;
            employee2.FirstName = "Barney";
            employee2.LastName = "Rancaciov";

            ShopWorker employee3 = new ShopWorker();
            employee3.ID = 3;
            employee3.FirstName = "Hailey";
            employee3.LastName = "Wilson";

            employees.Add(employee1);
            employees.Add(employee2);
            employees.Add(employee3);

            DataContext = this;


        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            calendar = new Classes.Calendar(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            calendar.NextMonth();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            calendar.PreviousMonth();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            window = new AddEmployee();
            window.Show();
        }
    }
}
