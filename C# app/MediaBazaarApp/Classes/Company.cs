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
        public readonly ProductCollection Products = new ProductCollection(new ProductDB());
        public readonly AnnouncementCollection Announcements = new AnnouncementCollection();
        public readonly ProductRequestMediator Requests = new ProductRequestMediator(new ProductRequestDAL());
        public readonly DepartmentMediator Departments = new DepartmentMediator(new DepartmentDAL());
        public readonly AccountManager AccountManager = new AccountManager();
        public readonly MessageCollection Messages = new MessageCollection();
        public readonly AutoScheduler AutoScheduler = new AutoScheduler();
        public readonly ShiftSchedule ShiftSchedule = new ShiftSchedule();
        public readonly List<Contract> Contracts = new List<Contract>();
        public readonly EmployeeList ShopWorkers= new EmployeeList();
        public readonly List<Status> Statuses = new List<Status>();
        public readonly Statistics Statistics = new Statistics();
        public readonly List<Shift> Shifts = new List<Shift>();
        public Company()
        {
          
            this.getContracts();
            this.getStatuses();
        }
        public Department GetDepartmentByID(int ID)
        {
            foreach(Department d in this.Departments.GetDepartments())
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
