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
        public MainWindow()
        {
            Loaded += OnLoad;
            InitializeComponent();
        }

        //Delete variable later
        private Random rnd = new Random();

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            for (int i = 1; i < DateTime.DaysInMonth(currentTime.Year, currentTime.Month) +1; i++)
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
                calendarGrid.Children.Add(grid);
            }
        }
    }
}
