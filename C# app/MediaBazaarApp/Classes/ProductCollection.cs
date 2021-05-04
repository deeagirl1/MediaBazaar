using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
   public class ProductCollection : DBmanager
    {
        public List<Product> ToList()
        {
            string sql = $"SELECT * FROM product";

            MySqlCommand cmd = new MySqlCommand(sql, this.GetConnection());
            MySqlDataReader reader = null;
            List<Product> products = new List<Product>();
            try
            {
                reader = this.OpenExecuteReader(cmd);
                while (reader.Read())
                {
                    Product product
                         = new Product(Convert.ToInt32(reader["ID"]),
                               Convert.ToString(reader["Name"]),
                               Convert.ToString(reader["Department"]),
                               Convert.ToDouble(reader["CostPrice"]),
                               Convert.ToDouble(reader["SellingPrice"]));

                    products.Add(product);
                }
            }
            finally
            {
                this.CloseExecuteReader(reader);
            }
            return products;
        }

        public void AddProduct(Product product)
        {
            string sql = "INSERT INTO product(Name,Department,CostPrice,SellingPrice) VALUES (@Name, @Department, @CostPrice, @SellingPrice)";
            MySqlParameter[] prms = new MySqlParameter[4];
            prms[0] = new MySqlParameter("@Name", product.Name);
            prms[1] = new MySqlParameter("@Department", product.Department);
            prms[2] = new MySqlParameter("@CostPrice", product.CostPrice);
            prms[3] = new MySqlParameter("@SellingPrice", product.SellingPrice);
            this.ExecuteQuery(sql, prms);
        }

        public void EditProduct(Product product)
        {
            string sql = "UPDATE product SET Name=@Name, Department = @Department, CostPrice = @CostPrice, SellingPrice = @SellingPrice WHERE ID = @ID";

            MySqlParameter[] prms = new MySqlParameter[5];
            prms[0] = new MySqlParameter("@ID", product.ID);
            prms[1] = new MySqlParameter("@Name", product.Name);
            prms[2] = new MySqlParameter("@Department", product.Department);
            prms[3] = new MySqlParameter("@CostPrice", product.CostPrice);
            prms[4] = new MySqlParameter("@SellingPrice", product.SellingPrice);

            this.ExecuteQuery(sql, prms);

        }
    }
}
