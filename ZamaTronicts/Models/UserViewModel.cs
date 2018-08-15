using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZamaTronicts.Models
{
    public class UserViewModel
    {
        // create constructor for a single/list of users
        public UserPO singleUserPO { get; set; }
        public List<UserPO> listUserPO { get; set; }

        // create the method for the UserViewModel
        public UserViewModel()
        {
            // instaniate a new instance of the single user and list of users
            singleUserPO = new UserPO();
            listUserPO = new List<UserPO>();
        }
    }
}