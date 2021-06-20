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

namespace MediaBazaarApp
{
    /// <summary>
    /// Interaction logic for NewWorkshiftWindow.xaml
    /// </summary>

    public partial class NewWorkshiftWindow : Window
    {
        private WorkShift shift;
        private Company company;

        public delegate void Refresh(DateTime date);
        public event Refresh RefreshCalendar;

        public NewWorkshiftWindow(DateTime date)
        {
            try
            {
                InitializeComponent();
                this.InitializeComponent();
                this.company = new Company();
                int shiftType = 1;

                if (date.Hour == 7) { shiftType = 1; }
                else if (date.Hour == 15) { shiftType = 2; }
                else if (date.Hour == 23) { shiftType = 3; }

                this.shift = new WorkShift(date, new Shift(shiftType));

                foreach (ShopWorker s in this.company.ShopWorkers.GetAvailiableEmployees(shift))
                {
                    this.lvAvailableEmployees.Items.Add(s);
                }
                this.lblWorkshift.Content = this.shift.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAssign_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //this.lvAssignedEmployees.Items.Add((ShopWorker)this.lvAssignedEmployees.SelectedItem);
                if (this.lvAvailableEmployees.SelectedItem != null)
                {
                    ShopWorker worker = ((ShopWorker)this.lvAvailableEmployees.SelectedItem);
                    //MessageBox.Show(worker.ToString());
                    if (!lvAssignedEmployees.Items.Contains(worker))
                    {
                        this.lvAssignedEmployees.Items.Add(worker);
                        this.lvAvailableEmployees.Items.Remove(worker);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // this.lvAssignedEmployees.Items.Remove((ShopWorker)this.lvAssignedEmployees.SelectedItem);
                if (this.lvAssignedEmployees.SelectedItem != null)
                {
                    ShopWorker worker = ((ShopWorker)this.lvAssignedEmployees.SelectedItem);
                    //MessageBox.Show(worker.ToString());
                    if (!lvAvailableEmployees.Items.Contains(worker))
                    {
                        this.lvAvailableEmployees.Items.Add(worker);
                        this.lvAssignedEmployees.Items.Remove(worker);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnProceed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (Object obj in this.lvAssignedEmployees.Items)
                {
                    if (obj is ShopWorker)
                    {
                        ShopWorker worker = (ShopWorker)obj;
                        this.shift.AssignedEmployees.Add(worker);
                    }
                }
                this.company.ShiftSchedule.Add(shift);
                if (RefreshCalendar != null)
                    RefreshCalendar(this.shift.date);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
