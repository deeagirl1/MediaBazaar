using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class Statistics : DBmanager
    {
        //public int getTotalEmployees(DateTime date)
        //{
        //    string sql = "select Count(*) from employeeassignment a " +
        //        " inner join workshift w on a.ShiftID = w.ID inner join employee e " +
        //        " on a.EmployeeID = e.ID where e.ID = @EmployeeID " +
        //        " and w.Date = @Date and w.ShiftType = @ShiftType";

        //    MySqlParameter[] prms = new MySqlParameter[3];

        //    prms[0] = new MySqlParameter("@EmployeeID", worker.ID);

        //    int count = Convert.ToInt32(this.ReadScalar(sql, prms));
        //    if (count == 0)
        //        return false;
        //    return true;
        //}
    }
}
