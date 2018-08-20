using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ZamaTronicts.Models
{
    public class ProductPO
    {
        public int productID { get; set; }
        public int userID { get; set; }
        [Display(Name = "Product Description")]
        public String productDescription { get; set; }
        [Display(Name = "Processor")]
        public String productProcessor { get; set; }
        [Display(Name = "Operating System")]
        public String productOperatingSystem { get; set; }
        [Display(Name = "Quantity")]
        public int productQuantity { get; set; }
        [Display(Name = "Ram")]
        public String productRam { get; set; }
        [Display(Name = "Price")]
        public double productPrice { get; set; }
        public int supplierID { get; set; }
        [Display(Name ="Supplier")]
        public string supplierName { get; set; }
        public SupplierPO supplier { get; set; }

    }
}