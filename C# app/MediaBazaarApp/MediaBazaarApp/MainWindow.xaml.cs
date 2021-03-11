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
        public ShopWorker[] employees { get; set; }
        public MainWindow(Company company)
        {
            Loaded += OnLoad;
            InitializeComponent();
            this.company = company;
            employees = this.company.ShopWorkers.ToArray<ShopWorker>();
            DataContext = this;
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

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
