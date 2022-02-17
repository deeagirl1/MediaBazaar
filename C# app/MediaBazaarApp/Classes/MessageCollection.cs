using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class MessageCollection : DBmanager
    {
        private EmployeeList employeeList = new EmployeeList();
        public List<Message> ToList()
        {
            string sql = $"SELECT * FROM contactmessages";

            MySqlCommand cmd = new MySqlCommand(sql, this.GetConnection());
            MySqlDataReader reader = null;
            List<Message> messages = new List<Message>();
            try
            {
                reader = this.OpenExecuteReader(cmd);
                while (reader.Read())
                {
                    Message message
                         = new Message(Convert.ToInt32(reader["ID"]),
                               employeeList.GetEmployeeById(Convert.ToInt32(reader["Sender"])),
                               Convert.ToString(reader["Topic"]),
                               Convert.ToString(reader["Text"]),
                               Convert.ToDateTime(reader["DateTime"]));
                    messages.Add(message);
                }
            }
            finally
            {
                this.CloseExecuteReader(reader);
            }
            return messages;
        }

        public List<Message> GetCallInSickMessages()
        {
            string sql = $"SELECT w.Date, p.ID, p.FirstName, p.LastName from " +
                $"employeeassignment e inner join workshift w on e.ShiftID = w.ID " +
                $"INNER join person p on e.EmployeeID = p.ID where e.calledInSick > 0 ";

            MySqlCommand cmd = new MySqlCommand(sql, this.GetConnection());
            MySqlDataReader reader = null;
            List<Message> messages = new List<Message>();
            try
            {
                reader = this.OpenExecuteReader(cmd);
                while (reader.Read())
                {
                    Message message
                         = new Message(0,
                               employeeList.GetEmployeeById(Convert.ToInt32(reader["ID"])),
                               "Called in sick",
                               $"Employee {employeeList.GetEmployeeById(Convert.ToInt32(reader["ID"]))}" +
                               $"cannot attend shift on this day.",
                               Convert.ToDateTime(reader["Date"]));
                    messages.Add(message);
                }
            }
            finally
            {
                this.CloseExecuteReader(reader);
            }
            return messages;
        }
    }
}
