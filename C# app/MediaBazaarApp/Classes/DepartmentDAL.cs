using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MediaBazaarApp.Classes
{
    public class DepartmentDAL : DBmanager, IDepartment
    {


        public void Create(Department department)
        {
            string sql = $"INSERT INTO department(ID, Name, Manager) values(@ID, @Name, @Manager)";

            MySqlParameter[] prms = new MySqlParameter[3];
            prms[0] = new MySqlParameter("@ID", department.ID);
            prms[1] = new MySqlParameter("@Name", department.Name);
            prms[2] = new MySqlParameter("@Manager", department.DepartmentManagerID);

            this.ExecuteQuery(sql, prms);
        }


        public List<Department> GetAll()
        {

            string sql = $"SELECT d.ID, d.Name, d.Manager, p.FirstName, p.LastName " +
            $"FROM `department`as d " +
            $"Inner JOIN `person` as p ON d.Manager = p.ID";

            MySqlCommand cmd = new MySqlCommand(sql, this.GetConnection());
            MySqlDataReader reader = null;
            List<Department> departments = new List<Department>();
            try
            {
                reader = this.OpenExecuteReader(cmd);
                while (reader.Read())
                {
                    

                    Manager manager
                    = new Manager(Convert.ToInt32(reader["Manager"]),
                                  Convert.ToString(reader["FirstName"]),
                                  Convert.ToString(reader["LastName"]));
                    Department department
                         = new Department(Convert.ToInt32(reader["ID"]),
                               Convert.ToString(reader["Name"]),
                               manager);

                    departments.Add(department);
                }
            }
            finally
            {
                this.CloseExecuteReader(reader);
            }
            return departments;
        }

        public List<Department> GetDepartmentName()
        {
            string sql = $"SELECT Name FROM department";

            MySqlCommand cmd = new MySqlCommand(sql, this.GetConnection());
            MySqlDataReader reader = null;
            List<Department> departments = new List<Department>();
            try
            {
                reader = this.OpenExecuteReader(cmd);
                while (reader.Read())
                {

                    Department department
                         = new Department(Convert.ToString(reader["Name"]));


                    departments.Add(department);
                }
            }
            finally
            {
                this.CloseExecuteReader(reader);
            }

            return departments;
        }

        
        public void Update(Department department)
        {
            string sql = $"UPDATE department SET Name = @Name, Manager = @Manager WHERE ID = @ID";

            MySqlParameter[] prms = new MySqlParameter[3];
            prms[0] = new MySqlParameter("@ID", department.ID);
            prms[1] = new MySqlParameter("@Name", department.Name);
            prms[2] = new MySqlParameter("@Manager", department.DepartmentManager);

            this.ExecuteQuery(sql, prms);
        }
    }

}
