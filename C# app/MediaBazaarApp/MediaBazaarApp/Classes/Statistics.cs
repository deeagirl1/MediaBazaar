using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class Statistics : DBmanager
    {
        public int GetTotalEmployeesForDate(DateTime date)
        {
            string sql = "select count(*) from employee where HireDate <= @date AND LastWorkingDay > @date";

            MySqlParameter[] prms = new MySqlParameter[1];

            prms[0] = new MySqlParameter("@date", date);

            int count = Convert.ToInt32(this.ReadScalar(sql, prms));
            return count;
        }
        public decimal GetTotalSalaryPaidForDate(DateTime date)
        {
            string sql = "SELECT Sum(e.Wage * 8) from employeeassignment a " +
                " INNER join employee e on a.EmployeeID = e.ID " +
                " INNER join workshift w on a.ShiftID = w.ID where w.Date < @date";

            MySqlParameter[] prms = new MySqlParameter[1];

            prms[0] = new MySqlParameter("@date", date);

            decimal amount = Convert.ToDecimal(this.ReadScalar(sql, prms));
            return amount;
        }
        public int GetTotalHoursWorkedForDate(DateTime date)
        {
            string sql = "SELECT Sum(1 * 8) from employeeassignment a " +
                " INNER join employee e on a.EmployeeID = e.ID " +
                " INNER join workshift w on a.ShiftID = w.ID where w.Date < @date";

            MySqlParameter[] prms = new MySqlParameter[1];

            prms[0] = new MySqlParameter("@date", date);

            int amount = Convert.ToInt32(this.ReadScalar(sql, prms));
            return amount;
        }
        public decimal GetAverageEmployeePerShiftForPeriod(DateTime start, DateTime end)
        {
            string sql = "select AVG(empCount) as a " +
                " FROM (SELECT e.ShiftID, count(*) as empCount " +
                " from employeeassignment e inner join workshift w on w.ID = e.ShiftID  " +
                " where w.Date > @StartDate and w.Date < @EndDate group by e.ShiftID) as assignments";

            MySqlParameter[] prms = new MySqlParameter[2];

            prms[0] = new MySqlParameter("@StartDate", start);
            prms[1] = new MySqlParameter("@EndDate", start);

            decimal data = Convert.ToInt32(this.ReadScalar(sql, prms));
            return data;
        }

    }
}
