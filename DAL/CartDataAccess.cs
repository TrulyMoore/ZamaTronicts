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
    public class CartDataAccess
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ZamaTronictsDB"].ConnectionString;
        // Create an instance of the ErrorLogger
        static ErrorLogger ErrorMessage = new ErrorLogger();


        public bool CreateCart(CartDAO cartToCreate)
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
                    using (SqlCommand _Command = new SqlCommand("sp_AddItemToCart", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;

                        // pass the values
                        _Command.Parameters.AddWithValue("@productID", cartToCreate.productID);
                        _Command.Parameters.AddWithValue("@userTableID", cartToCreate.userTableID);
                        _Command.Parameters.AddWithValue("@checkOutQuantity", cartToCreate.checkOutQuantity);
                        _Command.Parameters.AddWithValue("@checkOutTax", cartToCreate.checkOutTax);
                        _Command.Parameters.AddWithValue("@checkOutShipping", cartToCreate.checkOutShipping);
                        _Command.Parameters.AddWithValue("@checkOutTotal", cartToCreate.checkOutTotal);
                        _Command.Parameters.AddWithValue("@checkOutDate", cartToCreate.checkOutDate);

                        // open the connection
                        _Connection.Open();

                        //Execute the command
                        _Command.ExecuteNonQuery();

                        // change the status of the bool
                        success = true;

                        // close the connection
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

        public List<CartDAO> ViewCart(int userTableID)
        {
            List<CartDAO> cartList = new List<CartDAO>();

            // create try catch to catch any possible errors
            try
            {
                // create a using statment to use the connection string
                using (SqlConnection _Connection = new SqlConnection(connectionString))
                {
                    // create using statment to specify the stored procedure
                    using (SqlCommand _Command = new SqlCommand("sp_ViewCheckOutCart", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;
                        // pass the user ID
                        _Command.Parameters.AddWithValue("@userTableID", userTableID);

                        // open the connection
                        _Connection.Open();

                        using (SqlDataReader _Reader = _Command.ExecuteReader())
                        {
                            while (_Reader.Read())
                            {
                                CartDAO _cartToList = new CartDAO();
                                _cartToList.checkOutID = Convert.ToInt32(_Reader["checkOutID"]);
                                _cartToList.supplierName = (String)_Reader["supplierName"];
                                _cartToList.productDescription = (String)_Reader["productDescription"];
                                _cartToList.productPrice = Convert.ToDecimal(_Reader["productPrice"]);
                                _cartToList.checkOutQuantity = Convert.ToInt32(_Reader["checkOutQuantity"]);
                                _cartToList.checkOutDate = Convert.ToDateTime(_Reader["checkOutDate"]);
                                _cartToList.checkOutTax = Convert.ToDecimal(_Reader["checkOutTax"]);
                                _cartToList.checkOutShipping = Convert.ToInt32(_Reader["checkOutShipping"]);
                                _cartToList.checkOutTotal = Convert.ToDecimal(_Reader["checkOutTotal"]);
                                _cartToList.userTableID = Convert.ToInt32(_Reader["userTableID"]);
                                _cartToList.productID = Convert.ToInt32(_Reader["productID"]);
                                cartList.Add(_cartToList);
                            }
                        }

                    }
                }
            }
            catch (Exception error)
            {
                // call the error method and pass the error
                ErrorMessage.logger(error);
            }
            return cartList;

        }

        public bool DeleteItemFromCart(int itemToDelete)
        {
            bool success = false;
            // create try catch to catch any possible errors
            try
            {
                // create a using statment to use the connection string
                using (SqlConnection _Connection = new SqlConnection(connectionString))
                {
                    // create using statment to specify the stored procedure
                    using (SqlCommand _Command = new SqlCommand("CheckOutDeleteItemFromCart", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;
                        // pass the ID of the product to delete
                        _Command.Parameters.AddWithValue("checkOutID", itemToDelete);
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

        public bool UpdateItemQuantity(int checkOutID, int quantity)
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
                    using (SqlCommand _Command = new SqlCommand("sp_CheckOutAddToQuantity", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;
                        // pass the ID of the product to delete
                        _Command.Parameters.AddWithValue("checkOutID", checkOutID);
                        _Command.Parameters.AddWithValue("@checkOutQuantity", quantity);
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
        public bool CreateTransaction(CartDAO transactionToCreate)
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
                    using (SqlCommand _Command = new SqlCommand("sp_UserTransactionCreateTransaction", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;
                        _Command.Parameters.AddWithValue("@userTransactionID", transactionToCreate.userTransactionID);
                        _Command.Parameters.AddWithValue("@datePurchase", transactionToCreate.datePurchase);
                        _Command.Parameters.AddWithValue("@userTableID", transactionToCreate.userTableID);
                        _Command.Parameters.AddWithValue("@productID", transactionToCreate.productID);
                        _Command.Parameters.AddWithValue("@checkOutID", transactionToCreate.checkOutID);
                        _Command.Parameters.AddWithValue("@supplierID", transactionToCreate.supplierID);
                        //_Command.Parameters.AddWithValue("@supplierName", transactionToCreate.supplierName);
                        //_Command.Parameters.AddWithValue("@productDescription", transactionToCreate.productDescription);
                        //_Command.Parameters.AddWithValue("@productPrice", transactionToCreate.productPrice);
                        //_Command.Parameters.AddWithValue("@checkOutQuantity", transactionToCreate.checkOutQuantity);
                        //_Command.Parameters.AddWithValue("@checkOutShipping", transactionToCreate.checkOutShipping);
                        //_Command.Parameters.AddWithValue("@checkOutTotal", transactionToCreate.checkOutTotal);

                        // open the connection
                        _Connection.Open();

                        //Execute the command
                        _Command.ExecuteNonQuery();

                        // change the status of the bool
                        success = true;

                        // close the connection
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

        public List<CartDAO> ViewTransactions()
        {
            // create a new instance of productDOA that is a list
            List<CartDAO> itemList = new List<CartDAO>();

            // create try catch to catch any possible errors
            try
            {
                // create a using statment to use the connection string
                using (SqlConnection _Connection = new SqlConnection(connectionString))
                {
                    // create using statment to specify the stored procedure
                    using (SqlCommand _Command = new SqlCommand("sp_UserTransaction", _Connection))
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
                                CartDAO itemToList = new CartDAO();
                                itemToList.userTransactionID = Convert.ToInt32(_Reader["userTransactionID"]);
                                itemToList.datePurchase = Convert.ToDateTime(_Reader["datePurchase"]);
                                itemToList.userTableID = Convert.ToInt32(_Reader["userTableID"]);
                                itemToList.productID = Convert.ToInt32(_Reader["productID"]);
                                itemToList.checkOutID = Convert.ToInt32(_Reader["checkOutID"]);
                                itemToList.supplierID = Convert.ToInt32(_Reader["supplierID"]);
                                itemToList.supplierName = (String)_Reader["supplierName"];
                                itemToList.productDescription = (String)_Reader["productDescription"];
                                itemToList.productPrice = Convert.ToDecimal(_Reader["productPrice"]);
                                itemToList.checkOutQuantity = Convert.ToInt32(_Reader["checkOutQuantity"]);
                                itemToList.checkOutShipping = Convert.ToDecimal(_Reader["checkOutShipping"]);
                                itemToList.checkOutTotal = Convert.ToDecimal(_Reader["checkOutTotal"]);
                                itemList.Add(itemToList);

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
            return itemList;
        }
    }
}

   

