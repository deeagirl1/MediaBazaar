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
        private ManagerWindow managerWindow;
        public Login()
        {
            this.company = new Company();
            this.managerWindow = new ManagerWindow(this.company);
            InitializeComponent();

            this.company.AccountManager.Add(new Administrator(10, "John", "Brown", "admin", "pass"));
            this.company.AccountManager.Add(new Manager(20, "a", "b", "manager", "pass"));
            this.company.ShopWorkers.Add(new ShopWorker(01, "John", "Brown", "em1", new DateTime(1996, 06, 13), new DateTime(2020, 03, 2),new DateTime(2022,03,2), new Address("Netherlands", "Eindhoven", "Passtor", "59","5612")));
           

        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string login = this.tbEmail.Text;
            string password = this.tbPassword.Text;

            IAccount user = 
                this.company.AccountManager.isValid(login, password);

            if (user is Administrator)
            {
                this.mainWindow = new MainWindow(this.company);
                this.mainWindow.Show();
            }
            if(user is Manager)
            {
                this.managerWindow = new ManagerWindow(this.company);
                this.managerWindow.Show();
            }
            
                
                
        }
    }
}
