using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class Company : DBmanager
    {
        public readonly AccountManager AccountManager = new AccountManager();
        public readonly ShiftSchedule ShiftSchedule = new ShiftSchedule();
        public readonly EmployeeList ShopWorkers= new EmployeeList();
        public readonly List<Department> Departments = new List<Department>();
        public readonly List<Contract> Contracts = new List<Contract>();
        public readonly List<Status> Statuses = new List<Status>();
        public readonly List<Shift> Shifts = new List<Shift>();

        

        public Company()
        {
            this.getDepartments();
            this.getContracts();
            this.getStatuses();
        }

        public Department GetDepartmentByID(int ID)
        {
            foreach(Department d in this.Departments)
            {
                if (d.ID == ID)
                    return d;
            }
            return null;
        }

        public Contract GetContractByID(int ID)
        {
            foreach (Contract c in this.Contracts)
            {
                if (c.ID == ID)
                    return c;
            }
            return null;
        }
        public Status GetStatusByID(int ID)
        {
            foreach (Status s in this.Statuses)
            {
                if (s.ID == ID)
                    return s;
            }
            return null;
        }

        private void getDepartments()
        {
            string sql = "SELECT * FROM department";
            MySqlCommand cmd = new MySqlCommand(sql, this.GetConnection());
            MySqlDataReader reader = null;
            try
            {
                reader = this.OpenExecuteReader(cmd);
                this.Departments.Clear();
                while (reader.Read())
                {
                    Department dep = new Department(Convert.ToInt32(reader["ID"]),
                                                    Convert.ToString(reader["Name"]));
                    this.Departments.Add(dep);
                }
            }
            finally
            {
                this.CloseExecuteReader(reader);
            }
        }
        private void getContracts()
        {
            string sql = "SELECT * FROM contract";
            MySqlCommand cmd = new MySqlCommand(sql, this.GetConnection());
            MySqlDataReader reader = null;
            try
            {
                reader = this.OpenExecuteReader(cmd);
                this.Contracts.Clear();
                while (reader.Read())
                {
                    Contract contract = new Contract(Convert.ToInt32(reader["ID"]),
                                                Convert.ToBoolean(reader["Fixed"]),
                                                Convert.ToInt32(reader["Hours"]));

                    this.Contracts.Add(contract);
                }
            }
            finally
            {
                this.CloseExecuteReader(reader);
            }
        }
        private void getStatuses()
        {
            string sql = "SELECT * FROM employeeStatus";
            MySqlCommand cmd = new MySqlCommand(sql, this.GetConnection());
            MySqlDataReader reader = null;
            try
            {
                reader = this.OpenExecuteReader(cmd);
                this.Statuses.Clear();
                while (reader.Read())
                {
                    Status status = new Status(Convert.ToInt32(reader["ID"]),
                                                Convert.ToString(reader["Status"]));

                    this.Statuses.Add(status);
                }
            }
            finally
            {
                this.CloseExecuteReader(reader);
            }
        }
    }
    

}
