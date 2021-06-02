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

namespace MediaBazaarApp
{
    
    /// <summary>
    /// Interaction logic for EditWorkShift.xaml
    /// </summary>
    public partial class EditWorkShift : Window
    {
        Company company;
        WorkShift shift;

        public delegate void Refresh(DateTime date);
        public event Refresh RefreshCalendar;
        public EditWorkShift(WorkShift shift)
        {
            try
            {
                InitializeComponent();

                this.company = new Company();
                this.shift = shift;

                foreach (ShopWorker s in this.shift.AssignedEmployees)
                {
                    this.lvAssignedEmployees.Items.Add(s);
                }
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
                this.shift.AssignedEmployees.Clear();
                foreach (Object obj in this.lvAssignedEmployees.Items)
                {
                    if (obj is ShopWorker)
                    {
                        ShopWorker worker = (ShopWorker)obj;
                        this.shift.AssignedEmployees.Add(worker);
                    }
                }
                this.company.ShiftSchedule.Update(shift);
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
