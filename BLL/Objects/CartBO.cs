using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Objects
{
    public class CartBO
    {
        public int checkOutID { get; set; }
        public int checkOutQuantity { get; set; }
        public decimal checkOutTax { get; set; }
        public decimal checkOutShipping { get; set; }
        public decimal checkOutTotal { get; set; }
        public int checkOutDate { get; set; }
        public int userTableID { get; set; }
        public int productID { get; set; }
        public String supplierName { get; set; }
        public String productDescription { get; set; }
        public double productPrice { get; set; }
        public decimal finalTotal { get; set; }
        public int userTransactionID { get; set; }
        public DateTime datePurchase { get; set; }

    }
}
