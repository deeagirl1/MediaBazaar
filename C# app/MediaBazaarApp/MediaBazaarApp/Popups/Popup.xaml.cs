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

namespace MediaBazaarApp.Popups
{
    /// <summary>
    /// Interaction logic for Popup.xaml
    /// </summary>
    public partial class Popup : Window
    {
        public Popup(string title, string message)
        {
            InitializeComponent();
            Title = title;
            this.mainText.Content = message;
        }

        public Popup(string title, string message, string buttonMessage)
        {
            InitializeComponent();
            Title = title; 
            this.mainText.Content = message;
            this.okBtn.Content = buttonMessage;
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
