﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using ZamaTronicts.Models;

namespace ZamaTronicts.Controllers
{
    public class ProductController : Controller
    {
        // instaniate a new instance of the mapper and productDataAccess
        static Mapper _mapper = new Mapper();
        static ProductDataAccess _productDataAccess = new ProductDataAccess();

        // create the get/post methods to create a product
        [HttpGet]
        public ActionResult CreateProduct()
        {
            // create a new instance of the viewModel
            ProductViewModel productViewModel = new ProductViewModel();

            // return the view and pass an instance of singleProduct
            return View(productViewModel.singleProductPO);
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductPO productToMap)
        {
            // pass the elements of the product to the map through the method call and then to the DAL
            _productDataAccess.AddProduct(_mapper.Map(productToMap));

            // return the user to the view product page
            return RedirectToAction("ViewProducts");
        }

        // create a post and get method to update products by passing the ID of that product
        [HttpGet]
        public ActionResult UpdateProduct(int productID)
        {
            // create a new instance of the productViewModel
            ProductViewModel _productViewModel = new ProductViewModel();

            // pass the product ID to the view method and pass to the product dataAccess 
            //through the mapper then to the single product
            _productViewModel.singleProductPO = _mapper.Map(_productDataAccess.ViewOneProduct(productID));

            // return the view with productview.singleproduct
            return View(_productViewModel.singleProductPO);
        }

        [HttpPost]
        public ActionResult UpdateProduct(ProductPO productToMap)
        {
            // pass the product through the mapper to the method and then to the DAL
            _productDataAccess.UpdateProduct(_mapper.Map(productToMap));

            // return the user to the list of products
            return RedirectToAction("ViewProducts");
        }

        // create a get to view all of the products
        [HttpGet]
        public ActionResult ViewProducts()
        {
            // create a new instance of productViewModel
            ProductViewModel _productViewModel = new ProductViewModel();
            _productViewModel.userTableID = (int)Session["userTableID"];
            // call the view products method pass it through the dataAccess and mapper
            // then set it to the product list
            _productViewModel.listProductPO = _mapper.Map(_productDataAccess.ViewAllProducts());
           
            // return the view
            return View(_productViewModel);
        }

        // create a method to delete a book
        [HttpGet]
        public ActionResult DeleteProduct(int productID)
        {
            // pass the id to the method then to the DAL
            _productDataAccess.DeleteProduct(productID);

            // return the view products page
            return RedirectToAction("ViewProducts");
        }
    }
}