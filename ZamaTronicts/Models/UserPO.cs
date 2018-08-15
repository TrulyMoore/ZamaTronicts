using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZamaTronicts.Models
{
    public class UserPO
    {
        public int accountInfoID { get; set; }
        public String accountFirstName { get; set; }
        public String accountLastName { get; set; }
        public String accountEmail { get; set; }
        public String accountPhoneNumber { get; set; }
        public String accountAddress { get; set; }
        public String accountCity { get; set; }
        public String accountState { get; set; }
        public int accountZip { get; set; }
        public int userTableID { get; set; }
        public int userRole { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string roleName { get; set; }
    }
}