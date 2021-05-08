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
        private Depot depotWindow;
        private CashierWindow cashierWindow;
        public Login()
        {
            this.company = new Company();
            InitializeComponent();
         
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = this.tbEmail.Text;
                string password = this.tbPassword.Password;

                Person user =
                    this.company.AccountManager.IsValid(login, password);

                if (user is Administrator)
                {
                    this.mainWindow = new MainWindow(this.company, user);
                    this.mainWindow.Show();
                }
                if (user is Manager)
                {
                    this.managerWindow = new ManagerWindow(this.company, user);
                    this.managerWindow.Show();
                }
                if(user is DepotWorker)
                {
                    this.depotWindow = new Depot(this.company, user);
                    this.depotWindow.Show();
                }
                if(user is Cashier)
                {
                    this.cashierWindow = new CashierWindow(this.company, user);
                    this.cashierWindow.Show();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
