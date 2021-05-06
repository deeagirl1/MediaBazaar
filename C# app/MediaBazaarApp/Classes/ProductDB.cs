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
            string sql = $" SELECT p.ID, p.Name, p.CostPrice, p.SellingPrice, d.Name as Department, d.ID as DepID, " +
                         $" p.Height, p.Length, p.Width, " +
                         $" s.NrInStock, s.MinThreshold " +
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
                    Department department
                        = new Department(Convert.ToInt32(reader["DepID"]),
                                         Convert.ToString(reader["Department"]));

                    Product product
                         = new Product(Convert.ToInt32(reader["ID"]),
                               Convert.ToString(reader["Name"]),
                               department,
                               Convert.ToDecimal(reader["CostPrice"]),
                               Convert.ToDecimal(reader["SellingPrice"]),
                               Convert.ToInt32(reader["NrInStock"]),
                               Convert.ToDecimal(reader["Height"]),
                               Convert.ToDecimal(reader["Length"]),
                               Convert.ToDecimal(reader["Width"]),
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
            //string sql = $" SELECT p.ID, p.Name, p.CostPrice, p.SellingPrice, d.Name, s.NrInStock, s.MinTreshold " +
            //             $" FROM product p INNER JOIN productStock s ON p.ID = s.ID " +
            //             $" INNER JOIN department d ON p.Department = d.ID WEHERE p.ID = @ID ";
            //MySqlCommand cmd = new MySqlCommand(sql, this.GetConnection());
            //cmd.Parameters.Add(new MySqlParameter("@ID", id));
            //MySqlDataReader reader = null;
            //try
            //{
            //    reader = this.OpenExecuteReader(cmd);
            //    while (reader.Read())
            //    {
            //        Department department
            //            = new Department(Convert.ToInt32(reader["DepID"]),
            //                             Convert.ToString(reader["Department"]));

            //        Product product
            //             = new Product(Convert.ToInt32(reader["ID"]),
            //                   Convert.ToString(reader["Name"]),
            //                   department,
            //                   Convert.ToDecimal(reader["CostPrice"]),
            //                   Convert.ToDecimal(reader["SellingPrice"]),
            //                   Convert.ToInt32(reader["NrInStock"]),
            //                   Convert.ToInt32(reader["MinThreshold"]));

            //        return product;
            //    }
            //}
            //finally
            //{
            //    this.CloseExecuteReader(reader);
            //}
            return null;
        }

        public void Create(Product product)
        {
            string sql = "INSERT INTO product(Name,Department,CostPrice,SellingPrice, " +
                 " Height, Length, Width ) " +
                 " VALUES (@Name, @Department, @CostPrice, @SellingPrice, " +
                 " @Height, @Length, @Width ) ; " +
                 " SET @last_id_in_table1 = LAST_INSERT_ID(); " +
                 " INSERT INTO productStock(ID, NrInStock, MinThreshold) " +
                 " VALUES (@last_id_in_table1, @NrInStock, @MinThreshold) ";

            MySqlParameter[] prms = new MySqlParameter[9];
            prms[0] = new MySqlParameter("@Name", product.Name);
            prms[1] = new MySqlParameter("@Department", product.Department.ID);
            prms[2] = new MySqlParameter("@CostPrice", product.CostPrice);
            prms[3] = new MySqlParameter("@SellingPrice", product.SellingPrice);
            prms[4] = new MySqlParameter("@NrInStock",product.Quantity );
            prms[5] = new MySqlParameter("@MinThreshold", product.MinThreshold);
            prms[6] = new MySqlParameter("@Height", product.Height);
            prms[7] = new MySqlParameter("@Length", product.Length);
            prms[8] = new MySqlParameter("@Width", product.Width);

            this.ExecuteQuery(sql, prms);
        }

        public void Update(Product product)
        {
            string sql = "UPDATE product SET Name=@Name, Department = @Department, " +
                " CostPrice = @CostPrice, SellingPrice = @SellingPrice WHERE ID = @ID; " +
                " UPDATE productStock SET NrInStock = @NrInStock , " +
                " MinThreshold = @MinThreshold WHERE ID = @ID; ";

            MySqlParameter[] prms = new MySqlParameter[10];
            prms[0] = new MySqlParameter("@Name", product.Name);
            prms[1] = new MySqlParameter("@Department", product.Department.ID);
            prms[2] = new MySqlParameter("@CostPrice", product.CostPrice);
            prms[3] = new MySqlParameter("@SellingPrice", product.SellingPrice);
            prms[4] = new MySqlParameter("@NrInStock", product.Quantity);
            prms[5] = new MySqlParameter("@MinThreshold", product.MinThreshold);
            prms[7] = new MySqlParameter("@ID", product.ID);
            prms[8] = new MySqlParameter("@Height", product.Height);
            prms[9] = new MySqlParameter("@Length", product.Length);
            prms[8] = new MySqlParameter("@Width", product.Width);

            this.ExecuteQuery(sql, prms);
        }
    }
}
