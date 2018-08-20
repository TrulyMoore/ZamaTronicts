using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ZamaTronicts.Models
{
    public class UserLoginPO
    {
        [Display(Name = "UserName")]
        [Required]
        public string userName { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string userPassword { get; set; }
    }
}