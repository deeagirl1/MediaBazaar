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
using MediaBazaarApp.Classes;
using MediaBazaarApp.Popups;

namespace MediaBazaarApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Classes.Calendar calendar;
        private Person person;
        private Company company;
        private Add_Employee addEmployeeForm;
        private EditEmployee editEmployeeForm;
        private AccountManager account = new AccountManager();

        private List<ShopWorker> employees;
        public MainWindow(Company company, Person person)
        {
<<<<<<< HEAD
            Loaded += OnLoad;
            InitializeComponent();
            this.company = company;
            this.person = person;
            Loaded += OnLoad;
            this.employees = this.company.ShopWorkers.ToList();
            this.lvShopWorkers.ItemsSource = this.employees;
            this.lblUserString.Content = $"Hello, {this.person.FirstName}";



            MessageBox.Show(person.Username);

            ShopWorker emp = new ShopWorker(33,
                                                    "A",
                                                    "A",
                                                    "A7fdsf74",
                                                    "B37fsdf74",
                                                    "C",
                                                    new Department(2, "Electronics"),
                                                    new Address("S", "S", "S", "S", "S", ""),
                                                    new DateTime(1990, 05, 30),
                                                    "VBMN321321",
                                                    new Status(2, ""),
                                                    new DateTime(2020, 05, 30),
                                                    new DateTime(),
                                                    new Contract(2, true, 32),
                                                    Convert.ToDecimal(15.55));

            //this.company.ShopWorkers.Edit(emp);
            //this.company.ShopWorkers.Add(emp);
=======
            try
            {
                Loaded += OnLoad;
                InitializeComponent();
                this.company = company;
                this.person = person;
                Loaded += OnLoad;

                this.employees = this.company.ShopWorkers.ToList();
                this.lvShopWorkers.ItemsSource = this.employees;
                this.lblUserString.Content = $"Hello , {person.FirstName}";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
>>>>>>> 85393258dfd3a9637bd360d469ece4dddfe385b5
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            try
            {
                calendar = new Classes.Calendar(this, company.ShiftSchedule.ToList());
                this.lblMonthYear.Content = $"{this.calendar.Year}, {this.calendar.Month}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                calendar.NextMonth();
                this.lblMonthYear.Content = $"{this.calendar.Year}, {this.calendar.Month}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                calendar.PreviousMonth();
                this.lblMonthYear.Content = $"{this.calendar.Year}, {this.calendar.Month}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.addEmployeeForm = new Add_Employee(this.company);
                this.addEmployeeForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.employees = this.company.ShopWorkers.ToList();
                this.lvShopWorkers.ItemsSource = this.employees;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.lvShopWorkers.SelectedItem != null)
                {
                    ShopWorker worker = ((ShopWorker)this.lvShopWorkers.SelectedItem);
                    this.editEmployeeForm = new EditEmployee(this.company, worker);
                    this.editEmployeeForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.tbNewPassRepeat.Text == this.tbNewPass.Text)
                {
                    this.company.AccountManager.ChangePassword(this.person.Username,
                                        this.tbCurrentPass.Text, this.tbNewPass.Text);
                    MessageBox.Show("Suucessfully changed");
                }
                else throw new ArgumentException("Passwords do not match");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefreshCalendar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                calendar = new Classes.Calendar(this, company.ShiftSchedule.ToList());
                this.lblMonthYear.Content = $"{this.calendar.Year}, {this.calendar.Month}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Sort_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.employees = this.company.ShopWorkers.ToList();
                this.employees.Sort(new EmployeeSort());
                this.lvShopWorkers.ItemsSource = this.employees;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstName = tb_FirstName.Text;
                string lastName = tb_LastName.Text;
                string email = tb_Email.Text;
                string username = firstName.Substring(0, 3).ToLower() + lastName.Substring(0, 3).ToLower();
                string password = GeneratePasswords();




                if ((bool)rb_Adminstrator.IsChecked)
                {
                    account.Add(new Administrator(firstName, lastName, email, username, password));
                    System.Windows.Forms.MessageBox.Show($"Username: {username}, Password: {password}" + "\n Please note them down!");
                }
                    
                    else if ((bool)rb_Manager.IsChecked)
                    {
                        account.Add(new Manager(firstName, lastName, email, username, password));
                        System.Windows.Forms.MessageBox.Show($"Username: {username}, Password: {password}" + "\n Please note them down!");
                    }
                
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("All fields must be completed");
            }
        }


        public static string GeneratePasswords()
        {
            int lenght = 8;
            char[] passwordGenerated = new char[lenght];
            Random rand = new Random();
          
            for (int i = 0; i < lenght; i++)
            {
                var passCharacter = rand.Next(65, 91);
                passwordGenerated[i] = (char)passCharacter;
            }
            var finishedPassword = new String(passwordGenerated);
            return finishedPassword;
        }


    }
}
