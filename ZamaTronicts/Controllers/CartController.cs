using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZamaTronicts.Models;
using DAL;
using BLL;
//using BLL:

namespace ZamaTronicts.Controllers
{
    public class CartController : Controller
    {
        // create a new instance of the mapper/ business/ and logic layers
        static Mapper _mapper = new Mapper();
        static CartDataAccess _cartDataAccess = new CartDataAccess();
        static ProductDataAccess _productDataAccess = new ProductDataAccess();
        static CartLogic _cartBusinessLogic = new CartLogic();

        // create a get/post method to add an item to the cart
        [HttpGet]
        public ActionResult AddToCart(int productID)
        {
            // call the method and map the info to the productInfo
           ProductPO productInfo = _mapper.Map(_productDataAccess.ViewOneProduct(productID));

            // create a new instance of cartPO
           CartPO _CheckOut = new CartPO();

            // set correct values to the _checkOut
            _CheckOut.checkOutTotal = productInfo.productPrice;
            _CheckOut.productID = productID;
            _CheckOut.productQuantity = productInfo.productQuantity;
            _CheckOut.supplierID = productInfo.supplierID;
            _CheckOut.supplierName = productInfo.supplierName;
            _CheckOut.userTableID = (int)Session["userTableID"];
            _CheckOut.checkOutQuantity = 1;
            _CheckOut.checkOutTax = 0.04M;
           _CheckOut.checkOutShipping =  10.00M;
            _CheckOut.checkOutDate = DateTime.Today;

            // map the info
            _cartDataAccess.CreateCart(_mapper.Map(_CheckOut));

            // return to the view products view
            return RedirectToAction("ViewProducts","Product");
        }

        [HttpGet]
        public ActionResult ViewCart(int userTableID)
        {
            // create the variables for the item and final 
            decimal finalTotal;
            decimal itemTotal;

            // create a new instance of cartViewModel
            CartViewModel _cartViewModel = new CartViewModel();
            _cartViewModel.listOfItemsPO = _mapper.Map(_cartDataAccess.ViewCart(userTableID));

            finalTotal = _cartBusinessLogic.GetFinalTotal(_mapper.GetProductInfoList(_cartViewModel.listOfItemsPO));
            _cartViewModel.finalTotal = finalTotal;
            _cartViewModel._userTableID = userTableID;
            _cartViewModel.productQuantity = _cartViewModel.singleItemPO.productQuantity;

            foreach (CartPO singleItem in _cartViewModel.listOfItemsPO)
            {
                itemTotal = _cartBusinessLogic.GetProductTotal(_mapper.GetProductInfo(singleItem));
                singleItem.total = itemTotal;

            }

            // return the view
            return View(_cartViewModel);
        }
        
        [HttpPost]
        public ActionResult UpdateItemQuantity(CartPO item)
        {
            if (item.checkOutQuantity > item.productQuantity)
            {
                return RedirectToAction("ViewCart", "Cart", new { userTableID = item.userTableID } );
            }
            else
            {
               // pass the id to the method then to the DAL
                _cartDataAccess.UpdateItemQuantity(item.checkOutID, item.checkOutQuantity, item.productID);
            }
            // return the view cart page
            return RedirectToAction("ViewCart","Cart", new { userTableID = item.userTableID });
        }

        [HttpGet]
        public ActionResult DeleteItemFromCart(int checkOutID, int userTableID)
        {
            _cartDataAccess.DeleteItemFromCart(checkOutID);
          
            // pass the parameter as an object
              return RedirectToAction("ViewCart",new {userTableID = userTableID} );
        }


        [HttpGet]
        public ActionResult ViewTransactions(int userTableID)
        {
            List<CartPO> cartInfo  = _mapper.Map(_cartDataAccess.ViewCart(userTableID));
            _cartDataAccess.CreateTransaction(_mapper.Map(cartInfo));


            List<CartPO> _Transaction = _mapper.Map(_cartDataAccess.ViewTransactions(userTableID));
          
        
            return View(_Transaction);
        }      

    }
}

