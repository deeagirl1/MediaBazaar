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
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        private Company company;
        private User user;
        public EditUser(Company company, User user)
        {
            InitializeComponent();
            this.user = user;
            this.company = company;

            try
            {
                tb_FirstName.Text = this.user.FirstName;
                tb_LastName.Text = this.user.LastName;
                tb_Email.Text = this.user.Email;

                if(user.AccessLevel == 2)
                {
                    this.rb_Adminstrator.IsChecked = true;
                }
                if (user.AccessLevel == 3)
                {
                    this.rb_Manager.IsChecked = true;
                }
                if (user.AccessLevel == 4)
                {
                    this.rbDepotWorker.IsChecked = true;
                }
                if (user.AccessLevel == 5)
                {
                    this.rbCashier.IsChecked = true;
                }



            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btn_EditUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.user.FirstName = tb_FirstName.Text;
                this.user.LastName = tb_LastName.Text;
                this.user.Email = tb_Email.Text;

                if (rb_Adminstrator.IsChecked == true)
                {
                    user.AccessLevel = 2;
                }
                if (rb_Manager.IsChecked == true)
                {
                    user.AccessLevel = 3;
                }
                if (rbDepotWorker.IsChecked == true)
                {
                    user.AccessLevel = 4;
                }
                if (rbCashier.IsChecked == true)
                {
                    user.AccessLevel = 5;
                }

                this.company.AccountManager.Update(user);
            }

            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}
