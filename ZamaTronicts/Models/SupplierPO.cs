using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ZamaTronicts.Models
{
    public class SupplierPO
    {
        public int supplierID { get; set; }
       [Display(Name = "Name")]
        public String supplierName { get; set; }
       [Display(Name = "Address")]
        public String supplierAddress { get; set; }
      [Display(Name = "City")]
        public String supplierCity { get; set; }
      [Display(Name = "State")]
        public String supplierState { get; set; }
      [Display(Name = "Zip")]
        public int supplierZip { get; set; }
       [Display(Name = "Phone Number")]
        public String supplierPhoneNumber { get; set; }
    }
}