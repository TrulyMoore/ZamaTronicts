using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using DAL.Objects;
using BLL;
using UtilityLogger;

namespace DAL
{
   public class ProductDataAccess
    {
        // Create string for the DB connection
        static string connectionString = ConfigurationManager.ConnectionStrings["ZamaTronictsDB"].ConnectionString;

        // Create an instance of the ErrorLogger
        static ErrorLogger ErrorMessage = new ErrorLogger();

        // Create method to add  product
        public bool AddProduct(ProductDAO productToAdd)
        {
            // set the bool to false
            bool success = false;

            // create try catch to catch any possible errors
            try
            {
                // create a using statment to use the connection string
                using (SqlConnection _Connection = new SqlConnection(connectionString))
                {
                    // create using statment to specify the stored procedure
                    using (SqlCommand _Command = new SqlCommand("sp_ProductCreateProduct", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;

                        // pass the info to the stored procedure
                        _Command.Parameters.AddWithValue("@supplierID", productToAdd.supplierID);
                        _Command.Parameters.AddWithValue("@productDescription", productToAdd.productDescription);
                        _Command.Parameters.AddWithValue("@productProcessor", productToAdd.productProcessor);
                        _Command.Parameters.AddWithValue("@productOperatingSystem", productToAdd.productOperatingSystem);
                        _Command.Parameters.AddWithValue("@productQuantity", productToAdd.productQuantity);
                        _Command.Parameters.AddWithValue("@productRam", productToAdd.productRam);
                        _Command.Parameters.AddWithValue("@productPrice", productToAdd.productPrice);

                        // open the connection
                        _Connection.Open();
                        // execute the command/stored procedure
                        _Command.ExecuteNonQuery();

                        //change the bool to true
                        success = true;

                        //close the connection
                        _Connection.Close();
                    }
                }
            }
            //pass the error message
            catch (Exception error)
            {
                // call the error method and pass the error
                ErrorMessage.logger(error);
            }
            // return the success
            return success;
        }
        // create the method to update a product
        public bool UpdateProduct(ProductDAO productToUpdate)
        {
            // set the bool to false
            bool success = false;

            // create try catch to catch any possible errors
            try
            {
                // create a using statment to use the connection string
                using (SqlConnection _Connection = new SqlConnection(connectionString))
                {
                    // create using statment to specify the stored procedure
                    using (SqlCommand _Command = new SqlCommand("sp_ProductUpdateProduct", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;
                        _Command.Parameters.AddWithValue("@productID", productToUpdate.productID);
                        // pass the info to the stored procedure
                        _Command.Parameters.AddWithValue("@productDescription", productToUpdate.productDescription);
                        _Command.Parameters.AddWithValue("@productProcessor", productToUpdate.productProcessor);
                        _Command.Parameters.AddWithValue("@productOperatingSystem", productToUpdate.productOperatingSystem);
                        _Command.Parameters.AddWithValue("@productQuantity", productToUpdate.productQuantity);
                        _Command.Parameters.AddWithValue("@productRam", productToUpdate.productRam);
                        _Command.Parameters.AddWithValue("@productPrice", productToUpdate.productPrice);

                        // open the connection
                        _Connection.Open();
                        // execute the command/stored procedure
                        _Command.ExecuteNonQuery();

                        //change the bool to true
                        success = true;

                        //close the connection
                        _Connection.Close();

                    }
                }
            }
            //pass the error message
            catch (Exception error)
            {
                // call the error method and pass the error
                ErrorMessage.logger(error);
            }
            // return the success
            return success;
        }

        // create the method to delete product and pass in the product to delete
        public bool DeleteProduct(int productToDelete)
        {
            // set the bool to false
            bool success = false;

            // create try catch to catch any possible errors
            try
            {
                // create a using statment to use the connection string
                using (SqlConnection _Connection = new SqlConnection(connectionString))
                {
                    // create using statment to specify the stored procedure
                    using (SqlCommand _Command = new SqlCommand("sp_ProductDeleteProduct", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;
                        // pass the ID of the product to delete
                        _Command.Parameters.AddWithValue("productID", productToDelete);
                        // open the connection
                        _Connection.Open();
                        // execute the command/stored procedure
                        _Command.ExecuteNonQuery();

                        //change the bool to true
                        success = true;

                        //close the connection
                        _Connection.Close();

                    }
                }
            }
            //pass the error message
            catch (Exception error)
            {
                // call the error method and pass the error
                ErrorMessage.logger(error);
            }
            // return the success
            return success;

        }

        // create the method to view all products
        public List<ProductDAO> ViewAllProducts()
        {
            // create a new instance of productDOA that is a list
            List<ProductDAO> productList = new List<ProductDAO>();

            // create try catch to catch any possible errors
            try
            {
                // create a using statment to use the connection string
                using (SqlConnection _Connection = new SqlConnection(connectionString))
                {
                    // create using statment to specify the stored procedure
                    using (SqlCommand _Command = new SqlCommand("sp_ProductViewAllProducts", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;
                        // open the connection
                        _Connection.Open();

                        // create a using statement using the reader to reader through the list
                        using (SqlDataReader _Reader = _Command.ExecuteReader())
                        {
                            // create a while loop to read throught the whole record
                            while (_Reader.Read())
                            {
                                // create a new instance of ProductDOA to retrieve each item
                                ProductDAO productToList = new ProductDAO();
                                // get the product elements
                                productToList.supplierName = (string)(_Reader["supplierName"]);
                                productToList.productID = Convert.ToInt32(_Reader["productID"]);
                                productToList.productDescription = (String)_Reader["productDescription"];
                                productToList.productProcessor = (String)_Reader["productProcessor"];
                                productToList.productOperatingSystem = (String)_Reader["productOperatingSystem"];
                                productToList.productQuantity = Convert.ToInt32(_Reader["productQuantity"]);
                                productToList.productRam = (String)_Reader["productRam"];
                                productToList.productPrice = Convert.ToDecimal(_Reader["productPrice"]);

                                // return the info in a complete list
                                productList.Add(productToList);
                            }
                        }
                        //close the connection
                        _Connection.Close();
                    }
                }
            }

            //pass the error message
            catch (Exception error)
            {
                // call the error method and pass the error
                ErrorMessage.logger(error);
            }
            // return the list
            return productList;
        }


        // create the method to view only one product
        public ProductDAO ViewOneProduct(int productID)
        {
            // create a new instance of productDOA 
            ProductDAO _Product = new ProductDAO();

            // create try catch to catch any possible errors
            try
            {
                // create a using statment to use the connection string
                using (SqlConnection _Connection = new SqlConnection(connectionString))
                {
                    // create using statment to specify the stored procedure
                    using (SqlCommand _Command = new SqlCommand("sp_ProductViewOneProduct", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;
                        // pass the product ID of the item to view
                        _Command.Parameters.AddWithValue("@productID", productID);
                        // open the connection
                        _Connection.Open();

                        // create a using statement using the reader to reader through the list
                        using (SqlDataReader _Reader = _Command.ExecuteReader())
                        {
                            // create a while loop to read throught the whole record
                            while (_Reader.Read())
                            {
                                // get the product elements
                                _Product.productID = Convert.ToInt32(_Reader["productID"]);
                                _Product.productDescription = (String)_Reader["productDescription"];
                                _Product.productProcessor = (String)_Reader["productProcessor"];
                                _Product.productOperatingSystem = (String)_Reader["productOperatingSystem"];
                                _Product.productQuantity = Convert.ToInt32(_Reader["productQuantity"]);
                                _Product.productRam = (String)_Reader["productRam"];
                                _Product.productPrice = Convert.ToDecimal(_Reader["productPrice"]);
                                _Product.supplierID = Convert.ToInt32(_Reader["supplierID"]);
                                _Product.supplierName = (string)_Reader["supplierName"];
                            }
                        }
 
                        //close the connection
                        _Connection.Close();
                    }
                }
            }

            //pass the error message
            catch (Exception error)
            {
                // call the error method and pass the error
                ErrorMessage.logger(error);
            }
            // return the product with all of its elements
            return _Product;
        }


    }
}
