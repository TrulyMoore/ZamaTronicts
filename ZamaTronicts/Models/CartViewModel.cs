using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZamaTronicts.Models
{
    public class CartViewModel
    {
        public CartPO singleItemPO { get; set; }
        public List<CartPO> listOfItemsPO { get; set; }
        public decimal finalTotal { get; set; }
        public decimal itemTotal { get; set; }
        public CartViewModel()
        {

            singleItemPO = new CartPO();
            listOfItemsPO = new List<CartPO>();
        }
    }
}






       