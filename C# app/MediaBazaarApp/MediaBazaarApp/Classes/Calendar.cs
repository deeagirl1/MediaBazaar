//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Media;

//namespace MediaBazaarApp.Classes
//{
//    class Calendar
//    {
//        private Window window;
//        private int indexYear, indexMonth;
//        private List<WorkShift> workShifts;

//        //TODO: Handle days with no workshits

//        public ViewMode CurrentViewMode
//        {
//            get => _viewMode;
//            set
//            {
//                _viewMode = value;
//                Reload();
//            }
//        }
//        private ViewMode _viewMode;

//        public Calendar(Window window, List<WorkShift> workShifts)
//        {
//            this.window = window;
//            this.workShifts = workShifts;
//            DateTime currentTime = DateTime.Now;
//            indexYear = currentTime.Year;
//            indexMonth = currentTime.Month;
//            CurrentViewMode = ViewMode.MONTH;
//        }
//        public int Year
//        {
//            get { return this.indexYear; }
//        }
//        public string Month
//        {
//            get
//            {
//                string fullMonthName = new DateTime(2015, this.indexMonth, 1).ToString("MMMM");
//                return fullMonthName;
//            }
//        }

//        #region Boring year and month stuff
//        public void NextYear()
//        {
//            indexYear++;
//            Reload();
//        }
//        public void PreviousYear()
//        {
//            indexYear--;
//            Reload();
//        }
//        public void NextMonth()
//        {
//            if (indexMonth != 12)
//            {
//                indexMonth++;
//            }
//            else
//            {
//                indexMonth = 1;
//                indexYear++;
//            }
//            Reload();
//        }
//        public void PreviousMonth()
//        {
//            if (indexMonth != 1)
//            {
//                indexMonth--;
//            }
//            else
//            {
//                indexMonth = 12;
//                indexYear--;
//            }
//            Reload();
//        }

//        #endregion

//        private void Reload()
//        {
//            switch (CurrentViewMode)
//            {
//                case ViewMode.YEAR:
//                    break;
//                case ViewMode.MONTH:
//                    LoadMonth();
//                    break;
//            }
//        }
//        private void LoadMonth()
//        {
//            Grid mainGrid = (Grid)window.FindName("calendarGrid");
//            mainGrid.Children.Clear();
//            for (int i = 1; i < DateTime.DaysInMonth(indexYear, indexMonth) + 1; i++)
//            {
//                Button[] buttons = new Button[] { null, null, null };
//                //WorkShift[] todaysWorkShifts = new WorkShift[] { null, null, null };

//                //for (int j = 0; j < workShifts.Count; j++)
//                //{
//                //    if (workShifts[j].date.Year == indexYear && workShifts[j].date.Month == indexMonth && workShifts[j].date.Day == i)
//                //    {
//                //        todaysWorkShifts[(int)workShifts[j].shift.ID] = workShifts[j];
//                //    }
//                //}
//                //todaysWorkShifts.OrderBy(s => s.Shift);

//                for (int j = 0; j < buttons.Length; j++)
//                {
//                    buttons[j] = new Button
//                    {
//                        BorderThickness = new Thickness(1),
//                        HorizontalContentAlignment = HorizontalAlignment.Center,
//                        VerticalAlignment = VerticalAlignment.Top,
//                        Padding = new Thickness(1),
//                        Background = Brushes.Gray,
//                        Opacity = .7
//                    };
//                    buttons[j].Click += Calendar_Button_Click;
//                    switch (j)
//                    {
//                        case 0:
//                            buttons[j].Content = "Morning";
//                            buttons[j].Background = Brushes.Yellow;
//                            break;
//                        case 1:
//                            buttons[j].Content = "Afternoon";
//                            buttons[j].Background = Brushes.White;
//                            break;
//                        case 2:
//                            buttons[j].Content = "Night";
//                            buttons[j].Background = Brushes.RosyBrown;
//                            break;
//                    }
//                }


//                //for (int j = 0; j < todaysWorkShifts.Length; j++)
//                //{
//                //    if (todaysWorkShifts[j] != null)
//                //    {
//                //        buttons[j].BorderThickness = new Thickness(1);
//                //        buttons[j].HorizontalContentAlignment = HorizontalAlignment.Center;
//                //        buttons[j].VerticalAlignment = VerticalAlignment.Top;
//                //        buttons[j].Padding = new Thickness(1);
//                //        buttons[j].Background = Brushes.Gray;
//                //        buttons[j].Content = workShifts[j].ID;
//                //        buttons[j].DataContext = workShifts[j];

