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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private Company company;
        private MainWindow mainWindow;
        public Login()
        {
            this.company = new Company();
            InitializeComponent();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string login = this.tbEmail.Text;
            string password = this.tbPassword.Text;

            this.company.AccountManager.Add(new Administrator(10, "a", "b", "em", "pass"));

            IAccount user = 
                this.company.AccountManager.isValid(login, password);

            if (user is Administrator)
            {
                this.mainWindow = new MainWindow(this.company);
                this.mainWindow.Show();
            }
            
                
                
        }
    }
}
