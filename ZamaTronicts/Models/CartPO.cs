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
        public String supplierName { get; set; }
        public String productDescription { get; set; }
        public decimal productPrice { get; set; }
        public int checkOutID { get; set; }
        public int userTransactionID { get; set; }
        public DateTime datePurchase { get; set; }


        [Range(0,100)]
        public int checkOutQuantity { get; set; }
        public decimal checkOutTax { get; set; }
        public decimal checkOutShipping { get; set; }
        public decimal checkOutTotal { get; set; }
        public DateTime checkOutDate { get; set; }
        public int userTableID { get; set; }
        public int productID { get; set; }
        public decimal finalTotal { get; set; }
    }
}