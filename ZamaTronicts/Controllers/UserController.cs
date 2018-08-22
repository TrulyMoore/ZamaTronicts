using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Objects;
using ZamaTronicts.Models;

namespace ZamaTronicts.Controllers
{
    public class UserController : Controller
    {
        // create a new instance of the mapper and userViewModel
        static UserDataAccess _userDataAccess = new UserDataAccess();
        static Mapper _mapper = new Mapper();

        // create a post and get method to create a new user
        [HttpGet]
        public ActionResult CreateUser()
        {
            // create a new instance  of userModel
            UserPO _userModel = new UserPO();

            // set the default role value of one which is customer
            _userModel.userRole = 1;

            // return the userModel and view
            return View(_userModel);
        }

        // create a method to create a new user
        [HttpPost]
        public ActionResult CreateUser(UserPO userModel)
        {
            // pass the user model through the mapper to the method
            _userDataAccess.CreateUser(_mapper.Map(userModel));

            // return to the login page
            return RedirectToAction("Login");
        }

        // create the get/post update methods to update the user info
        [HttpGet]
        public ActionResult UpdateUser(int userTableID)
        {
            // call the dropdown method to view available roles
            DropDown();

            // instaniate a new usermodel
            UserViewModel _userModel = new UserViewModel();

            // pass the userID to the view method through the DAL
            // then pass through the mapper and set to the single user
            _userModel.singleUserPO = _mapper.Map(_userDataAccess.ViewOneUser(userTableID));

            //return the view with the single user
            return View(_userModel.singleUserPO);
        }

        [HttpPost]
        public ActionResult UpdateUser(UserPO userToMap)
        {

            // pass the user through the mapper to the method in the DAL
            _userDataAccess.UpdateUser(_mapper.Map(userToMap));

            if ((string)Session["roleName"] == "customer")
            {
                return RedirectToAction("ViewProducts", "Product");
            }
                // return to a list of users
                return RedirectToAction("ViewUsers");
        }

        // create a get method to view all of the users
        [HttpGet]
        public ActionResult ViewUsers()
        {
            //create a new instance of userViewModels
            UserViewModel _userViewModel = new UserViewModel();

            // call the method and pass through the DAL to the mapper then pass to the user list
            _userViewModel.listUserPO = _mapper.Map(_userDataAccess.ViewAllUsers());

            // return the viewModel
            return View(_userViewModel);
        }

        // create a get method to delete a user
        [HttpGet]
        public ActionResult DeleteUser(int userTableID, int accountInfoID)
        {
            if ((string)Session["roleName"] == "admin")
            {
                // pass the userID to the method in the DAL
                _userDataAccess.DeleteUser(userTableID, accountInfoID);
            }
            // return the view to view all of the users
            return RedirectToAction("ViewUsers");
        }

        // create the get/post login methods
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserPO userModel)
        {
            // check to make sure the user is accessing the right view/browser
            if (ModelState.IsValid)
            {
                // map the info
                UserDAO _user = _userDataAccess.LoginUser(_mapper.Map(userModel));

                // if the user does not exist take them to the create user page
                if (_user.userPassword == userModel.userPassword)
                {
                    // put the user values to the sesion variables
                    Session["userTableID"] = _user.userTableID;
                    Session["roleName"] = _user.roleName;
                    Session["userRole"] = _user.userRole;
                }
                else
                {
                    // display message if the info does not match

                    ViewBag.errorMessage = "Incorrect username/password";

                    // return the view
                    return View();
                }

            }
            return RedirectToAction("ViewProducts", "Product");
        }

        // create method for user logout
        [HttpGet]
        public ActionResult Logout()
        {
            // abandon the session
            Session.Abandon();

            // return home
            return RedirectToAction("Index", "Home");
        }

        // create a dropdown method to view all available roles
        [HttpGet]
        private void DropDown()
        {
            // create a new list 
            ViewBag.ListRoles = new List<SelectListItem>();
            List<UserPO> role = _mapper.Map(_userDataAccess.ViewAllRoles());

            // loop through the roles
            foreach (UserPO roles in role)
            {
                ViewBag.ListRoles.Add(new SelectListItem { Text = roles.roleName, Value = roles.userRole.ToString() });
            }
        }

        [HttpGet]
        public ActionResult CreateRole()
        {
            // create a new instance  of userModel
            UserPO _userModel = new UserPO();

            // return the userModel and view
            return View(_userModel);
        }

        [HttpPost]
        public ActionResult CreateRole(UserPO userModel)
        {
            // pass the user model through the mapper to the method  
            _userDataAccess.CreateRole(_mapper.Map(userModel));

            // return to the login page
            return RedirectToAction("Login");
        }
    }
}
