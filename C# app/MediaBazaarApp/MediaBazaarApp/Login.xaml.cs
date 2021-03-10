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

            this.company.accountManager.Add(new Administrator(10, "Bohdan", "Tymofieienko", "em", "pass"));
            this.company.accountManager.Add(new ShopWorker(01, "A1", "B1", "em1", "pass"));
            this.company.accountManager.Add(new Administrator(02, "A2", "B2", "em2", "pass"));
            this.company.accountManager.Add(new Administrator(02, "A3", "B3", "em3", "pass"));

            IAccount user = 
                this.company.accountManager.isValid(login, password);

            if (user is Administrator)
            {
                this.mainWindow = new MainWindow(this.company);
                this.mainWindow.Show();
            }           
        }
    }
}
