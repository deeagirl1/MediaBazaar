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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    MessageBox.Show("Suucessfully changed");
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
    }
}
