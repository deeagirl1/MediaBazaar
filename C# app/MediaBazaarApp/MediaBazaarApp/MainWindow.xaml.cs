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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaBazaarApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Classes.Calendar calendar;
        public MainWindow()
        {
            Loaded += OnLoad;
            InitializeComponent();
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            calendar = new Classes.Calendar(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            calendar.NextMonth();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            calendar.PreviousMonth();
        }
    }
}