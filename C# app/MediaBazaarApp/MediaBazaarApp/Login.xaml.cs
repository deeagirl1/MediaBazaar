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
        private MainWindow admWindow;
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
<<<<<<< HEAD
            this.company.ShopWorkers.Add(new ShopWorker(01, "a1", "b1", "em1", "pass")); // to be seen in the list
=======
            this.company.ShopWorkers.Add(new ShopWorker(01, "a1", "b1", "em1", "pass"));
>>>>>>> 0f6824ca87bdcde9928d5d364260e5d8c6c484da
            this.company.ShopWorkers.Add(new ShopWorker(02, "a2", "b2", "em2", "pass"));
            this.company.ShopWorkers.Add(new ShopWorker(03, "a3", "b3", "em3", "pass"));

            IAccount user = 
                this.company.AccountManager.isValid(login, password);

            if (user is Administrator)
            {
<<<<<<< HEAD
                this.mainWindow = new MainWindow(this.company);
                this.mainWindow.Show();
=======
                this.admWindow = new MainWindow(this.company);
                this.admWindow.Show();
>>>>>>> 0f6824ca87bdcde9928d5d364260e5d8c6c484da
            }
            
                
                
        }
    }
}
