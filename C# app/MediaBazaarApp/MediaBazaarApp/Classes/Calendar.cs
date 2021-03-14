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

        //Temporary variables for debugging!
        private Random rnd = new Random();
        //End temp

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
                            Opacity = .7
                        };
                        buttons[j].Click += Calendar_Button_Click;
                        switch (j)
                        {
                            case 0:
                                buttons[j].Content = "Morning";
                                buttons[j].Background = Brushes.Yellow;
                                break;
                            case 1:
                                buttons[j].Content = "Afternoon";
                                buttons[j].Background = Brushes.White;
                                break;
                            case 2:
                                buttons[j].Content = "Night";
                                buttons[j].Background = Brushes.RosyBrown;
                                break;
                        }
                    }
                }

                for (int j = 0; j < workShifts.Count; j++)
                {
                    if (workShifts[j].Year == indexYear && workShifts[j].Month == indexMonth && workShifts[j].Day == i)
                    {
                        todaysWorkShifts[(int)workShifts[j].Shift] = workShifts[j];
                    }
                }

                for (int j = 0; j < todaysWorkShifts.Length; j++)
                {
                    if (todaysWorkShifts[j] != null)
                    {
                        buttons[(int)workShifts[j].Shift] = new Button
                        {
                            BorderThickness = new Thickness(1),
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Top,
                            Padding = new Thickness(1),
                            Background = Brushes.Gray,
                            Content = workShifts[j].ID,
                            DataContext = workShifts[j]
                        };
                        switch (workShifts[j].Shift)
                        {
                            case Shift.MORNING:
                                buttons[(int)workShifts[j].Shift].Background = Brushes.YellowGreen;
                                break;
                            case Shift.DAY:
                                buttons[(int)workShifts[j].Shift].Background = Brushes.Green;
                                break;
                            case Shift.NIGHT:
                                buttons[(int)workShifts[j].Shift].Background = Brushes.Brown;
                                break;
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
            Button btn = (Button)sender;
            if (btn.DataContext != null)
            {
                //Workshift assigned
                WorkShift workShift = (WorkShift)btn.DataContext;
            }
            else
            {
                //Workshift not assigned
            }
        }

        public enum ViewMode
        {
            YEAR,
            MONTH
        }
    }
}

