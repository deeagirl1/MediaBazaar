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

namespace MediaBazaarApp.Classes
{
    /// <summary>
    /// Interaction logic for WorkShiftWindow.xaml
    /// </summary>
    public partial class WorkShiftWindow : Window
    {
        Company company;
        WorkShift shift;
        public WorkShiftWindow(WorkShift shift)
        {
            InitializeComponent();
            this.company = new Company();
            this.shift = shift;
            this.lblWorkshift.Content = this.shift.ToString();
            this.lvEmployees.ItemsSource = this.shift.AssignedEmployees;
        }

    }
}
