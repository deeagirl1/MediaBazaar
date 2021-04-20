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
    /// Interaction logic for EditAnnouncement.xaml
    /// </summary>
    public partial class EditAnnouncement : Window
    {
        private Company company;
        private Announcement announcement;

        public EditAnnouncement(Company company, Announcement announcement)
        {
            InitializeComponent();
            this.company = company;
            this.announcement = announcement;
            this.tbTitle.Text = this.announcement.Title;
            this.tbDescription.Text = this.announcement.Description;

        }

        private void btnEditAnnouncement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.announcement.Title = tbTitle.Text;
                this.announcement.Description = tbDescription.Text;

                this.company.Announcements.EditAnnouncement(announcement);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
