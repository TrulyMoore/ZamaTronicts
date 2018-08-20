using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZamaTronicts.Models
{
    public class ProductViewModel
    {
        // create constructor for a single/list of product
        public ProductPO singleProductPO { get; set; }
        public List<ProductPO> listProductPO { get; set; }
        public int userTableID { get; set; }
        
        // create the method for the productViewModel
        public ProductViewModel()
        {
            // instaniate a new instance of the single product and list of products
            singleProductPO = new ProductPO();
            listProductPO = new List<ProductPO>();
        }
    }
}