using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class ShiftSchedule : DBmanager
    {
        public List<WorkShift> workShifts { get; set; }
        private EmployeeList employeeList = new EmployeeList();
        public ShiftSchedule()
        {
            this.workShifts = new List<WorkShift>();
        }
        public int Add(WorkShift shift)
        {
            string sql = "INSERT INTO workshift (ShiftType, Date) VALUES (@ShiftType, @Date); " +
                         "Select LAST_INSERT_ID() ";

            MySqlParameter[] prms = new MySqlParameter[2];

            prms[0] = new MySqlParameter("@ShiftType",shift.shift.ID);
            prms[1] = new MySqlParameter("@Date", shift.date);

            shift.ID = Convert.ToInt32(this.ReadScalar(sql, prms));
            this.addAssignedEmployees(shift.ID, shift.AssignedEmployees);
            return shift.ID;
            
        }
        public IEnumerable<WorkShift> GetShiftsInPerioad(DateTime start, DateTime end)
        {
            foreach (WorkShift s in workShifts)
            {
                if(s.date >= start && s.date <= end)
                {
                    yield return s;
                }
            }
        }
        private List<ShopWorker> getAssignedEmployees(int id)
        {
            List<ShopWorker> temp = new List<ShopWorker>();
            string sql = $"SELECT e.id as EmployeeID from employee e inner join employeeassignment a on e.ID = a.EmployeeID where a.ShiftID = @ID";

            MySqlCommand cmd = new MySqlCommand(sql, this.GetConnection());
            MySqlDataReader reader = null;
            cmd.Parameters.Add(new MySqlParameter("@ID", id));

            try
            {
                reader = this.OpenExecuteReader(cmd);
                while (reader.Read())
                {
                    temp.Add(this.employeeList.GetEmployeeById(Convert.ToInt32(reader["EmployeeID"])));
                }
            }
            finally
            {
                this.CloseExecuteReader(reader);
            }
            return temp;
        }
        public List<WorkShift> ToList()
        {
            string sql = $"SELECT w.id as ShiftID, w.Date, s.ID as timeID, s.Name from workshift w inner join shifttime s on w.ShiftType = s.ID";

            MySqlCommand cmd = new MySqlCommand(sql, this.GetConnection());
            MySqlDataReader reader = null;
            List<WorkShift> shifts = new List<WorkShift>();
            try
            {
                reader = this.OpenExecuteReader(cmd);
                while (reader.Read())
                {
                    WorkShift shift = new WorkShift(Convert.ToInt32(reader["ShiftID"]),
                                                    Convert.ToDateTime(reader["Date"]),
                                                    new Shift(Convert.ToInt32(reader["timeID"]), Convert.ToString(reader["Name"])));
                    shifts.Add(shift);
                }
            }
            finally
            {
                this.CloseExecuteReader(reader);
            }
            foreach (WorkShift w in shifts)
            {
                foreach (ShopWorker s in getAssignedEmployees(w.ID))
                {
                    w.AssignedEmployees.Add(s);
                }
            }
            return shifts;
            throw new ArgumentException("No scheduled shifts founded");
        }
        private void addAssignedEmployees(int ShiftID, List<ShopWorker> employees)
        {
            foreach(ShopWorker s in employees)
            {
                this.assignEmployee(ShiftID, s.ID);
            }
        }
        private void assignEmployee(int ShiftID, int EmployeeID)
        {
            string sql = "INSERT INTO employeeassignment (ShiftID, EmployeeID) VALUES (@ShiftID, @EmployeeID); ";

            MySqlParameter[] prms = new MySqlParameter[2];

            prms[0] = new MySqlParameter("@ShiftID", ShiftID);
            prms[1] = new MySqlParameter("@EmployeeID", EmployeeID);


            this.ExecuteQuery(sql, prms);
        }
    
    }
}
