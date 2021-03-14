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
    /// Interaction logic for WorkShiftWindow.xaml
    /// </summary>
    public partial class WorkShiftWindow : Window
    {
        private Classes.WorkShift workShift;
        public WorkShiftWindow(Classes.WorkShift workShift)
        {
            this.workShift = workShift;
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            for (int i = 0; i < workShift.ShopWorkers.Count; i++)
            {
                AssignedWorkersListView.Items.Add(workShift.ShopWorkers[i]);
            }
        }
    }
}
