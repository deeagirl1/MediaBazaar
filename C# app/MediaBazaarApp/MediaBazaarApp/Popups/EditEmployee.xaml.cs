﻿using System;
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
using System.Windows.Shapes;
using MediaBazaarApp.Classes;

namespace MediaBazaarApp.Popups
{
    /// <summary>
    /// Interaction logic for EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        private ShopWorker worker;
        private Company company;

        public EditEmployee(Company company, ShopWorker worker)
        {
            InitializeComponent();
            this.company = company;
            this.worker = worker;
            this.cbx_Department.ItemsSource = this.company.Departments;
            this.cbx_Contract.ItemsSource = this.company.Contracts;
            this.cbx_Status.ItemsSource = this.company.Statuses;
            fillFields();
        }

        private void fillFields()
        {
            this.tb_Country.Text = this.worker.HomeAddress.Country;
            this.tb_City.Text = this.worker.HomeAddress.City;
            this.tb_Street.Text = this.worker.HomeAddress.Street;
            this.tb_AddressAddition.Text = this.worker.HomeAddress.Addition;
            this.tb_ZipCode.Text = this.worker.HomeAddress.ZipCode;
            this.tb_StreetNumber.Text = this.worker.HomeAddress.StreetNumber;
            this.tb_Email.Text = this.worker.Email;
            this.dp_LastHireDate.SelectedDate = this.worker.LastWorkingDay;
            this.tb_HourlyWage.Text = Convert.ToString(this.worker.HourlyWage);
            this.tb_AccountNumber.Text = this.worker.BankAccount;
            this.cbx_Department.SelectedItem = this.company.GetDepartmentByID(this.worker.WorksAt.ID);
            this.cbx_Contract.SelectedItem = this.company.GetContractByID(this.worker.Contract.ID);
            this.cbx_Status.SelectedItem = this.company.GetStatusByID(this.worker.Status.ID);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.worker.HomeAddress.Country = this.tb_Country.Text;
            this.worker.HomeAddress.City = this.tb_City.Text;
            this.worker.HomeAddress.Street = this.tb_Street.Text;
            this.worker.HomeAddress.Addition = this.tb_AddressAddition.Text;
            this.worker.HomeAddress.ZipCode = this.tb_ZipCode.Text;
            this.worker.HomeAddress.StreetNumber = this.tb_StreetNumber.Text;
            this.worker.Email = this.tb_Email.Text;
            this.worker.LastWorkingDay = Convert.ToDateTime(this.dp_LastHireDate.SelectedDate);
            this.worker.HourlyWage = Convert.ToDecimal(this.tb_HourlyWage.Text);
            this.worker.BankAccount = this.tb_AccountNumber.Text;
            this.worker.WorksAt = ((Department)this.cbx_Department.SelectedItem);
            this.worker.Contract = ((Contract)this.cbx_Contract.SelectedItem);
            this.worker.Status = ((Status)this.cbx_Status.SelectedItem);

            this.company.ShopWorkers.Edit(worker);
            this.Close();
        }
    }
}
