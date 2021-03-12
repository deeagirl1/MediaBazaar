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
        public View ViewMode
        {
            get => _viewMode;
            set
            {
                _viewMode = value;
                Reload();
            }
        }
        private View _viewMode;
        public ButtonView ButtonViewMode
        {
            get => _buttonViewMode;
            set
            {
                _buttonViewMode = value;
                Reload();
            }
        }
        private ButtonView _buttonViewMode;

        public Calendar(Window window)
        {
            this.window = window;
            DateTime currentTime = DateTime.Now;
            indexYear = currentTime.Year;
            indexMonth = currentTime.Month;
            ViewMode = View.MONTH;
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
            switch (ViewMode)
            {
                case View.YEAR:
                    break;
                case View.MONTH:
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
                Grid grid = new Grid();
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(31, GridUnitType.Star);
                grid.RowDefinitions.Add(row);
                row = new RowDefinition();
                row.Height = new GridLength(58, GridUnitType.Star);
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
                    btn.BorderThickness = new Thickness(0);
                    btn.HorizontalContentAlignment = HorizontalAlignment.Center;
                    btn.VerticalAlignment = VerticalAlignment.Top;
                    btn.Padding = new Thickness(1);
                    if (j == 0)
                    {
                        btn.Foreground = Brushes.DarkOrange;
                        btn.Content = "Empty";
                    }
                    else
                    {
                        btn.Content = "Joe " + rnd.Next(1000, 9999);
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
        public enum View
        {
            YEAR,
            MONTH
        }
        public enum ButtonView
        {
            SHIFTS,
            EMPLOYEES
        }
    }
}
