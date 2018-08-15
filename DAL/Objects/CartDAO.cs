using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Objects
{
    public class CartDAO
    {
        public String supplierName { get; set; }
        public String productDescription { get; set; }
        public decimal productPrice { get; set; }
        public int checkOutID { get; set; }
        public int checkOutQuantity { get; set; }
        public decimal checkOutTax { get; set; }
        public decimal checkOutShipping { get; set; }
        public decimal checkOutTotal { get; set; }
        public DateTime checkOutDate { get; set; }
        public int userTableID { get; set; }
        public int productID { get; set; }
        public int userTransactionID { get; set; }
        public DateTime datePurchase { get; set; }
        public int supplierID { get; set; }
    }  
}
