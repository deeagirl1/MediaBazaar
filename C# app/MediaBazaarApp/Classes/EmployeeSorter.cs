using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class EmployeeSorter : DBmanager
    {
        public List<ShopWorker> GetAll(List<ShopWorker> workers)
        {
            List<ShopWorker> front = new List<ShopWorker>();
            List<ShopWorker> back = new List<ShopWorker>();
            foreach (ShopWorker s in workers)
            {
                if (s.ID >= this.getCounter())
                    front.Add(s);
                else back.Add(s);
            }
            return front.Concat(back).ToList();
        }
        private int getCounter()
        {
            string sql = "SELECT COUNTER FROM SORTING";

            Object obj = this.ReadScalar(sql);
            if (obj != DBNull.Value)
            {
                int count = Convert.ToInt32(obj);
                return count;
            }
            else return 0;
        }
        private int getNext(int current)
        {
            string sql = "SELECT ID FROM EMPLOYEE WHERE ID > @VALUE";

            MySqlParameter[] prms = new MySqlParameter[1];

            prms[0] = new MySqlParameter("@VALUE", current);

            Object obj = this.ReadScalar(sql, prms);
            if (obj != null)
            {
                int res = Convert.ToInt32(obj);
                return res;
            }
            else return getFirst();
        }
        private int getFirst()
        {
            string sql = "SELECT ID FROM EMPLOYEE";
            Object obj = this.ReadScalar(sql);
            if (obj != DBNull.Value)
            {
                int res = Convert.ToInt32(obj);
                return res;
            }
            else return 0;
        }

        public void Incerement()
        {
            string sql = "UPDATE SORTING SET COUNTER = @ID";
            MySqlParameter[] prms = new MySqlParameter[1];

            prms[0] = new MySqlParameter("@ID", this.getNext(this.getCounter()));

            this.ExecuteQuery(sql, prms);
        }
    }
}
