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
    public class UserDataAccess
    {
        // Create string for the DB connection
        static string connectionString = ConfigurationManager.ConnectionStrings["ZamaTronictsDB"].ConnectionString;

        // Create an instance of the ErrorLogger
        static ErrorLogger ErrorMessage = new ErrorLogger();

        // create a method to create a new user
        public bool CreateUser(UserDAO userToCreate)
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
                    using (SqlCommand _Command = new SqlCommand("sp_UserAccountInfoCreateUser", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;

                        // pass the info to the stored procedure
                        _Command.Parameters.AddWithValue("@accountFirstName", userToCreate.accountFirstName);
                        _Command.Parameters.AddWithValue("@accountLastName", userToCreate.accountLastName);
                        _Command.Parameters.AddWithValue("@accountEmail", userToCreate.accountEmail);
                        _Command.Parameters.AddWithValue("@accountPhoneNumber", userToCreate.accountPhoneNumber);
                        _Command.Parameters.AddWithValue("@accountAddress", userToCreate.accountAddress);
                        _Command.Parameters.AddWithValue("@accountCity", userToCreate.accountCity);
                        _Command.Parameters.AddWithValue("@accountState", userToCreate.accountState);
                        _Command.Parameters.AddWithValue("@accountZip", userToCreate.accountZip);
                        _Command.Parameters.AddWithValue("@userName", userToCreate.userName);
                        _Command.Parameters.AddWithValue("@userPassword", userToCreate.userPassword);
                        _Command.Parameters.AddWithValue("@userRole", userToCreate.userRole);
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
        // create a method to update a user
        public bool UpdateUser(UserDAO userToUpdate)
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
                    using (SqlCommand _Command = new SqlCommand("sp_UserAccountInfoUpdateUser", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;
                        // pass the info to the stored procedure
                        _Command.Parameters.AddWithValue("@userTableID", userToUpdate.userTableID);
                        _Command.Parameters.AddWithValue("@accountInfoID", userToUpdate.accountInfoID);
                        _Command.Parameters.AddWithValue("@accountFirstName", userToUpdate.accountFirstName);
                        _Command.Parameters.AddWithValue("@accountLastName", userToUpdate.accountLastName);
                        _Command.Parameters.AddWithValue("@accountEmail", userToUpdate.accountEmail);
                        _Command.Parameters.AddWithValue("@accountPhoneNumber", userToUpdate.accountPhoneNumber);
                        _Command.Parameters.AddWithValue("@accountAddress", userToUpdate.accountAddress);
                        _Command.Parameters.AddWithValue("@accountCity", userToUpdate.accountCity);
                        _Command.Parameters.AddWithValue("@accountState", userToUpdate.accountState);
                        _Command.Parameters.AddWithValue("@accountZip", userToUpdate.accountZip);
                        _Command.Parameters.AddWithValue("@userRole", userToUpdate.userRole);
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

        // create a method to delete a user
        public bool DeleteUser(int userTableID, int accountInfoID)
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
                    using (SqlCommand _Command = new SqlCommand("sp_UserAccountInfoDeleteUser", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;
                        // pass the id of the user to delete
                        _Command.Parameters.AddWithValue("userTableID", userTableID);
                        _Command.Parameters.AddWithValue("accountInfoID", accountInfoID);
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

        // create a method to view all users
        public List<UserDAO> ViewAllUsers()

        {
            // create a new instance of userDAO 
            List<UserDAO> _UserList = new List<UserDAO>();

            // set the bool to false
            bool success = false;

            // create try catch to catch any possible errors
            try
            {
                // create a using statment to use the connection string
                using (SqlConnection _Connection = new SqlConnection(connectionString))
                {
                    // create using statment to specify the stored procedure
                    using (SqlCommand _Command = new SqlCommand("sp_UserAccountInfoViewAllUsers", _Connection))
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
                                // create a new instance of userDOA to retrieve each item
                                UserDAO userToList = new UserDAO();

                                // get the user elements
                                userToList.accountInfoID = Convert.ToInt32(_Reader["accountInfoID"]);
                                userToList.userTableID = Convert.ToInt32(_Reader["userTableID"]);
                                userToList.accountFirstName = (string)_Reader["accountFirstName"];
                                userToList.accountLastName = (string)_Reader["accountLastName"];
                                userToList.accountEmail = (string)_Reader["accountEmail"];
                                userToList.accountPhoneNumber = (string)_Reader["accountPhoneNumber"];
                                userToList.accountAddress = (string)_Reader["accountAddress"];
                                userToList.accountCity = (string)_Reader["accountCity"];
                                userToList.accountState = (string)_Reader["accountState"];
                                userToList.accountZip = Convert.ToInt32(_Reader["accountZip"]);
                                userToList.roleName = (string)_Reader["roleName"];
                                _UserList.Add(userToList);
                            }
                        }
                        //change the bool to true
                        success = true;

                        //close the connection
                        _Connection.Close();
                    }
                }
            }
            catch (Exception error)
            {
                // call the error method and pass the error
                ErrorMessage.logger(error);
            }
            return _UserList;
        }

        // create a method to view only one user
        public UserDAO ViewOneUser(int userID)
        {
            // create a new instance of userDOA
            UserDAO _User = new UserDAO();
           

            // create try catch to catch any possible errors
            try
            {
                // create a using statment to use the connection string
                using (SqlConnection _Connection = new SqlConnection(connectionString))
                {
                    // create using statment to specify the stored procedure
                    using (SqlCommand _Command = new SqlCommand("sp_UserAccountInfoViewOneUser", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;
                        _Command.Parameters.AddWithValue("@userTableID", userID);
                     

                        // open the connection
                        _Connection.Open();

                        // create a using statement using the reader to reader through the list
                        using (SqlDataReader _Reader = _Command.ExecuteReader())
                        {
                            // create a while loop to read throught the whole record
                            while (_Reader.Read())
                            {
                                // get the user elements
                                _User.userTableID = Convert.ToInt32(_Reader["userTableID"]);
                                _User.accountInfoID = Convert.ToInt32(_Reader["accountInfoID"]);
                                _User.accountFirstName = (string)_Reader["accountFirstName"];
                                _User.accountLastName = (string)_Reader["accountLastName"];
                                _User.accountEmail = (string)_Reader["accountEmail"];
                                _User.accountPhoneNumber = (string)_Reader["accountPhoneNumber"];
                                _User.accountAddress = (string)_Reader["accountAddress"];
                                _User.accountCity = (string)_Reader["accountCity"];
                                _User.accountState = (string)_Reader["accountState"];
                                _User.accountZip = Convert.ToInt32(_Reader["accountZip"]);
                                _User.roleName = (string) _Reader["roleName"];
                                _User.userName = (string)_Reader["userName"];
                                _User.userPassword = (string)_Reader["userPassword"];
                                _User.userRole = Convert.ToInt32(_Reader["userRole"]);
                            }
                        }
                    }
                 
                    //close the connection
                    _Connection.Close();
                }
            }
            catch (Exception error)
            {
                // call the error method and pass the error
                ErrorMessage.logger(error);
            }
            return _User;
        }

        // create a method for userlogin
        public UserDAO LoginUser(UserDAO _UserLogin)
        {
            // create a new instance of userDAO
            UserDAO _User = new UserDAO();

            // create try catch to catch any possible errors
            try
            {
                // create a using statment to use the connection string
                using (SqlConnection _Connection = new SqlConnection(connectionString))
                {
                    // create using statment to specify the stored procedure
                    using (SqlCommand _Command = new SqlCommand("sp_UserTableUserLogIn", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;
                        _Command.Parameters.AddWithValue("@userName", _UserLogin.userName);
                     
                        // open the connection
                        _Connection.Open();
                        // create a using statement using the reader to reader through the list
                        using (SqlDataReader _Reader = _Command.ExecuteReader())
                        {
                            // create a while loop to read throught the whole record
                            while (_Reader.Read())
                            {
                                
                                _User.userTableID = Convert.ToInt32(_Reader["userTableID"]);
                                _User.userName = (string)_Reader["userName"];
                                _User.userPassword = (string)_Reader["userPassword"];
                                _User.userRole = Convert.ToInt32(_Reader["userRole"]);
                                _User.roleName = (String)_Reader["roleName"];
                            }
                        }

                        //close the connection
                        _Connection.Close();
                    }
                }
            }
            catch (Exception error)
            {
                // call the error method and pass the error
                ErrorMessage.logger(error);
            }
            return _User;
        }
        public List<UserDAO> ViewAllRoles()

        {
            // create a new instance of userDAO 
            List<UserDAO> _UserList = new List<UserDAO>();

            // set the bool to false
            bool success = false;

            // create try catch to catch any possible errors
            try
            {
                // create a using statment to use the connection string
                using (SqlConnection _Connection = new SqlConnection(connectionString))
                {
                    // create using statment to specify the stored procedure
                    using (SqlCommand _Command = new SqlCommand("sp_RoleTableViewAllRoles", _Connection))
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
                                // create a new instance of userDOA to retrieve each item
                                UserDAO userToList = new UserDAO();

                                // get the user elements
                                //userToList.accountInfoID = Convert.ToInt32(_Reader["accountInfoID"]);
                                //userToList.userTableID = Convert.ToInt32(_Reader["userTableID"]);
                                userToList.roleName = (string)(_Reader["roleName"]);
                                userToList.userRole = Convert.ToInt32(_Reader["userRoleID"]);
                                _UserList.Add(userToList);
                            }
                        }
                        //change the bool to true
                        success = true;

                        //close the connection
                        _Connection.Close();
                    }
                }
            }
            catch (Exception error)
            {
                // call the error method and pass the error
                ErrorMessage.logger(error);
            }
            return _UserList;
        }
        public bool CreateRole(UserDAO roleToCreate)
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
                    using (SqlCommand _Command = new SqlCommand("sp_RoleTableCreateRole", _Connection))
                    {
                        // specify the command is a stored procedure
                        _Command.CommandType = System.Data.CommandType.StoredProcedure;

                        // pass the info to the stored procedure
                        _Command.Parameters.AddWithValue("@roleName", roleToCreate.roleName);
                      
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
    }
}
              