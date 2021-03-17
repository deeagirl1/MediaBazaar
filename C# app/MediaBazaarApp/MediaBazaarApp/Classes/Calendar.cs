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
        private int[] lastMonthDays { get => new int[] { DateTime.DaysInMonth(indexYear, indexMonth-1) }; }
        private int[] nextMonthDays { get => new int[] { DateTime.DaysInMonth(indexYear, indexMonth+1) }; }

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
            Grid[] grids = new Grid[7 * 6];
            Button[] buttons;
            StackPanel sPanel;
            RowDefinition row;
            Label lbl;
            Border b;
            for (int i = 0; i < grids.Length; i++)
            {
                buttons = new Button[] { null, null, null };
                grids[i] = new Grid()
                {
                    Margin = new Thickness(2),
                    Background = Brushes.WhiteSmoke
                };
                row = new RowDefinition
                {
                    Height = new GridLength(30, GridUnitType.Star)
                };
                grids[i].RowDefinitions.Add(row);
                row = new RowDefinition
                {
                    Height = new GridLength(60)
                };
                b = new Border()
                {
                    BorderThickness = new Thickness(2),
                    BorderBrush = Brushes.Black,
                    Opacity = .5,
                    CornerRadius = new CornerRadius(25, 3, 120, 60)
                };
                grids[i].Children.Add(b);
                grids[i].RowDefinitions.Add(row);
                sPanel = new StackPanel();
                lbl = new Label
                {
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    FontSize = 25,
                    Padding = new Thickness(5),
                    Content = 0
                };
                sPanel.Children.Add(lbl);
                grids[i].Children.Add(sPanel);
                Grid.SetRow(sPanel, 0);
                sPanel = new StackPanel();
                for (int j = 0; j < buttons.Length; j++)
                {
                    buttons[j] = new Button
                    {
                        IsEnabled = false
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
                    sPanel.Children.Add(buttons[j]);
                }
                grids[i].Children.Add(sPanel);
                Grid.SetRow(sPanel, 1);
                Grid.SetRow(grids[i], i / 7);
                Grid.SetColumn(grids[i], i % 7);
                Grid.SetRowSpan(b, 2);
                grids[i].Opacity = .4;
            }
            WorkShift[] todaysWorkShifts;
            int dayOfMonth = DateTime.DaysInMonth(indexYear, indexMonth - 1) - (int)(new DateTime(indexYear, indexMonth, 1).DayOfWeek) + 1;
            for (int i = 0; i < (int)(new DateTime(indexYear, indexMonth, 1).DayOfWeek); i++)
            {
                lbl = grids[i].Children.OfType<StackPanel>().ToArray()[0].Children.OfType<Label>().ToArray()[0];
                lbl.Content = dayOfMonth++;
            }
            dayOfMonth = 1;
            for (int i = (int)(new DateTime(indexYear, indexMonth, 1).DayOfWeek); i < (int)(new DateTime(indexYear, indexMonth, 1).DayOfWeek)+ DateTime.DaysInMonth(indexYear, indexMonth); i++)
            {
                grids[i].Opacity = 1;
                todaysWorkShifts = new WorkShift[] { null, null, null };
                for (int j = 0; j < workShifts.Count; j++)
                {
                    if (workShifts[j].Year == indexYear && workShifts[j].Month == indexMonth && workShifts[j].Day == i)
                    {
                        todaysWorkShifts[(int)workShifts[j].Shift] = workShifts[j];
                    }
                }
                todaysWorkShifts.OrderBy(s => s.Shift);

                lbl = grids[i].Children.OfType<StackPanel>().ToArray()[0].Children.OfType<Label>().ToArray()[0];
                lbl.Content = dayOfMonth++;
                buttons = grids[i].Children.OfType<StackPanel>().ToArray()[1].Children.OfType<Button>().ToArray();
                for (int j = 0; j < buttons.Length; j++)
                {
                    buttons[j].IsEnabled = true;
                    buttons[j].BorderThickness = new Thickness(1);
                    buttons[j].HorizontalContentAlignment = HorizontalAlignment.Center;
                    buttons[j].VerticalAlignment = VerticalAlignment.Top;
                   
                 //   buttons[j].Background = Brushes.Gray;
                    
                    if (todaysWorkShifts[j] != null)
                    {
                        buttons[j].Content = workShifts[j].ID;
                        buttons[j].DataContext = workShifts[j];
                        switch (workShifts[j].Shift)
                        {
                            case Shift.Morning:
                                buttons[j].Background = Brushes.YellowGreen;
                                break;
                            case Shift.Day:
                                buttons[j].Background = Brushes.Green;
                                break;
                            case Shift.Night:
                                buttons[j].Background = Brushes.Brown;
                                break;
                        }
                    }
                    else
                    {
                        buttons[j].Content = (Shift)j;
                    }
                }
            }
            dayOfMonth = 1;
            for (int i = (int)(new DateTime(indexYear, indexMonth, 1).DayOfWeek) + DateTime.DaysInMonth(indexYear, indexMonth); i < grids.Length; i++)
            {
                lbl = grids[i].Children.OfType<StackPanel>().ToArray()[0].Children.OfType<Label>().ToArray()[0];
                lbl.Content = dayOfMonth++;
            }
            for (int i = 0; i < grids.Length; i++)
            {
                mainGrid.Children.Add(grids[i]);
            }
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

