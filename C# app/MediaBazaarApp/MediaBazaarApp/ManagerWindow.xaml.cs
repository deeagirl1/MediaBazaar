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
        private Company company;
        private Manager manager;

        public ManagerWindow(Company company, IAccount user)
        {
            Loaded += OnLoad;
            InitializeComponent();
            this.company = company;
            this.manager = (Manager)user;
        }

        

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            calendar = new Classes.Calendar(this);
            this.lblMonthYear.Content = $"{this.calendar.Year}, {this.calendar.Month}";
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {

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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int result = this.company.AccountManager.changePassword(this.manager.Email, tbOldPass.Text, tbNewPass.Text, tbRepeatPass.Text);

            if (result ==1)
            {
                MessageBox.Show("Password changed successfully");
            }
            else if (result == 0)
            {
                MessageBox.Show("Make sure you write the same password in both fields");
            }
            else if (result == -1)
            {
                MessageBox.Show("You do not have authorization to do this");
            }
        }
    }
}
