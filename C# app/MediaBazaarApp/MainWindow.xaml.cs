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
        private AddAnnouncement addAnnouncementForm;
        private EditAnnouncement editAnnouncementForm;
        private EditProduct editProductForm;
        private List<ShopWorker> employees;
        private AddDepartment addDepartmentForm;
        private EditDepartment editDepartmentForm;
        private ViewDepartment viewDepartmentForm;
        private AddUser addUserWindow;
        public MainWindow(Company company, Person person)
        {
            try
            {
                Loaded += OnLoad;
                InitializeComponent();
                this.company = company;
                this.person = person;
                Loaded += OnLoad;

                this.employees = this.company.ShopWorkers.ToList();
                this.lvShopWorkers.ItemsSource = this.employees;
                this.lvMessages.ItemsSource = this.company.Messages.ToList();
                this.lblUserString.Content = $"Hello , {person.FirstName}";
                this.cmb_ProductDepartments.ItemsSource = this.company.Departments.GetAll();
                this.lvUsers.ItemsSource = this.company.AccountManager.GetAllUsers();
                this.showDepartments();

                this.showAnnouncements();
                this.showProducts();
                this.showRequests();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            this.RefreshCalendar();
        }
        private void RefreshEmployees()
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
      
        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.addEmployeeForm = new Add_Employee(this.company);
                this.addEmployeeForm.EmployeeAdded += RefreshEmployees;
                this.addEmployeeForm.Show();
                this.employees = this.company.ShopWorkers.ToList();
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
                    this.editEmployeeForm.EmployeeEdited += RefreshEmployees;
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
                    MessageBox.Show("Sucessfully changed");
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
            this.RefreshCalendar();
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
    
        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = tb_Search.Text;
                this.employees = this.company.ShopWorkers.ToList();
                this.employees = FindPattern(name, employees);
                this.lvShopWorkers.ItemsSource = this.employees;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private List<ShopWorker> FindPattern(string name, List<ShopWorker> workers)
        {
            List<ShopWorker> temp = new List<ShopWorker>();
            foreach (ShopWorker worker in workers)
            {
                if (worker.ToString().Contains(name))
                {
                    temp.Add(worker);
                }
            }
            return temp;
        }
        private void btnRefreshMessages_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.lvMessages.ItemsSource = this.company.Messages.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void lvMessages_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Message message = (Message)this.lvMessages.SelectedItem;
                MessageBox.Show(message.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void RefreshCalendar()
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
        public void RefreshCalendar(DateTime date)
        {
            try
            {
                calendar = new Classes.Calendar(this, company.ShiftSchedule.ToList(), date);
                this.lblMonthYear.Content = $"{this.calendar.Year}, {this.calendar.Month}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnRefreshAnnouncements_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.showAnnouncements();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void btn_EditAnnouncement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.lvAnnouncements.SelectedItem != null)
                {
                    Announcement announcement = ((Announcement)this.lvAnnouncements.SelectedItem);
                    this.editAnnouncementForm = new EditAnnouncement(this.company, announcement);
                    this.editAnnouncementForm.Show();
                    this.showAnnouncements();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_AddAnnouncement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.addAnnouncementForm = new AddAnnouncement(this.company);
                this.addAnnouncementForm.Show();
                this.showAnnouncements();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void showAnnouncements()
        {
            try
            {
                this.lvAnnouncements.ItemsSource = this.company.Announcements.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnRefreshProducts_Click(object sender, RoutedEventArgs e)
        {
            this.showProducts();
        }
        private void btn_EditProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.lvProducts.SelectedItem != null)
                {
                    ListViewItem item = ((ListViewItem)this.lvProducts.SelectedItem);
                    Product product = (Product)item.Content;
                    this.editProductForm = new EditProduct(this.company, product);
                    this.editProductForm.Show();
                    this.showProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new AddProduct().Show();
                this.showProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void showProducts()
        {
            try
            {
                List<ListViewItem> items = new List<ListViewItem>();
                foreach (Product item in this.company.Products.ToList())
                {
                    ListViewItem OneItem = new ListViewItem();
                    if (item.Quantity < item.MinThreshold)
                    {
                        OneItem.Background = Brushes.IndianRed;
                    }
                    else
                    {
                        OneItem.Background = Brushes.LightGreen;
                    }
                    OneItem.Content = item;
                    items.Add(OneItem);
                    lvProducts.ItemsSource = items;
                }
                lvProducts.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnRequest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.lvProducts.SelectedItem != null)
                {
                    ListViewItem item = ((ListViewItem)this.lvProducts.SelectedItem);
                    Product product = (Product)item.Content;
                    new RequestAmountForm(product).Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showRequests()
        {
            try
            {
                this.lvRequests.ItemsSource = this.company.Requests.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showDepartments()
        {
            try
            {
                this.lvDepartments.ItemsSource = this.company.Departments.GetAll();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnRefreshRequests1_Click(object sender, RoutedEventArgs e)
        {
            this.showRequests();
        }

        private void lvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lvProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnRefreshRequests_Click(object sender, RoutedEventArgs e)
        {
            this.showRequests();
        }

        private void lvRequests_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (this.lvRequests.SelectedItem != null)
                {
                    ProductRequest req = (ProductRequest)this.lvRequests.SelectedItem;
                    if(req.RequestStatus.ID == 3)
                        MessageBox.Show(req.Comment);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefreshDepartments_Click(object sender, RoutedEventArgs e)
        {
            this.showDepartments();
        }

        private void btnAutoSchedule_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AutoScheduleWindow window = new AutoScheduleWindow();
                window.RefreshCalendar += this.RefreshCalendar;
                window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bindDepartmentsToCMB()
        {
            try
            {
                foreach(Department d in this.company.Departments.GetAll())
                {
                    this.cmb_ProductDepartments.Items.Add(d);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                addDepartmentForm = new AddDepartment(this.company);
                this.addDepartmentForm.Show();
                this.addDepartmentForm.DepartmentAdded += showDepartments;
                this.addDepartmentForm.DepartmentAdded += bindDepartmentsToCMB;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnEditDepartment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Department department = (Department)lvDepartments.SelectedItem;
                editDepartmentForm = new EditDepartment(this.company, department);
                this.editDepartmentForm.Show();
                this.editDepartmentForm.departmentEdited += showDepartments;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lvDepartments_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Department department = (Department)this.lvDepartments.SelectedItem;
                this.viewDepartmentForm = new ViewDepartment(this.company, department);
                this.viewDepartmentForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefreshDepartments1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.showDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_ApplyFilterDepartment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Product> products = new List<Product>();
                int id = ((Department)this.cmb_ProductDepartments.SelectedItem).ID;
                foreach(Product product in this.company.Products.ToList())
                {
                    if (product.Department.ID == id)
                        products.Add(product);
                }
                this.lvProducts.ItemsSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_AddUser_Click(object sender, RoutedEventArgs e)
        {
            this.addUserWindow = new AddUser(company);
            addUserWindow.Show();
        }
    }
}