//                //        switch (workShifts[j].Shift)
//                //        {
//                //            case Shift.MORNING:
//                //                buttons[j].Background = Brushes.YellowGreen;
//                //                break;
//                //            case Shift.DAY:
//                //                buttons[j].Background = Brushes.Green;
//                //                break;
//                //            case Shift.NIGHT:
//                //                buttons[j].Background = Brushes.Brown;
//                //                break;
//                //        }
//                //    }
//                //}




//                Grid grid = new Grid
//                {
//                    Margin = new Thickness(2),
//                    Background = Brushes.DarkGray
//                };
//                RowDefinition row = new RowDefinition();
//                row.Height = new GridLength(30, GridUnitType.Star);
//                grid.RowDefinitions.Add(row);
//                row = new RowDefinition();
//                row.Height = new GridLength(60);
//                grid.RowDefinitions.Add(row);
//                StackPanel sPanel = new StackPanel();
//                Label lbl = new Label
//                {
//                    HorizontalContentAlignment = HorizontalAlignment.Center,
//                    VerticalAlignment = VerticalAlignment.Top,
//                    FontSize = 15,
//                    Padding = new Thickness(5),
//                    Content = i
//                };
//                sPanel.Children.Add(lbl);
//                grid.Children.Add(sPanel);
//                Grid.SetRow(sPanel, 0);
//                sPanel = new StackPanel();
//                for (int j = 0; j < buttons.Length; j++)
//                {
//                    sPanel.Children.Add(buttons[j]);
//                }
//                grid.Children.Add(sPanel);
//                Grid.SetRow(sPanel, 1);
//                Grid.SetRow(grid, i / 7);
//                Grid.SetColumn(grid, i % 7);
//                mainGrid.Children.Add(grid);
//            }
//        }

//        private void Calendar_Button_Click(object sender, RoutedEventArgs e)
//        {
//            Button btn = (Button)sender;
//            MessageBox.Show("Test");
//            if (btn.DataContext != null)
//            {
//                //Workshift assigned
//                WorkShift workShift = (WorkShift)btn.DataContext;
//                //
//                //workShift.ShowDialog();
//                //
//                //window = new Popups.WorkShiftWindow(workShift);
//                //window.Show();
//                MessageBox.Show("Test");
//            }
//            else
//            {
//                //Workshift not assigned

//                //Create new WorkShift maybe and add it everywhere 6
//            }
//        }


