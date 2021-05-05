using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class ProductRequestDAL : DBmanager, IProductRequestStorage
    {
        public void Create(ProductRequest productRequest)
        {
            string sql = "INSER INTO restock(ItemID, AmountRequested) values(@ItemID, @AmountRequested)";

            MySqlParameter[] prms = new MySqlParameter[4];
            prms[0] = new MySqlParameter("@ItemID", productRequest.Product.ID);
            prms[1] = new MySqlParameter("@AmountRequested", productRequest.Quantity);

            this.ExecuteQuery(sql, prms);
        }
        public List<ProductRequest> GetAll()
        {
            string sql = $" SELECT r.ID, r.ItemID, p.ID as PrID, p.Name, r.AmountRequested, r.Date" +
                $" FROM restock r INNER JOIN product p on r.ItemID = p.ID ";

            MySqlCommand cmd = new MySqlCommand(sql, this.GetConnection());
            MySqlDataReader reader = null;
            List<ProductRequest> requests = new List<ProductRequest>();
            try
            {
                reader = this.OpenExecuteReader(cmd);
                while (reader.Read())
                {
                    Product product
                         = new Product(Convert.ToInt32(reader["PrID"]),
                               Convert.ToString(reader["Name"]));

                    ProductRequest request
                         = new ProductRequest(Convert.ToInt32(reader["ID"]),
                                              product,
                                              Convert.ToInt32(reader["AmountRequested"]),
                                              Convert.ToDateTime(reader["Date"]));

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
