﻿using System;
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
    /// Interaction logic for AddAnnouncement.xaml
    /// </summary>
    public partial class AddAnnouncement : Window
    {

        private Company company;
        private Announcement announcement;
        public AddAnnouncement(Company company)
        {
            InitializeComponent();
            this.company = company;
        }

        private void btnAddAnnouncement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string title = tb_Title.Text;
                string description = tbDescription.Text;

                announcement = new Announcement(title,description);
                this.company.Announcements.AddAnnouncement(announcement);
                this.Close();
            }
            catch(Exception ex)
            {
              MessageBox.Show(ex.Message);
            }
        }
    }
}
