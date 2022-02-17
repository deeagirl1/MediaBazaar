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
            string sql = "INSERT INTO restock(ItemID, AmountRequested, Status) values(@ItemID, @AmountRequested, 1)";

            MySqlParameter[] prms = new MySqlParameter[2];
            prms[0] = new MySqlParameter("@ItemID", productRequest.Product.ID);
            prms[1] = new MySqlParameter("@AmountRequested", productRequest.Quantity);

            this.ExecuteQuery(sql, prms);
        }
        public List<ProductRequest> GetAll()
        {
            string sql = $" SELECT r.ID, r.ItemID, p.ID as PrID, p.Name," +
                $" r.AmountRequested, r.Date, s.ID as StID, s.Name as stName, r.Comment as Comment" +
                $" FROM restock r INNER JOIN product p on r.ItemID = p.ID " +
                $" INNER JOIN requestStatus s on r.Status = s.ID ";

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

                    RequestStatus status
                        = new RequestStatus(Convert.ToInt32(reader["StID"]),
                               Convert.ToString(reader["stName"]));

                    ProductRequest request
                         = new ProductRequest(Convert.ToInt32(reader["ID"]),
                                              product,
                                              Convert.ToInt32(reader["AmountRequested"]),
                                              Convert.ToDateTime(reader["Date"]),
                                              Convert.ToString(reader["Comment"]),
                                              status);

                    requests.Add(request);
                }
            }
            finally
            {
                this.CloseExecuteReader(reader);
            }
            return requests;
        }
        public void UpdateQuantity(ProductRequest request)
        {
            string sql = "UPDATE productStock SET NrInStock=NrInStock + @amount WHERE ID = @id";

            MySqlParameter[] prms = new MySqlParameter[2];
            prms[0] = new MySqlParameter("@amount", request.Quantity);
            prms[1] = new MySqlParameter("@id", request.Product.ID);

            this.ExecuteQuery(sql, prms);
        }
        public void UpdateStatus(ProductRequest request, int Status, string comment)
        {
            string sql = "UPDATE restock SET Status = @Status, Comment = @Comment WHERE ID = @id";

            MySqlParameter[] prms = new MySqlParameter[3];
            prms[0] = new MySqlParameter("@Status", Status);
            prms[1] = new MySqlParameter("@id", request.ID);
            prms[2] = new MySqlParameter("@Comment", request.Comment);

            this.ExecuteQuery(sql, prms);
        }

        public void CreateComment(ProductRequest request, string comment)
        {
            string sql = "Update restock SET COMMENT = @Comment WHERE ID = @ID";

            MySqlParameter[] prms = new MySqlParameter[2];
            prms[0] = new MySqlParameter("@ID", request.ID);
            prms[1] = new MySqlParameter("@Comment",comment);

            this.ExecuteQuery(sql, prms);
        }

        public void UpdateStatus(ProductRequest request, int Status)
        {
            string sql = "UPDATE restock SET Status = @Status WHERE ID = @id";

            MySqlParameter[] prms = new MySqlParameter[2];
            prms[0] = new MySqlParameter("@Status", Status);
            prms[1] = new MySqlParameter("@id", request.ID);
          

            this.ExecuteQuery(sql, prms);
        }
    }
}
