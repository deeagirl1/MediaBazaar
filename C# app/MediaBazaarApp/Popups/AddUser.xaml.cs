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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        private Company company;
        public AddUser(Company company)
        {
            InitializeComponent();
            this.company = company;

        }

        private void btnAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string firstName = tb_FirstName.Text;
                string lastName = tb_LastName.Text;
                string email = tb_Email.Text;
                string username = email;
                string password = "";


                AccountManager account = new AccountManager();


                if ((bool)rb_Adminstrator.IsChecked)
                {
                    password = account.Add(new Administrator(firstName, lastName, email));
                }
                else if ((bool)rb_Manager.IsChecked)
                {
                    password = account.Add(new Manager(firstName, lastName, email));
                }
                else if ((bool)rbDepotWorker.IsChecked)
                {
                    password = account.Add(new DepotWorker(firstName, lastName, email));
                }
                else if ((bool)rbCashier.IsChecked)
                {
                    password = account.Add(new Cashier(firstName, lastName, email));
                }

                MessageBox.Show($"Username: {username}, Password: {password}" + "\n Please note them down!");

            }
            catch (Exception)
            {
                MessageBox.Show("All fields must be completed");
            }
        }
    }
}
