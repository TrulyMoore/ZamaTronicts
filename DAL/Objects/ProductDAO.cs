using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Objects
{ 
    
   public class ProductDAO
    {
        // create the constructors
        public int productID { get; set; }
        public String productDescription { get; set; }
        public String productProcessor { get; set; }
        public String productOperatingSystem { get; set; }
        public int productQuantity { get; set; }
        public String productRam { get; set; }
        public decimal productPrice { get; set; }
        public int supplierID { get; set; }
        public String supplierName { get; set; }
    }
}
