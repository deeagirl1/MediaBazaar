using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp.Classes
{
    public class ProductDB : DBmanager, IProductStorage
    {
        public List<Product> GetAll()
        {
            string sql = $" SELECT p.ID, p.Name, p.CostPrice, p.SellingPrice, d.Name as Department, s.NrInStock, s.MinThreshold " +
                         $" FROM product p INNER JOIN productStock s ON p.ID = s.ID " +
                         $" INNER JOIN department d ON p.Department = d.ID ";

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
                               Convert.ToDouble(reader["SellingPrice"]),
                               Convert.ToInt32(reader["NrInStock"]),
                               Convert.ToInt32(reader["MinThreshold"]));

                    products.Add(product);
                }
            }
            finally
            {
                this.CloseExecuteReader(reader);
            }
            return products;
        }

        public Product GetByID(int id)
        {
            string sql = $" SELECT p.ID, p.Name, p.CostPrice, p.SellingPrice, d.Name, s.NrInStock, s.MinTreshold " +
                         $" FROM product p INNER JOIN productStock s ON p.ID = s.ID " +
                         $" INNER JOIN department d ON p.Department = d.ID WEHERE p.ID = @ID ";
            MySqlCommand cmd = new MySqlCommand(sql, this.GetConnection());
            cmd.Parameters.Add(new MySqlParameter("@ID", id));
            MySqlDataReader reader = null;
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
                               Convert.ToDouble(reader["SellingPrice"]),
                               Convert.ToInt32(reader["NrInStock"]),
                               Convert.ToInt32(reader["MinThreshold"]));
                    return product;
                }
            }
            finally
            {
                this.CloseExecuteReader(reader);
            }
            return null;
        }

        public void Create(Product product)
        {
            string sql = "INSERT INTO product(Name,Department,CostPrice,SellingPrice) " +
                 " VALUES (@Name, @Department, @CostPrice, @SellingPrice) ; " +
                 " SET @last_id_in_table1 = LAST_INSERT_ID(); " +
                 " INSERT INTO productStock(ID, NrInStock, MinThreshold) " +
                 " VALUES (@last_id_in_table1, @NrInStock, @MinThreshold) ";

            MySqlParameter[] prms = new MySqlParameter[4];
            prms[0] = new MySqlParameter("@Name", product.Name);
            prms[1] = new MySqlParameter("@Department", product.Department);
            prms[2] = new MySqlParameter("@CostPrice", product.CostPrice);
            prms[3] = new MySqlParameter("@SellingPrice", product.SellingPrice);
            prms[4] = new MySqlParameter("@NrInStock",product.Quantity );
            prms[5] = new MySqlParameter("@MinThreshold", product.MinTreshold);

            this.ExecuteQuery(sql, prms);
        }

        public void Update(Product product)
        {
            string sql = "UPDATE product SET Name=@Name, Department = @Department, " +
                " CostPrice = @CostPrice, SellingPrice = @SellingPrice WHERE ID = @ID; " +
                " UPDATE productStock SET NrInStock = @NrInStock , " +
                " MinThreshold = @MinThreshold WHERE ID = @ID; ";

            MySqlParameter[] prms = new MySqlParameter[5];
            prms[0] = new MySqlParameter("@Name", product.Name);
            prms[1] = new MySqlParameter("@Department", product.Department);
            prms[2] = new MySqlParameter("@CostPrice", product.CostPrice);
            prms[3] = new MySqlParameter("@SellingPrice", product.SellingPrice);
            prms[4] = new MySqlParameter("@NrInStock", product.Quantity);
            prms[5] = new MySqlParameter("@MinThreshold", product.MinTreshold);
            prms[5] = new MySqlParameter("@ID", product.ID);

            this.ExecuteQuery(sql, prms);
        }
    }
}
