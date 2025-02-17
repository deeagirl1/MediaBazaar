﻿using System;
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
        private Window window;
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

        public Calendar(Window window, List<WorkShift> workShifts)
        {
            this.window = window;
            this.workShifts = workShifts;
            DateTime currentTime = DateTime.Now;
            indexYear = currentTime.Year;
            indexMonth = currentTime.Month;
            CurrentViewMode = ViewMode.MONTH;
        }
        public Calendar(Window window, List<WorkShift> workShifts, DateTime date)
        {
            this.window = window;
            this.workShifts = workShifts;
            DateTime currentTime = date;
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
            Grid mainGrid = (Grid)window.FindName("calendarGrid");
            mainGrid.Children.Clear();
            int day = 1;
            int weekDay = Convert.ToInt32(new DateTime(indexYear, indexMonth, 1).DayOfWeek);
            if (weekDay != 0) weekDay--;
            else weekDay = 6; 

            //Console.WriteLine(+1);
            for (int i = weekDay; day < DateTime.DaysInMonth(indexYear, indexMonth) + 1; i++)
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
                        buttons[j].Background = Brushes.Yellow;
                        switch (j)
                        {
                            case 0:
                                buttons[j].Content = "Morning";
                                //buttons[j].Background = Brushes.Yellow;
                                buttons[j].DataContext = new DateTime(indexYear, indexMonth, day, 7, 0, 0);
                                break;
                            case 1:
                                buttons[j].Content = "Afternoon";
                                //buttons[j].Background = Brushes.White;
                                buttons[j].DataContext = new DateTime(indexYear, indexMonth, day, 15, 0, 0);
                                break;
                            case 2:
                                buttons[j].Content = "Night";
                                //buttons[j].Background = Brushes.RosyBrown;
                                buttons[j].DataContext = new DateTime(indexYear, indexMonth, day, 23, 0, 0);
                                break;
                        }
                        foreach (WorkShift w in this.workShifts)
                        {
                            if (w.date.Year == indexYear && w.date.Month == indexMonth && w.date.Day == day)
                            {

                                if (j == 0 && w.shift.ID == 1)
                                {
                                    buttons[j].DataContext = w;
                                    if (w.AssignedEmployees.Count > 0)
                                    {
                                        buttons[j].Content = $"Morning  {w.AssignedEmployees.Count}";
                                        buttons[j].Background = Brushes.SpringGreen;
                                    }
                                }
                                else if (j == 1 && w.shift.ID == 2)
                                {
                                    buttons[j].DataContext = w;
                                    
                                    if (w.AssignedEmployees.Count > 0)
                                    {
                                        buttons[j].Content = $"Day  {w.AssignedEmployees.Count}";
                                        buttons[j].Background = Brushes.SpringGreen;
                                    }  
                                }
                                else if (j == 2 && w.shift.ID == 3)
                                {
                                    buttons[j].DataContext = w;
                                    if (w.AssignedEmployees.Count > 0)
                                    {
                                        buttons[j].Content = $"Night  {w.AssignedEmployees.Count}";
                                        buttons[j].Background = Brushes.SpringGreen;
                                    }
                                }
                            }
                        }
                    }
                }
                DateTime dateValue = new DateTime(this.indexYear, this.indexMonth, day);
                string dayOfWeek = dateValue.ToString("dddd");
                
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
                lbl.Content = day++;
                Label weekday = new Label();
                weekday.HorizontalContentAlignment = HorizontalAlignment.Center;
                weekday.VerticalAlignment = VerticalAlignment.Top;
                weekday.FontSize = 15;
                weekday.Padding = new Thickness(5);
                weekday.Content = dayOfWeek;
                sPanel.Children.Add(lbl);
                sPanel.Children.Add(weekday);
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
                //else Grid.SetColumn(grid, 7 % 8);

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
                    EditWorkShift editWindow = new EditWorkShift(w);
                    var win = this.window as MainWindow;
                    if (this.window is MainWindow)
                        editWindow.RefreshCalendar += win.RefreshCalendar;
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
                        else { editWindow.Show(); }
                    }
                    else { editWindow.Show(); }
                    
                }
                else if(btn.DataContext is DateTime)
                {
                    DateTime dateTime = (DateTime)btn.DataContext;
                    NewWorkshiftWindow window = new NewWorkshiftWindow(dateTime);
                    var win = this.window as MainWindow;
                    if (this.window is MainWindow)
                        window.RefreshCalendar += win.RefreshCalendar; 
                    if (dateTime > DateTime.Now)
                        window.Show();
                }
            }
            catch(Exception ex)
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


