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
                lbStatus.Content = this.user.AccessLevel.ToString();

            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btn_EditUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
