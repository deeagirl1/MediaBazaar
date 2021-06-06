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

            prms[0] = new MySqlParameter("@ShiftType", shift.shift.ID);
            prms[1] = new MySqlParameter("@Date", shift.date);

            shift.ID = Convert.ToInt32(this.ReadScalar(sql, prms));
            this.addAssignedEmployees(shift);
            return shift.ID;

        }
        public void Update(WorkShift shift)
        {
            this.removeAssignedEmployees(shift.ID);
            this.addAssignedEmployees(shift);
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
        public WorkShift GetWorkShift(DateTime date)
        {
            return new WorkShift(date, getShiftType(date));
        }
        public WorkShift ShiftExists(DateTime date)
        {
            foreach (WorkShift w in this.ToList())
            {
                if (w.date == date)
                    return w;
            }
            return null;
        }
        private Shift getShiftType(DateTime date)
        {
            switch (date.Hour)
            {
                case 7: return new Shift(1);
                case 15: return new Shift(2);
                case 23: return new Shift(3);
                default: return null;
            }
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
        private void addAssignedEmployees(WorkShift shift)
        {
            foreach (ShopWorker s in shift.AssignedEmployees)
            {
                this.assignEmployee(shift.ID, s.ID);
            }
        }
        private void assignEmployee(int ShiftID, int EmployeeID)
        {
            string sql = "INSERT INTO employeeassignment (ShiftID, EmployeeID) VALUES (@ShiftID, @EmployeeID);";

            MySqlParameter[] prms = new MySqlParameter[2];

            prms[0] = new MySqlParameter("@ShiftID", ShiftID);
            prms[1] = new MySqlParameter("@EmployeeID", EmployeeID);

            this.ExecuteQuery(sql, prms);

            EmployeeSorter sorter = new EmployeeSorter();
            sorter.Incerement();
        }
        private void removeAssignedEmployees(int ShiftID)
        {
            string sql = "DELETE FROM employeeassignment WHERE shiftID = @ID";

            MySqlParameter[] prms = new MySqlParameter[1];

            prms[0] = new MySqlParameter("@ID", ShiftID);

            this.ExecuteQuery(sql, prms);
        }
        public IEnumerable<AttendenceModel> GetAttendence(WorkShift w)
        {
            foreach(ShopWorker s in w.AssignedEmployees)
            {
                yield return new AttendenceModel(s,
                    this.getCheckInTime(w, s), this.getCheckOutTime(w, s));
            } 
        }
        private Nullable<DateTime> getCheckInTime(WorkShift w, ShopWorker s)
        {
            string sql = "SELECT CheckIn FROM employeeassignment WHERE employeeassignment.ShiftID = @SHIFT AND employeeassignment.EmployeeID = @EMP";

            MySqlParameter[] prms = new MySqlParameter[2];

            prms[0] = new MySqlParameter("@SHIFT", w.ID);
            prms[1] = new MySqlParameter("@EMP", s.ID);

            Object obj = this.ReadScalar(sql, prms);
            if (obj != DBNull.Value)
            {
                DateTime time = Convert.ToDateTime(obj);
                return time;
            }
            else return null;
        }
        private Nullable<DateTime> getCheckOutTime(WorkShift w, ShopWorker s)
        {
            string sql = "SELECT CheckOut FROM employeeassignment WHERE employeeassignment.ShiftID = @SHIFT AND employeeassignment.EmployeeID = @EMP";

            MySqlParameter[] prms = new MySqlParameter[2];

            prms[0] = new MySqlParameter("@SHIFT", w.ID);
            prms[1] = new MySqlParameter("@EMP", s.ID);

            Object obj = this.ReadScalar(sql, prms);
            if (obj != DBNull.Value)
            {
                DateTime time = Convert.ToDateTime(obj);
                return time;
            }
            else return null;
        }
    }
}
