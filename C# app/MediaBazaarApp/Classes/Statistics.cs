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
            string sql = "select count(*) from employee where HireDate <= @date AND status<>3";

            MySqlParameter[] prms = new MySqlParameter[1];

            prms[0] = new MySqlParameter("@date", date);
           
            Object obj = this.ReadScalar(sql, prms);
            if (obj != DBNull.Value)
            {
                int count = Convert.ToInt32(obj);
                return count;
            }
           else throw new ArgumentException("No data found for selected date");
        }
        public decimal GetTotalSalaryPaidForDate(DateTime date)
        {
            string sql = "SELECT Sum(e.Wage * 8) from employeeassignment a " +
                " INNER join employee e on a.EmployeeID = e.ID " +
                " INNER join workshift w on a.ShiftID = w.ID where w.Date < @date";

            MySqlParameter[] prms = new MySqlParameter[1];

            prms[0] = new MySqlParameter("@date", date);

            Object obj = this.ReadScalar(sql, prms);
            if (obj != DBNull.Value)
            {
                decimal amount = Convert.ToDecimal(obj);
                return amount;
            }
            else throw new ArgumentException("No data found for selected date");

        }

        public decimal GetAverageSalaryDepartment(Department department)
        {
            string sql = "SELECT AVG(e.Wage) from employeeassignment a " +
                         "INNER join employee e on a.EmployeeID = e.ID " +
                         "INNER join department d on e.DepartmentID = @ID ";

            MySqlParameter[] prms = new MySqlParameter[1];

            prms[0] = new MySqlParameter("@ID", department.ID);
            decimal amount;
            Object obj = this.ReadScalar(sql, prms);
            if (obj != DBNull.Value)
            {
                amount = Convert.ToDecimal(obj);
                return amount;
            }

            else
            { 
                amount = 0;
                return amount;
            };
        }
        public int NrOfEmployees(Department department)
        {
            string sql = "SELECT COUNT(*) FROM employee WHERE DepartmentID = @ID ";
            MySqlParameter[] prms = new MySqlParameter[1];
            prms[0] = new MySqlParameter("@ID", department.ID);
            Object obj = this.ReadScalar(sql, prms);
            if (obj != DBNull.Value)
            {
                int amount = Convert.ToInt32(obj);
                return amount;
            }
            else throw new ArgumentException("No employees found");
        }

        public int GetTotalHoursWorkedForDate(DateTime date)
        {
            string sql = "SELECT Sum(1 * 8) from employeeassignment a " +
                " INNER join employee e on a.EmployeeID = e.ID " +
                " INNER join workshift w on a.ShiftID = w.ID where w.Date < @date";

            MySqlParameter[] prms = new MySqlParameter[1];

            prms[0] = new MySqlParameter("@date", date);

            Object obj = this.ReadScalar(sql, prms);
            if (obj != DBNull.Value)
            {
                int count = Convert.ToInt32(obj);
                return count;
            }
            else throw new ArgumentException("No data found for selected date");
        }
        public decimal GetAverageEmployeePerShiftForPeriod(DateTime start, DateTime end)
        {
            string sql = "select AVG(empCount) as a " +
                " FROM (SELECT count(*) as empCount " +
                " from employeeassignment e inner join workshift w on w.ID = e.ShiftID  " +
                " where w.Date > @StartDate and w.Date < @EndDate group by e.ShiftID) as assignments";

            MySqlParameter[] prms = new MySqlParameter[2];

            prms[0] = new MySqlParameter("@StartDate", start);
            prms[1] = new MySqlParameter("@EndDate", end);

            Object obj = this.ReadScalar(sql, prms);
            if (obj != DBNull.Value)
            {
                decimal amount = Convert.ToDecimal(obj);
                return amount;
            }
            else throw new ArgumentException("No data found for selected period");
        }

        public decimal GetTotalSalaryPaidForPeriod(DateTime start, DateTime end)
        {
            string sql = "SELECT Sum(e.Wage * 8) from employeeassignment a " +
                " INNER join employee e on a.EmployeeID = e.ID " +
                " INNER join workshift w on a.ShiftID = w.ID " +
                " where w.Date > @StartDate and w.Date < @EndDate ";

            MySqlParameter[] prms = new MySqlParameter[2];

            prms[0] = new MySqlParameter("@StartDate", start);
            prms[1] = new MySqlParameter("@EndDate", end);

            Object obj = this.ReadScalar(sql, prms);
            if (obj != DBNull.Value)
            {
                decimal amount = Convert.ToDecimal(obj);
                return amount;
            }
            else throw new ArgumentException("No data found for selected period");
        }
        public decimal GetAverageSalaryForPeriod(DateTime start, DateTime end)
        {
            string sql = "SELECT Sum(e.Wage * 8) from employeeassignment a " +
                " INNER join employee e on a.EmployeeID = e.ID " +
                " INNER join workshift w on a.ShiftID = w.ID " +
                " where w.Date > @StartDate and w.Date < @EndDate ";

            MySqlParameter[] prms = new MySqlParameter[2];

            prms[0] = new MySqlParameter("@StartDate", start);
            prms[1] = new MySqlParameter("@EndDate", end);

            Object obj = this.ReadScalar(sql, prms);
            if (obj != DBNull.Value)
            {
                decimal amount = Convert.ToDecimal(obj);
                return amount;
            }
            else throw new ArgumentException("No data found for selected period");
        }
        public decimal GetHoursWorkedForPeriod(DateTime start, DateTime end)
        {
            string sql = "select sum(8) from employeeassignment a " +
                " INNER JOIN workshift w on w.ID = a.ShiftID " +
                " where w.Date >= @StartDate AND w.Date <= @EndDate";

            MySqlParameter[] prms = new MySqlParameter[2];

            prms[0] = new MySqlParameter("@StartDate", start);
            prms[1] = new MySqlParameter("@EndDate", end);

            Object obj = this.ReadScalar(sql, prms);
            if (obj != DBNull.Value)
            {
                decimal amount = Convert.ToDecimal(obj);
                return amount;
            }
            else throw new ArgumentException("No data found for selected period");
        }

        public decimal GetAvgItemPerPurchase(Product product)
        {
            string sql = "SELECT AVG(Amount) as AverageAmount from purchase where product = @ItemId";

            MySqlParameter[] prms = new MySqlParameter[1];

            prms[0] = new MySqlParameter("@ItemId", product.ID);

            Object obj = this.ReadScalar(sql, prms);
            if (obj != DBNull.Value)
            {
                decimal amount = Convert.ToDecimal(obj);
                return amount;
            }
            else throw new ArgumentException("No data found!");
        }
        public int GetTotalSalesPerDepartment(Department department, DateTime start, DateTime end)
        {
            string sql = $"SELECT Sum(pur.Amount) FROM purchase pur " +
                         " inner JOIN product p on pur.Product = p.ID " +
                         " inner join Department d on p.Department = d.ID " +
                         " where pur.DateTime >= @start AND pur.DateTime <= @end AND d.ID = @ID ";


            MySqlParameter[] prms = new MySqlParameter[3];
            prms[0] = new MySqlParameter("@ID", department.ID);
            prms[1] = new MySqlParameter("@start", start);
            prms[2] = new MySqlParameter("@end", end);
            Object obj = this.ReadScalar(sql, prms);
            int sales;
            if (obj != DBNull.Value)
            {
                sales = Convert.ToInt32(obj);
                return sales;
            }

            else
            {
                sales = 0;
                return sales;
            }

        }

        public int GetTotalSalariesPaidPerDepartment(Department department, DateTime start, DateTime end)
        {
            string sql = $"SELECT Sum(e.Wage) FROM employee e " +
                         "INNER join employeeassignment a on e.ID = a.EmployeeID " +
                         "INNER join workshift w on a.ShiftID = w.ID " +
                         "INNER join Department d on e.DepartmentID = d.ID " +
                         "WHERE w.Date >= @start AND w.Date <= @end AND d.ID = @ID ";

     
            MySqlParameter[] prms = new MySqlParameter[3];
            prms[0] = new MySqlParameter("@ID", department.ID);
            prms[1] = new MySqlParameter("@start", start);
            prms[2] = new MySqlParameter("@end", end);
            Object obj = this.ReadScalar(sql, prms);
            int salaries;
            if (obj != DBNull.Value)
            {
                salaries = Convert.ToInt32(obj);
                return salaries;
            }

            else
            {
                salaries = 0;
                return salaries;
            }

        }

        public decimal GetProfitPerProduct(Product product)
        {
            string sql = "SELECT COUNT(Amount)*product.SellingPrice - " +
                " COUNT(Amount)*product.CostPrice as TotalProfit from purchase " +
                " INNER JOIN product ON purchase.Product = product.ID " +
                " where product.ID = @ItemId; ";

            MySqlParameter[] prms = new MySqlParameter[1];

            prms[0] = new MySqlParameter("@ItemId", product.ID);

            Object obj = this.ReadScalar(sql, prms);
            if (obj != DBNull.Value)
            {
                decimal amount = Convert.ToDecimal(obj);
                return amount;
            }
            else throw new ArgumentException("No data found!");
        }

        public decimal GetTotalSalesPerProduct(Product product)
        {
            string sql = "SELECT SUM(Amount) as SalesAmount from purchase where product = @ItemId";

            MySqlParameter[] prms = new MySqlParameter[1];

            prms[0] = new MySqlParameter("@ItemId", product.ID);

            Object obj = this.ReadScalar(sql, prms);
            if (obj != DBNull.Value)
            {
                decimal amount = Convert.ToDecimal(obj);
                return amount;
            }
            else throw new ArgumentException("No data found!");
        }
    }
}
