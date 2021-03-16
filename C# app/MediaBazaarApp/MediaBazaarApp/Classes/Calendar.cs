using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MediaBazaarApp.Classes
{
    class Calendar
    {
        private Window window;
        private int indexYear, indexMonth;
        private List<WorkShift> workShifts;
        private Grid mainGrid;
        private DoubleAnimation doubleAnimation;
        private Storyboard storyboard;
        //TODO: Handle days with no workshits

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
            mainGrid = (Grid)window.FindName("calendarGrid");
            doubleAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = .6,
                Duration = new Duration(TimeSpan.FromMilliseconds(150)),
                AutoReverse = true
            };
            storyboard = new Storyboard
            {
                Children =
                {
                    doubleAnimation
                }
            };
            Storyboard.SetTarget(doubleAnimation, mainGrid);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Grid.OpacityProperty));
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
            storyboard.Begin(mainGrid);
            mainGrid.Children.Clear();
            int dayOfMonth = 1;

            for (int i = (int)(new DateTime(indexYear, indexMonth, 1).DayOfWeek);  dayOfMonth -1 < DateTime.DaysInMonth(indexYear, indexMonth); i++)
            {
                Button[] buttons = new Button[] { null, null, null };
                WorkShift[] todaysWorkShifts = new WorkShift[] { null, null, null };

                for (int j = 0; j < workShifts.Count; j++)
                {
                    if (workShifts[j].Year == indexYear && workShifts[j].Month == indexMonth && workShifts[j].Day == i)
                    {
                        todaysWorkShifts[(int)workShifts[j].Shift] = workShifts[j];
                    }
                }
                todaysWorkShifts.OrderBy(s => s.Shift);

                for (int j = 0; j < buttons.Length; j++)
                {
                    buttons[j] = new Button
                    {
                        BorderThickness = new Thickness(1),
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Top,
                        Padding = new Thickness(0),
                        Background = Brushes.Gray,
                        FontSize = 13,
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


                for (int j = 0; j < todaysWorkShifts.Length; j++)
                {
                    if (todaysWorkShifts[j] != null)
                    {
                        buttons[j].BorderThickness = new Thickness(1);
                        buttons[j].HorizontalContentAlignment = HorizontalAlignment.Center;
                        buttons[j].VerticalAlignment = VerticalAlignment.Top;
                        buttons[j].Padding = new Thickness(1);
                        buttons[j].Background = Brushes.Gray;
                        buttons[j].Content = workShifts[j].ID;
                        buttons[j].DataContext = workShifts[j];

                        switch (workShifts[j].Shift)
                        {
                            case Shift.MORNING:
                                buttons[j].Background = Brushes.YellowGreen;
                                break;
                            case Shift.DAY:
                                buttons[j].Background = Brushes.Green;
                                break;
                            case Shift.NIGHT:
                                buttons[j].Background = Brushes.Brown;
                                break;
                        }
                    }
                }


                Grid grid = new Grid
                {
                    Margin = new Thickness(2),
                    Background=Brushes.WhiteSmoke
                };




                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(30, GridUnitType.Star);
                grid.RowDefinitions.Add(row);
                row = new RowDefinition();
                row.Height = new GridLength(60);
                grid.RowDefinitions.Add(row);
                StackPanel sPanel = new StackPanel();
                Label lbl = new Label
                {
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    FontSize = 25,
                    Padding = new Thickness(5),
                    Content = dayOfMonth++
                };
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


                Border b;
                b = new Border()
                {
                    BorderThickness = new Thickness(2),
                    BorderBrush = Brushes.Black,
                    Opacity=.5
                };
                b.CornerRadius = new CornerRadius(10, 10, 2, 2);
                                grid.Children.Add(b);
                Grid.SetRowSpan(b, 2);
                mainGrid.Children.Add(grid);
            }

        }

        private int GetLastDayOfMonth()
        {
            return 31;
        }

        private void Calendar_Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.DataContext != null)
            {
                //Workshift assigned
                WorkShift workShift = (WorkShift)btn.DataContext;
                workShift.ShowDialog();
            }
            else
            {               
                //Workshift not assigned

                //Create new WorkShift maybe and add it everywhere 6
                
                //Just let Bohdan decide I guess
            }
        }
        

        public enum ViewMode
        {
            YEAR,
            MONTH
        }
    }
}

