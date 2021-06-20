using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class RequestStatusCollection : DBmanager
    {
        public List<RequestStatus> GetAll()
        {
            string sql = "SELECT * FROM requestStatus";
            MySqlCommand cmd = new MySqlCommand(sql, this.GetConnection());
            MySqlDataReader reader = null;
            List<RequestStatus> requests = new List<RequestStatus>();
            try
            {
                reader = this.OpenExecuteReader(cmd);
                while (reader.Read())
                {
                    RequestStatus request
                        = new RequestStatus(Convert.ToInt32(reader["ID"]),
                                            Convert.ToString(reader["Name"]));
                    requests.Add(request);
                }
            }
            finally
            {
                this.CloseExecuteReader(reader);
            }
            return requests;
        }

    }
}
