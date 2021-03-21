using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MediaBazaarApp
{
    public class DBmanager : DataBase
    {
        private MySqlConnection conn;
        string connStr;

        public DBmanager()
        {
            connStr = this.ToString();
            conn = new MySqlConnection(connStr);
        }

        public MySqlConnection GetConnection()
        {
            return this.conn;
        }

        public Object ReadScalar(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                Object result = cmd.ExecuteScalar();

                return result;
            }
        }

        public Object ReadScalar(string sql, MySqlParameter[] prms)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();

                if (prms != null)
                {
                    foreach (MySqlParameter p in prms)
                    {
                        cmd.Parameters.Add(p);
                    }
                }

                Object result = cmd.ExecuteScalar();

                return result;
            }
        }

        public bool ExecuteQuery(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                Object result = cmd.ExecuteNonQuery();
                if (Convert.ToInt32(result) > 0)
                    return true;
                return false;
            }
        }

        public bool ExecuteQuery(string sql, MySqlParameter[] prms)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                if (prms != null)
                {
                    foreach (MySqlParameter p in prms)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                return false;
            }
        }

        public MySqlDataReader OpenExecuteReader(MySqlCommand sqlReaderCommand)
        {
            this.conn.Open();
            MySqlDataReader reader = sqlReaderCommand.ExecuteReader();

            return reader;
        }

        public void CloseExecuteReader(MySqlDataReader reader)
        {
            if (reader != null)
                reader.Close();

            this.conn.Close();
        }
    }
}
