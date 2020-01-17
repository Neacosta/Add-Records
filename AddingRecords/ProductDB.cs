using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AddingRecords
{
    class ProductDB
    {
        public static void AddProduct(Product product)
        {
            //set a new connection object
            SqlConnection conn = DatabaseDB.GetConnection();

            //set string for sql statement
            string strIns =
                "INSERT INTO Products " +
                "(ProductCode, Description, UnitPrice) " +
                "Values (@Code, @Description, @UnitPrice)";

            //set command object to the sql statement and connection
            SqlCommand cmd = new SqlCommand(strIns, conn);

            //identify paramaters and the property which will populate the value.
            cmd.Parameters.AddWithValue("@Code", product.ProdCode);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@UnitPrice", product.Price);


            try
            {
                //open the connection to the database.
                conn.Open();

                //execute the insert statement
                cmd.ExecuteNonQuery();

                //inform user the record has been inserted.
                MessageBox.Show("Record Added", "Success");

            }
            catch (Exception ex)
            {
                //thow exception if insert fails.
                throw ex;
            }
            finally
            {
                //close the database connection.
                conn.Close();
            }
        }

        public static void DeleteProduct(Product product)
        {
            //set new connection object. 
            SqlConnection conn = DatabaseDB.GetConnection();

            //set string strDelete to equal the sql delete syntax
            string strDelete =
                "DELETE FROM Products " +
                "WHERE ProductCode = @ProductCode";

            //declare command object and set the query and connection.
            SqlCommand cmd = new SqlCommand(strDelete, conn);

            //declare paramaters and paramater value
            cmd.Parameters.AddWithValue("@ProductCode", product.ProdCode);

            //try executing the delete
            try
            {
                //open database connection.
                conn.Open();

                //Execute Command NonQuery.
                cmd.ExecuteNonQuery();

                //Display Success
                MessageBox.Show("Successfully Deleted!", "Row Removed");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }


        }

        public static void SelectProduct(Product product)
        {
            //set sql connection string
            SqlConnection conn = DatabaseDB.GetConnection();

            //Set Select query to string. select query gets users input for product code.
            string strSel =
                "SELECT * FROM Products " +
                "WHERE ProductCode = @ProductCode";


            //declare command object and assign sql query and connection
            SqlCommand cmd = new SqlCommand(strSel, conn);

            cmd.Parameters.AddWithValue("@ProductCode", product.ProdCode);

            try
            {
                //open database
                conn.Open();

                //execute Reader for the select statement
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    product.ProdCode = dr["ProductCode"].ToString();
                    product.Description = dr["Description"].ToString();
                    product.Price = Convert.ToDecimal(dr["UnitPrice"]);

                }

            }
            catch (Exception ex)
            {
                //throw error
                throw ex;
            }
            finally
            {
                //close database connection
                conn.Close();
            }

        }

        public static List<string> SelectAllProducts()
        {
            //declare List to hold values.
            List<string> lstProductCode = new List<string>();


            //set sql connection string
            SqlConnection conn = DatabaseDB.GetConnection();

            //Set Select query to string. select query gets users input for product code.
            string strSel =
                "SELECT ProductCode FROM Products";

            //declare command object and assign sql query and connection
            SqlCommand cmd = new SqlCommand(strSel, conn);

            try
            {
                //open database
                conn.Open();

                //execute Reader for the select statement
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lstProductCode.Add(dr["ProductCode"].ToString());

                }

                return lstProductCode;
            }
            catch (Exception ex)
            {
                //throw error
                throw ex;
            }
            finally
            {
                //close database connection
                conn.Close();
            }
        }

        public static void UpdateProduct(Product oldProduct, Product newProduct)
        {
            //instantiate conn object to hold connection string.
            SqlConnection conn = DatabaseDB.GetConnection();

            //Update query, with optimistic concurancy.
            string strUp =
                "UPDATE Products " +
                "SET Description = @newDescription, " +
                "UnitPrice = @newPrice " +
                "WHERE ProductCode = @ProductCode " +
                "AND Description = @oldDescription " +
                "AND UnitPrice = @oldPrice";

            //declare commandn object and set sql statement and connections string.
            SqlCommand cmd = new SqlCommand(strUp, conn);

            //declare paramaters with old and new values.
            cmd.Parameters.AddWithValue("@newDescription", newProduct.Description);
            cmd.Parameters.AddWithValue("@newPrice", newProduct.Price);
            cmd.Parameters.AddWithValue("@oldDescription", oldProduct.Description);
            cmd.Parameters.AddWithValue("@oldProductCode", oldProduct.ProdCode);
            cmd.Parameters.AddWithValue("@oldPrice", oldProduct.Price);
            cmd.Parameters.AddWithValue("@ProductCode", oldProduct.ProdCode);

            try
            {
                //open database connection
                conn.Open();

                //update record
                cmd.ExecuteNonQuery();

                //display a successful execution.
                MessageBox.Show("Record Successfully Updated", "Updated");

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

