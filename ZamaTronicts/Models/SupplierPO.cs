using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZamaTronicts.Models
{
    public class SupplierPO
    {
        public int supplierID { get; set; }
        public String supplierName { get; set; }
        public String supplierAddress { get; set; }
        public String supplierCity { get; set; }
        public String supplierState { get; set; }
        public int supplierZip { get; set; }
        public String supplierPhoneNumber { get; set; }
    }
}