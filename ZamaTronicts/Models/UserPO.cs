using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ZamaTronicts.Models
{
    public class UserPO
    {
        public int accountInfoID { get; set; }
        public int userTableID { get; set; }
        public int userRole { get; set; }

       // [Required]
        [Display(Name = "First Name")]
        public String accountFirstName { get; set; }

        //[Required]
        [Display(Name = "Last Name")]
        public String accountLastName { get; set; }

        [Display(Name = "Email")]
       // [Required]
        [DataType(DataType.EmailAddress)]
        public String accountEmail { get; set; }

        [Display(Name = "Phone Number")]
        //[Required]
        public String accountPhoneNumber { get; set; }

        [Display(Name = "Address")]
        //[Required]
        public String accountAddress { get; set; }

        [Display(Name = "City")]
        //[Required]
        public String accountCity { get; set; }

        [Display(Name = "State")]
        //[Required]
        public String accountState { get; set; }

        [Display(Name = "Zip")]
       // [Required]
        public int accountZip { get; set; }

        
        [Display(Name = "UserName")]
        [Required]
        public string userName { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string userPassword { get; set; }

        [Display(Name = "Role")]
        public string roleName { get; set; }
    }
}