using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class EmployeeList : DBmanager
    {
        public List<ShopWorker> ToList()
        {
            string sql = $"SELECT p.ID, p.FirstName, p. LastName, p.Email, " +
                $" p.Username, p.Password, p.AccessLevel, e.BirthDate, e.HireDate, " +
                $" e.Country, e.City,e.Street,e.StreetNumber,e.AddressAddition,e.ZipCode, " +
                $" e.Wage, e.AccountNumber,d.ID as DepartmentID, d.Name as Department, " +
                $" c.ID as ContractID, c.Fixed as ContractFixed,c.Hours as ContractHours " +
                $" FROM PERSON p INNER JOIN EMPLOYEE e ON p.ID = e.ID " +
                $" INNER JOIN department d ON e.DepartmentID = d.ID " +
                $" INNER JOIN contract c on e.ContractID = c.ID WHERE ACCESSLEVEL = 1";
            MySqlCommand cmd = new MySqlCommand(sql, this.GetConnection());
            MySqlDataReader reader = null;
            List<ShopWorker> employees = new List<ShopWorker>();
            try
            {
                reader = this.OpenExecuteReader(cmd);

                while (reader.Read())
                {
                    Address address = new Address(Convert.ToString(reader["Country"]),
                                                  Convert.ToString(reader["City"]),
                                                  Convert.ToString(reader["Street"]),
                                                  Convert.ToString(reader["StreetNumber"]),
                                                  Convert.ToString(reader["ZipCode"]),
                                                  Convert.ToString(reader["AddressAddition"]));

                    Contract contract = new Contract(Convert.ToInt32(reader["ContractID"]),
                                                     Convert.ToBoolean(reader["ContractFixed"]),
                                                     Convert.ToInt32(reader["ContractHours"]));

                    Department department = new Department(Convert.ToInt32(reader["DepartmentID"]),
                                                     Convert.ToString(reader["Department"]));

                    ShopWorker emp = new ShopWorker(Convert.ToInt32(reader["ID"]),
                                                    Convert.ToString(reader["FirstName"]),
                                                    Convert.ToString(reader["LastName"]),
                                                    Convert.ToString(reader["Email"]),
                                                    Convert.ToString(reader["Username"]),
                                                    Convert.ToString(reader["Password"]),
                                                    department,
                                                    address,
                                                    Convert.ToDateTime(reader["BirthDate"]),
                                                    Convert.ToString(reader["AccountNumber"]),
                                                    Convert.ToDateTime(reader["HireDate"]),
                                                    contract,
                                                    Convert.ToDecimal(reader["Wage"]));

                    employees.Add(emp);
                }
            }
            finally
            {
                this.CloseExecuteReader(reader);
            }
            return employees;
        }

        public void Add(ShopWorker worker)
        {

        }
    }
}
