using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using ZamaTronicts.Models;

namespace ZamaTronicts.Controllers
{
    public class SupplierController : Controller
    {
        // instaniate a new instance of the mapper and supplierDataAccess
        static Mapper _mapper = new Mapper();
        static SupplierDataAccess _supplierDataAccess = new SupplierDataAccess();

        // create the get/post methods to create a supplier
        [HttpGet]
        public ActionResult CreateSupplier()
        {
            if ((string)Session["roleName"] == "admin" || (string)Session["roleName"] == "moderator")
            {
                // create a new instance of the viewModel
                SupplierViewModel supplierViewModel = new SupplierViewModel();

                // return the view and pass an instance of singleSupplier
                return View(supplierViewModel.singleSupplierPO);
            }
            return RedirectToAction("ViewProducts");
        }

        [HttpPost]
        public ActionResult CreateSupplier(SupplierPO supplierToMap)
        {
            // pass the elements of the supplier to the map through the method call and then to the DAL
            _supplierDataAccess.AddSupplier(_mapper.Map(supplierToMap));

            // return the user to the view supplier page
            return RedirectToAction("ViewSuppliers");
        }

        // create a post and get method to update supplier by passing the ID of that supplier
        [HttpGet]
        public ActionResult UpdateSupplier(int supplierID)
        {
            if ((string)Session["roleName"] == "admin" || (string)Session["roleName"] == "moderator")
            {
                // create a new instance of the productViewModel
                SupplierViewModel _supplierViewModel = new SupplierViewModel();

                // pass the supplier ID to the view method and pass to the product dataAccess 
                //through the mapper then to the single supplier
                _supplierViewModel.singleSupplierPO = _mapper.Map(_supplierDataAccess.ViewOneSupplier(supplierID));

                // return the view with supplierview.singleproduct
                return View(_supplierViewModel.singleSupplierPO);
            }
            return RedirectToAction("ViewProducts");
        }

        [HttpPost]
        public ActionResult UpdateSupplier(SupplierPO supplierToMap)
        {
            // pass the supplier through the mapper to the method and then to the DAL
            _supplierDataAccess.UpdateSupplier(_mapper.Map(supplierToMap));

            // return the user to the list of suppliers
            return RedirectToAction("ViewSuppliers");
        }

        // create a get to view all of the suppliers
        [HttpGet]
        public ActionResult ViewSuppliers()
        {
            if ((string)Session["roleName"] == "admin" || (string)Session["roleName"] == "moderator")
            {
                // create a new instance of supplerViewModel
                SupplierViewModel _supplierViewModel = new SupplierViewModel();

                // call the view suppliers method pass it through the dataAccess and mapper
                // then set it to the supplier list
                _supplierViewModel.listSupplierPO = _mapper.Map(_supplierDataAccess.ViewAllSuppliers());

                // return the view
                return View(_supplierViewModel);
            }
            return RedirectToAction("ViewProducts");
        }

        // create a method to delete a book
        [HttpGet]
        public ActionResult DeleteSupplier(int supplierID)
        {
            if ((string)Session["roleName"] == "admin")
            {
                // pass the id to the method then to the DAL
                _supplierDataAccess.DeleteSupplier(supplierID);
            }
            // return the view suppler page
            return RedirectToAction("ViewSuppliers");
        }
    }
}