//        public enum ViewMode
//        {
//            YEAR,
//            MONTH
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MediaBazaarApp.Classes
{
    class Calendar
    {
        private Grid parentGrid;
        private int indexYear, indexMonth;
        private List<WorkShift> workShifts;


        public ViewMode CurrentViewMode
        {
            get => _viewMode;
            set
            {
                _viewMode = value;
                Reload();
            }
        }
        private ViewMode _viewMode;

        public Calendar(Grid grid, List<WorkShift> workShifts)
        {
            this.parentGrid = grid;
            this.workShifts = workShifts;
            DateTime currentTime = DateTime.Now;
            indexYear = currentTime.Year;
            indexMonth = currentTime.Month;
            CurrentViewMode = ViewMode.MONTH;
        }
        public int Year
        {
            get { return this.indexYear; }
        }
        public string Month
        {
            get
            {
                string fullMonthName = new DateTime(2015, this.indexMonth, 1).ToString("MMMM");
                return fullMonthName;
            }
        }


        #region Boring year and month stuff
        public void NextYear()
        {
            indexYear++;
            Reload();
        }
        public void PreviousYear()
        {
            indexYear--;
            Reload();
        }
        public void Refresh()
        {
            Reload();
        }
        public void NextMonth()
        {
            if (indexMonth != 12)
            {
                indexMonth++;
            }
            else
            {
                indexMonth = 1;
                indexYear++;
            }
            Reload();
        }
        public void PreviousMonth()
        {
            if (indexMonth != 1)
            {
                indexMonth--;
            }
            else
            {
                indexMonth = 12;
                indexYear--;
            }
            Reload();
        }

        #endregion


        private void Reload()
        {
            switch (CurrentViewMode)
            {
                case ViewMode.YEAR:
                    break;
                case ViewMode.MONTH:
                    LoadMonth();
                    break;
            }
        }
        private void LoadMonth()
        {
            Grid mainGrid = parentGrid;
            mainGrid.Children.Clear();
            for (int i = 1; i < DateTime.DaysInMonth(indexYear, indexMonth) + 1; i++)
            {
                Button[] buttons = new Button[] { null, null, null };
                WorkShift[] todaysWorkShifts = new WorkShift[] { null, null, null };

                for (int j = 0; j < 3; j++)
                {
                    if (buttons[j] == null)
                    {
                        buttons[j] = new Button
                        {
                            BorderThickness = new Thickness(1),
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Top,
                            Padding = new Thickness(1),
                            Background = Brushes.Gray,
                            Opacity = .7,
                            //Content = new DateTime(indexYear, indexMonth, i),
                            //DataContext = new WorkShift(new DateTime(indexYear, indexMonth, i))
                        };
                        buttons[j].Click += Calendar_Button_Click;
                        buttons[j].Background = Brushes.LightGreen;
                        switch (j)
                        {
                            case 0:
                                buttons[j].Content = "Morning";
                                //buttons[j].Background = Brushes.Yellow;
                                buttons[j].DataContext = new DateTime(indexYear, indexMonth, i, 7, 0, 0);
                                break;
                            case 1:
                                buttons[j].Content = "Afternoon";
                                //buttons[j].Background = Brushes.White;
                                buttons[j].DataContext = new DateTime(indexYear, indexMonth, i, 15, 0, 0);
                                break;
                            case 2:
                                buttons[j].Content = "Night";
                                //buttons[j].Background = Brushes.RosyBrown;
                                buttons[j].DataContext = new DateTime(indexYear, indexMonth, i, 23, 0, 0);
                                break;
                        }
                        foreach (WorkShift w in this.workShifts)
                        {
                            if (w.date.Year == indexYear && w.date.Month == indexMonth && w.date.Day == i)
                            {

                                if (j == 0 && w.shift.ID == 1)
                                {
                                    buttons[j].DataContext = w;
                                    if (w.AssignedEmployees.Count > 0)
                                    {
                                        buttons[j].Content = $"Morning  {w.AssignedEmployees.Count}";
                                        buttons[j].Background = Brushes.Yellow;
                                    }
                                }
                                else if (j == 1 && w.shift.ID == 2)
                                {
                                    buttons[j].DataContext = w;

                                    if (w.AssignedEmployees.Count > 0)
                                    {
                                        buttons[j].Content = $"Day  {w.AssignedEmployees.Count}";
                                        buttons[j].Background = Brushes.Yellow;
                                    }
                                }
                                else if (j == 2 && w.shift.ID == 3)
                                {
                                    buttons[j].DataContext = w;
                                    if (w.AssignedEmployees.Count > 0)
                                    {
                                        buttons[j].Content = $"Night  {w.AssignedEmployees.Count}";
                                        buttons[j].Background = Brushes.Yellow;
                                    }
                                }
                            }
                        }
                    }
                }


                Grid grid = new Grid();
                grid.Margin = new Thickness(2);
                grid.Background = Brushes.DarkGray;
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(30, GridUnitType.Star);
                grid.RowDefinitions.Add(row);
                row = new RowDefinition();
                row.Height = new GridLength(60);
                grid.RowDefinitions.Add(row);
                StackPanel sPanel = new StackPanel();
                Label lbl = new Label();
                lbl.HorizontalContentAlignment = HorizontalAlignment.Center;
                lbl.VerticalAlignment = VerticalAlignment.Top;
                lbl.FontSize = 15;
                lbl.Padding = new Thickness(5);
                lbl.Content = i;
                sPanel.Children.Add(lbl);
                grid.Children.Add(sPanel);
                Grid.SetRow(sPanel, 0);

                sPanel = new StackPanel();
                for (int j = 0; j < buttons.Length; j++)
                {
                    sPanel.Children.Add(buttons[j]);
                }
                grid.Children.Add(sPanel);
                Grid.SetRow(sPanel, 1);
                Grid.SetRow(grid, i / 7);
                Grid.SetColumn(grid, i % 7);
                mainGrid.Children.Add(grid);
            }
        }
        private void Calendar_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                if (btn.DataContext is WorkShift)
                {
                    WorkShift w = (WorkShift)btn.DataContext;
                    if (w.date.Date < DateTime.Now.Date)
                        new WorkShiftWindow(w).Show();
                    else if (w.date.Date == DateTime.Now.Date)
                    {
                        if (DateTime.Now.Hour >= 7 && w.shift.ID == 1)
                            new WorkShiftWindow(w).Show();
                        else if (DateTime.Now.Hour >= 15 && w.shift.ID <= 2)
                            new WorkShiftWindow(w).Show();
                        else if (DateTime.Now.Hour >= 23 && w.shift.ID <= 3)
                            new WorkShiftWindow(w).Show();
                        else { new EditWorkShift(w).Show(); }
                    }
                    else { new EditWorkShift(w).Show(); }

                }
                else if (btn.DataContext is DateTime)
                {
                    DateTime dateTime = (DateTime)btn.DataContext;
                    if (dateTime > DateTime.Now)
                        new NewWorkshiftWindow(dateTime).Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public enum ViewMode
        {
            YEAR,
            MONTH
        }
    }
}