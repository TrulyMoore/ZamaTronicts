using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZamaTronicts.Models
{
    public class ProductPO
    {
        public int productID { get; set; }
        public String productDescription { get; set; }
        public String productProcessor { get; set; }
        public String productOperatingSystem { get; set; }
        public int productQuantity { get; set; }
        public String productRam { get; set; }
        public decimal productPrice { get; set; }
        public int userID { get; set; }

    }
}