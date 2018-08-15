using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZamaTronicts.Models
{
    public class SupplierViewModel
    {
        // create constructor for a single/list of suppliers
        public SupplierPO singleSupplierPO { get; set; }
        public List<SupplierPO> listSupplierPO { get; set; }

        // create the method for the SupplierViewModel
        public SupplierViewModel()
        {
            // instaniate a new instance of the single supplier and list of suppliers
            singleSupplierPO = new SupplierPO();
            listSupplierPO = new List<SupplierPO>();
        }
    }
}