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
            for (int i = 0; i < workShifts.Count; i++)
            {
                
            }
        }
        private void LoadMonth()
        {
            Grid mainGrid = (Grid)window.FindName("calendarGrid");
            mainGrid.Children.Clear();
            for (int i = 1; i < DateTime.DaysInMonth(indexYear, indexMonth) + 1; i++)
            {
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
                Button btn;
                for (int j = 0; j < 3; j++)
                {
                    btn = new Button();
                    btn.BorderThickness = new Thickness(1);
                    btn.HorizontalContentAlignment = HorizontalAlignment.Center;
                    btn.VerticalAlignment = VerticalAlignment.Top;
                    btn.Padding = new Thickness(1);
                    btn.Background = Brushes.Gray;


                    switch (j)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                    }
                    sPanel.Children.Add(btn);
                }


                grid.Children.Add(sPanel);
                Grid.SetRow(sPanel, 1);

                Grid.SetRow(grid, i / 7);
                Grid.SetColumn(grid, i % 7);
                mainGrid.Children.Add(grid);
            }
        }




        public class Day
        {

        }
        public enum ViewMode
        {
            YEAR,
            MONTH
        }
    }
}

