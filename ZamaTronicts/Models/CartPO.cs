using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZamaTronicts.Models
{
    public class CartPO
    {
        public int supplierID { get; set; }
        public int checkOutID { get; set; }
        public int productID { get; set; }
        public int userTransactionID { get; set; }
        public int userTableID { get; set; }
        [Display(Name = "Supplier")]
        public String supplierName { get; set; }
        [Display(Name = "Product Description")]
        public String productDescription { get; set; }
        [Display(Name = "Price")]
        public decimal productPrice { get; set; }
        [Display(Name = "Date of Purchase")]
        public DateTime datePurchase { get; set; }
        [Display(Name = "Tax")]
        public decimal checkOutTax { get; set; }
        [Display(Name ="Shipping")]
        public decimal checkOutShipping { get; set; }
        [Display(Name = "Price")]
        public decimal checkOutTotal { get; set; }
        [Display(Name = "Date Added")]
        public DateTime checkOutDate { get; set; }
        [Display(Name = "Final Total")]
        public decimal total { get; set; }
        [Range(0,100)]
        [Display(Name = "Quantity")]
        public int checkOutQuantity { get; set; }
    }
}