using MediaBazaarApp.Classes;
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
    /// Interaction logic for AutoScheduleWindow.xaml
    /// </summary>
    public partial class AutoScheduleWindow : Window
    {
        private Company company;
        public delegate void Refresh(DateTime date);
        public event Refresh RefreshCalendar;
        public AutoScheduleWindow()
        {
            InitializeComponent();
            this.company = new Company();
        }

        private void btnProceed_Click(object sender, RoutedEventArgs e)
        {
            DateTime start = Convert.ToDateTime(this.dtpStartDate.SelectedDate);
            DateTime end= Convert.ToDateTime(this.dtpEndDate.SelectedDate);
            int amount = Convert.ToInt32(this.tbAmount.Text);
            this.company.AutoScheduler.Schedule(start, end, amount);
            if (RefreshCalendar != null)
                RefreshCalendar(start);
            this.Close();
        }
    }
}
