using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ZamaTronicts.Models
{
    public class CartViewModel
    {
        public CartPO singleItemPO { get; set; }
        public List<CartPO> listOfItemsPO { get; set; }
        //[Display(Name = "Final Total")]
        public decimal finalTotal { get; set; }
        //[Display(Name = "Total")]
        public decimal itemTotal { get; set; }
        public int _userTableID { get; set; }
        public CartViewModel()
        {

            singleItemPO = new CartPO();
            listOfItemsPO = new List<CartPO>();
        }
    }
}






       