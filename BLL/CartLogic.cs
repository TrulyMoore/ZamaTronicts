using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Objects;



namespace BLL
{
    public class CartLogic
    {
        List<CartBO> totalList = new List<CartBO>();
        CartBO productList = new CartBO();
        CartBO cart = new CartBO();

        public decimal GetProductTotal(CartBO cartInfo)
        {
            decimal subTotal = cartInfo.checkOutTotal * cartInfo.checkOutQuantity;
            decimal subTax = subTotal * cartInfo.checkOutTax;
           subTotal= (subTotal + subTax);
            
            return subTotal;
        }

        public decimal GetFinalTotal(List<CartBO> totalList)
        {
            decimal shipping = 10.00M;
            decimal finalTotal =0;
            foreach (CartBO singleList in totalList)
            {
                finalTotal += GetProductTotal(singleList);
            }
            
            return finalTotal +shipping;

        }
    }
}
