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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaBazaarApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Calendar calendar;
        public MainWindow()
        {
            Loaded += OnLoad;
            InitializeComponent();
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            calendar = new Calendar(this);
        }


        public class Calendar
        {
            private MainWindow mainWindow;
            private int indexYear, indexMonth;
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

            public Calendar(MainWindow window)
            {
                mainWindow = window;
                DateTime currentTime = DateTime.Now;
                indexYear = currentTime.Year;
                indexMonth = currentTime.Month;
                CurrentViewMode = ViewMode.MONTH;
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
                    lbl.Padding = new Thickness(0);
                    lbl.Content = i;
                    sPanel.Children.Add(lbl);
                    grid.Children.Add(sPanel);
                    Grid.SetRow(sPanel, 0);


                    sPanel = new StackPanel();
                    for (int j = 0; j < 3; j++)
                    {
                        lbl = new Label();
                        lbl.HorizontalContentAlignment = HorizontalAlignment.Center;
                        lbl.VerticalAlignment = VerticalAlignment.Top;
                        lbl.Padding = new Thickness(0);
                        if (j == 0)
                        {
                            lbl.Foreground = Brushes.DarkOrange;
                            lbl.Content = "Empty";
                        }
                        else
                        {
                            lbl.Content = "Joe " + rnd.Next(1000, 9999);
                        }
                        sPanel.Children.Add(lbl);
                    }
                    grid.Children.Add(sPanel);
                    Grid.SetRow(sPanel, 1);

                    Grid.SetRow(grid, 1 + i / 7);
                    Grid.SetColumn(grid, i % 7);
                    mainWindow.calendarGrid.Children.Add(grid);
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
}