// using directives
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
   public class SupplierDataAccess
    {
        // Create string for the DB connection
        static string connectionString = ConfigurationManager.ConnectionStrings["ZamaTronictsDB"].ConnectionString;

        // Create an instance of the ErrorLogger
        static ErrorLogger ErrorMessage = new ErrorLogger();

        // Create method to add  a supplier
        public bool AddSupplier(SupplierDAO supplierToAdd)
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
                    using (SqlCommand _Command = new SqlCommand("sp_SupplierCreateSupplier", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;

                        // pass the info to the stored procedure
                        _Command.Parameters.AddWithValue("@supplierName", supplierToAdd.supplierName);
                        _Command.Parameters.AddWithValue("@supplierAddress", supplierToAdd.supplierAddress);
                        _Command.Parameters.AddWithValue("@supplierCity", supplierToAdd.supplierCity);
                        _Command.Parameters.AddWithValue("@supplierState", supplierToAdd.supplierState);
                        _Command.Parameters.AddWithValue("@supplierZip", supplierToAdd.supplierZip);
                        _Command.Parameters.AddWithValue("@supplierPhoneNumber", supplierToAdd.supplierPhoneNumber);

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
        // create the method to update a supplier
        public bool UpdateSupplier(SupplierDAO supplierToUpdate)
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
                    using (SqlCommand _Command = new SqlCommand("sp_SupplierUpdateSupplier", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;
                        // pass the info to the stored procedure
                        _Command.Parameters.AddWithValue("@supplierID", supplierToUpdate.supplierID);
                        _Command.Parameters.AddWithValue("@supplierName", supplierToUpdate.supplierName);
                        _Command.Parameters.AddWithValue("@supplierAddress", supplierToUpdate.supplierAddress);
                        _Command.Parameters.AddWithValue("@supplierCity", supplierToUpdate.supplierCity);
                        _Command.Parameters.AddWithValue("@supplierState", supplierToUpdate.supplierState);
                        _Command.Parameters.AddWithValue("@supplierZip", supplierToUpdate.supplierZip);
                        _Command.Parameters.AddWithValue("@supplierPhoneNumber", supplierToUpdate.supplierPhoneNumber);

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
        // create the method to delete supplier and pass in the supplier to delete
        public bool DeleteSupplier(int supplierToDelete)
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
                    using (SqlCommand _Command = new SqlCommand("sp_SupplierDeleteSupplier", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;
                        // pass the ID of the product to delete
                        _Command.Parameters.AddWithValue("supplierID", supplierToDelete);
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

        // create the method to view all suppliers
        public List<SupplierDAO> ViewAllSuppliers()
        {
            // create a new instance of supplierDOA that is a list
            List<SupplierDAO> supplierList = new List<SupplierDAO>();

            // create try catch to catch any possible errors
            try
            {
                // create a using statment to use the connection string
                using (SqlConnection _Connection = new SqlConnection(connectionString))
                {
                    // create using statment to specify the stored procedure
                    using (SqlCommand _Command = new SqlCommand("sp_SupplierViewAllSuppliers", _Connection))
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
                                // create a new instance of SupplierDOA to retrieve each item
                                SupplierDAO supplierToList = new SupplierDAO();
                                // get the product elements
                                supplierToList.supplierID = Convert.ToInt32(_Reader["supplierID"]);
                                supplierToList.supplierName = (String)_Reader["supplierName"];
                                supplierToList.supplierAddress = (String)_Reader["supplierAddress"];
                                supplierToList.supplierCity = (String)_Reader["supplierCity"];
                                supplierToList.supplierState = (String)_Reader["supplierState"];
                                supplierToList.supplierZip = Convert.ToInt32(_Reader["supplierZip"]);
                                supplierToList.supplierPhoneNumber = (String)_Reader["supplierPhoneNumber"];

                                // return the info in a complete list
                                supplierList.Add(supplierToList);


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
            return supplierList;
        }

        // create the method to view one supplier
        public SupplierDAO ViewOneSupplier(int supplierID)
        {
            // create a new instance of supplierDOA 
            SupplierDAO _Supplier = new SupplierDAO();

            // create try catch to catch any possible errors
            try
            {
                // create a using statment to use the connection string
                using (SqlConnection _Connection = new SqlConnection(connectionString))
                {
                    // create using statment to specify the stored procedure
                    using (SqlCommand _Command = new SqlCommand("sp_SupplierViewOneSupplier", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;
                        // pass the supplier ID of the item to view
                        _Command.Parameters.AddWithValue("@supplierID", supplierID);
                        // open the connection
                        _Connection.Open();

                        // create a using statement using the reader to reader through the list
                        using (SqlDataReader _Reader = _Command.ExecuteReader())
                        {
                            // create a while loop to read throught the whole record
                            while (_Reader.Read())
                            {
                                // get the product elements
                                _Supplier.supplierID = Convert.ToInt32(_Reader["supplierID"]);
                                _Supplier.supplierName = (String)_Reader["supplierName"];
                                _Supplier.supplierAddress = (String)_Reader["supplierAddress"];
                                _Supplier.supplierCity = (String)_Reader["supplierCity"];
                                _Supplier.supplierState = (String)_Reader["supplierState"];
                                _Supplier.supplierZip = Convert.ToInt32(_Reader["supplierZip"]);
                                _Supplier.supplierPhoneNumber = (String)_Reader["supplierPhoneNumber"];
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
            return _Supplier;
        }
    }
}
