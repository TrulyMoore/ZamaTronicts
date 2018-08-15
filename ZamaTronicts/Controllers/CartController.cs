﻿using System;
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

        static Mapper _mapper = new Mapper();
        static CartDataAccess _cartDataAccess = new CartDataAccess();
        static ProductDataAccess _productDataAccess = new ProductDataAccess();
        static CartLogic _cartBusinessLogic = new CartLogic();


        [HttpGet]
        public ActionResult AddToCart(int productID)
        {
            
           ProductPO productInfo = _mapper.Map(_productDataAccess.ViewOneProduct(productID));

           CartPO _CheckOut = new CartPO();
            _CheckOut.checkOutTotal = productInfo.productPrice;
            _CheckOut.productID = productID;
            _CheckOut.userTableID = (int)Session["userTableID"];
            _CheckOut.checkOutQuantity = 1;
            _CheckOut.checkOutTax = 0.04M;
           _CheckOut.checkOutShipping =  10.00M;
            _CheckOut.checkOutDate = DateTime.Today;

            _cartDataAccess.CreateCart(_mapper.Map(_CheckOut));

            return RedirectToAction("ViewProducts","Product");
        }

        [HttpGet]
        public ActionResult ViewCart(int userTableID)
        {
            decimal finalTotal;
            decimal itemTotal;

            // create a new instance of cartViewModel
            CartViewModel _cartViewModel = new CartViewModel();
            _cartViewModel.listOfItemsPO = _mapper.Map(_cartDataAccess.ViewCart(userTableID));

            finalTotal = _cartBusinessLogic.GetFinalTotal(_mapper.GetProductInfoList(_cartViewModel.listOfItemsPO));
            _cartViewModel.finalTotal = finalTotal;

            foreach (CartPO singleItem in _cartViewModel.listOfItemsPO)
            {
                itemTotal = _cartBusinessLogic.GetProductTotal(_mapper.GetProductInfo(singleItem));
                singleItem.finalTotal = itemTotal;

            }

            // return the view
            return View(_cartViewModel);
        }

        [HttpGet]
        public ActionResult DeleteItemFromCart(int checkOutID, int userTableID)
        {
            _cartDataAccess.DeleteItemFromCart(checkOutID);
          
            // pass the parameter as an object
              return RedirectToAction("ViewCart",new {userTableID = userTableID} );
        }

        [HttpPost]
        public ActionResult UpdateItemQuantity(CartPO item)
        {
            // pass the id to the method then to the DAL
            _cartDataAccess.UpdateItemQuantity(item.checkOutID, item.checkOutQuantity);

            // return the view cart page
            return RedirectToAction("ViewCart","Cart", new { userTableID = item.userTableID });
        }

        [HttpGet]
        public ActionResult CreateTransactions(int userTableID)
        {
            CartPO transactionInfo = _mapper.Map(_cartDataAccess.ViewOneProduct(userTableID));
            CartPO _transaction = new CartPO();
            _transaction.userTransactionID = transactionInfo.productPrice;
            _CheckOut.productID = productID;


            return RedirectToAction("ViewTransactions","Cart");
        }


        [HttpGet]
        public ActionResult ViewTransactions()
        {
            //create a new instance of userViewModels
            CartViewModel _cartViewModel = new CartViewModel();

            // call the method and pass through the DAL to the mapper then pass to the user list
            _cartViewModel.listOfItemsPO = _mapper.Map(_cartDataAccess.ViewTransactions());

            // return the viewModel

            return View(_cartViewModel);


        }

    }
}
