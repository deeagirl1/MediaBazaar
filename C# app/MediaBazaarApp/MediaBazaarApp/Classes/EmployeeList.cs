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
                $" p.Username, p.Password, p.AccessLevel, e.BirthDate, e.HireDate, e.LastWorkingDay, " +
                $" e.Country, e.City,e.Street,e.StreetNumber,e.AddressAddition,e.ZipCode, " +
                $" e.Wage, e.AccountNumber, s.ID as StatusID, s.Status as StatusName, " +
                $" d.ID as DepartmentID, d.Name as Department, " +
                $" c.ID as ContractID, c.Fixed as ContractFixed,c.Hours as ContractHours " +
                $" FROM PERSON p INNER JOIN EMPLOYEE e ON p.ID = e.ID " +
                $" INNER JOIN department d ON e.DepartmentID = d.ID " +
                $" INNER JOIN employeeStatus s ON e.Status = s.ID " +
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

                    Status status = new Status(Convert.ToInt32(reader["StatusID"]),
                                               Convert.ToString(reader["StatusName"]));

                    DateTime lastWorkingDay;

                    if (reader["LastWorkingDay"] != DBNull.Value)
                        lastWorkingDay = Convert.ToDateTime(reader["LastWorkingDay"]);
                    else lastWorkingDay = new DateTime();

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
                                                    status,
                                                    Convert.ToDateTime(reader["HireDate"]),
                                                    lastWorkingDay,
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

        public void Edit(ShopWorker shopWorker)
        {
            string sql = " UPDATE person SET Email=@Email WHERE ID = @ID; " +
                         " UPDATE employee SET LastWorkingDay=@LastWorkingDay, Country=@Country, " +
                         " City=@City, Street=@Street, StreetNumber=@StreetNumber, AddressAddition=@AddressAddition, " +
                         " ZipCode=@ZipCode,Wage=@Wage,AccountNumber=@AccountNumber,Status = @Status,DepartmentID=@DepartmentID, " +
                         " ContractID=@ContractID WHERE ID = @ID; ";

            MySqlParameter[] prms = new MySqlParameter[14];

            prms[0] = new MySqlParameter("@Email", shopWorker.Email);
            prms[1] = new MySqlParameter("@Country", shopWorker.HomeAddress.Country);
            prms[2] = new MySqlParameter("@City", shopWorker.HomeAddress.City);
            prms[3] = new MySqlParameter("@Street", shopWorker.HomeAddress.Street);
            prms[4] = new MySqlParameter("@StreetNumber", shopWorker.HomeAddress.StreetNumber);
            prms[5] = new MySqlParameter("@AddressAddition", shopWorker.HomeAddress.Addition);
            prms[6] = new MySqlParameter("@ZipCode", shopWorker.HomeAddress.ZipCode);
            prms[7] = new MySqlParameter("@Wage", shopWorker.HourlyWage);
            prms[8] = new MySqlParameter("@AccountNumber", shopWorker.BankAccount);
            prms[9] = new MySqlParameter("@DepartmentID", shopWorker.WorksAt.ID);
            prms[10] = new MySqlParameter("@ContractID", shopWorker.Contract.ID);
            prms[11] = new MySqlParameter("@ID", shopWorker.ID);
            prms[12] = new MySqlParameter("@Status", shopWorker.Status.ID);

            if (shopWorker.LastWorkingDay.Date < DateTime.Now)
                prms[13] = new MySqlParameter("@LastWorkingDay", null);
            else prms[13] = new MySqlParameter("@LastWorkingDay", shopWorker.LastWorkingDay);

            this.ExecuteQuery(sql, prms);
        }

        public void Add(ShopWorker shopWorker)
        {
            //INSERT INTO `person`(`FirstName`, `LastName`, `Email`, `Username`, `Password`, `AccessLevel`) VALUES('a', 'b', 'c', 'd', 'e', 1); SET @last_id_in_table1 = LAST_INSERT_ID(); INSERT INTO `employee`(`ID`, `BirthDate`, `HireDate`, `Country`, `City`, `Street`, `StreetNumber`, `ZipCode`, `Wage`, `AccountNumber`, `DepartmentID`, `ContractID`) VALUES(@last_id_in_table1, 2020 - 12 - 08, 2020 - 12 - 08, 's', 's', 'e', 75, 'asas', 10, 'dsadsa', 2, 1)
            string sql = " INSERT INTO person(FirstName, LastName, Email, Username, Password, AccessLevel) " +
                         " VALUES (@FirstName, @LastName, @Email, @Username, @Password, @AccessLevel); " +
                         " SET @last_id_in_table1 = LAST_INSERT_ID(); " +
                         " INSERT INTO employee(ID, BirthDate, HireDate, LastWorkingDay, Country, City, Street, StreetNumber, " +
                         " AddressAddition, ZipCode, Wage, AccountNumber,Status, DepartmentID, ContractID) " +
                         " VALUES (@last_id_in_table1, @BirthDate, @HireDate, @LastWorkingDay, @Country, @City, @Street, @StreetNumber, " +
                         " @AddressAddition, @ZipCode, @Wage, @AccountNumber,@Status, @DepartmentID, @ContractID )";

            MySqlParameter[] prms = new MySqlParameter[20];

            prms[0] = new MySqlParameter("@FirstName", shopWorker.FirstName);
            prms[1] = new MySqlParameter("@LastName", shopWorker.LastName);
            prms[2] = new MySqlParameter("@Email", shopWorker.Email);
            prms[3] = new MySqlParameter("@Username", shopWorker.Email);
            prms[4] = new MySqlParameter("@Password", "test");
            prms[5] = new MySqlParameter("@AccessLevel", 1); 
            prms[6] = new MySqlParameter("@BirthDate", shopWorker.BirthDate.Date);
            prms[7] = new MySqlParameter("@HireDate", shopWorker.HireTime.Date);
            prms[8] = new MySqlParameter("@Country", shopWorker.HomeAddress.Country);
            prms[9] = new MySqlParameter("@City", shopWorker.HomeAddress.City);
            prms[10] = new MySqlParameter("@Street", shopWorker.HomeAddress.Street); 
            prms[11] = new MySqlParameter("@StreetNumber", shopWorker.HomeAddress.StreetNumber);
            prms[12] = new MySqlParameter("@AddressAddition", shopWorker.HomeAddress.Addition);
            prms[13] = new MySqlParameter("@ZipCode", shopWorker.HomeAddress.ZipCode);
            prms[14] = new MySqlParameter("@Wage", shopWorker.HourlyWage);
            prms[15] = new MySqlParameter("@AccountNumber", shopWorker.BankAccount);
            prms[16] = new MySqlParameter("@DepartmentID", shopWorker.WorksAt.ID);
            prms[17] = new MySqlParameter("@ContractID", shopWorker.Contract.ID);
            prms[18] = new MySqlParameter("@Status", shopWorker.Status.ID);

            if (shopWorker.LastWorkingDay.Date < DateTime.Now)
                prms[19] = new MySqlParameter("@LastWorkingDay", null);
            else prms[19] = new MySqlParameter("@LastWorkingDay", shopWorker.LastWorkingDay);

            this.ExecuteQuery(sql,prms);
        }
    }
}
