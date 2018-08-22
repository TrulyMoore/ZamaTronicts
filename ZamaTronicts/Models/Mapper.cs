using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Objects;
using BLL.Objects;

namespace ZamaTronicts.Models
{
    public class Mapper
    {
        // create the mappers for each object
        // create the mapper for a list of products
        //sdf
        public List<ProductPO> Map(List<ProductDAO> productListToMap)
        {
            // create a new instance of the list
            List<ProductPO> productListToReturn = new List<ProductPO>();

            // create a foreach loop to run through the whole list
            foreach (ProductDAO productToMap in productListToMap)
            {
                // create a new instance of productPO
                ProductPO productToView = new ProductPO();

                // get the values from each element
                productToView.productID = productToMap.productID;
                productToView.supplierID = productToMap.supplierID;
                productToView.supplierName = productToMap.supplierName;
                productToView.productDescription = productToMap.productDescription;
                productToView.productProcessor = productToMap.productProcessor;
                productToView.productOperatingSystem = productToMap.productOperatingSystem;
                productToView.productQuantity = productToMap.productQuantity;
                productToView.productRam = productToMap.productRam;
                productToView.productPrice = productToMap.productPrice;
              
                productListToReturn.Add(productToView);
            }
            // return the finally list of all products
            return productListToReturn;
        }


        // Create a mapper going from productPO to productDAO
        public ProductPO Map(ProductDAO productToMap)
        {
            // create a new instance of productPO to go from view to db
            ProductPO productToView = new ProductPO();

            // map the values 
            productToView.productID = productToMap.productID;
            productToView.supplierID = productToMap.supplierID;
            productToView.supplierName = productToMap.supplierName;
            productToView.productDescription = productToMap.productDescription;
            productToView.productProcessor = productToMap.productProcessor;
            productToView.productOperatingSystem = productToMap.productOperatingSystem;
            productToView.productQuantity = productToMap.productQuantity;
            productToView.productRam = productToMap.productRam;
            productToView.productPrice = productToMap.productPrice;
           

            // return the product
            return productToView;

        }

        // create a mapper to go from the db to the view
        public ProductDAO Map(ProductPO productToMap)
        {
            // create a new instance of productDAO to go from db to view
            ProductDAO productToView = new ProductDAO();

            // map the values 
            productToView.productID = productToMap.productID;
            productToView.supplierID = productToMap.supplierID;
            productToView.supplierName = productToMap.supplierName;
            productToView.productDescription = productToMap.productDescription;
            productToView.productProcessor = productToMap.productProcessor;
            productToView.productOperatingSystem = productToMap.productOperatingSystem;
            productToView.productQuantity = productToMap.productQuantity;
            productToView.productRam = productToMap.productRam;
            productToView.productPrice = productToMap.productPrice;
        

            // return the product
            return productToView;
        }

        // create a mapper to list all of the suppliers
        public List<SupplierPO> Map(List<SupplierDAO> supplierListToMap)
        {
            // create a new insatance of the supplierPO list
            List<SupplierPO> supplierListToReturn = new List<SupplierPO>();

            // create  a foreach loop to loop through the whole list
            foreach (SupplierDAO supplierToMap in supplierListToMap)
            {
                // create a new instance of supplierPO
                SupplierPO supplierToView = new SupplierPO();

                // map the values
                supplierToView.supplierID = supplierToMap.supplierID;
                supplierToView.supplierName = supplierToMap.supplierName;
                supplierToView.supplierAddress = supplierToMap.supplierAddress;
                supplierToView.supplierCity = supplierToMap.supplierCity;
                supplierToView.supplierState = supplierToMap.supplierState;
                supplierToView.supplierZip = supplierToMap.supplierZip;
                supplierToView.supplierPhoneNumber = supplierToMap.supplierPhoneNumber;
                supplierListToReturn.Add(supplierToView);
            }
            // return the list of suppliers
            return supplierListToReturn;
        }
        public List<SupplierDAO> Map(List<SupplierPO> supplierListToMap)
        {
            // create a new insatance of the supplierPO list
            List<SupplierDAO> supplierListToReturn = new List<SupplierDAO>();

            // create  a foreach loop to loop through the whole list
            foreach (SupplierPO supplierToMap in supplierListToMap)
            {
                // create a new instance of supplierPO
                SupplierDAO supplierToView = new SupplierDAO();

                // map the values
                supplierToView.supplierID = supplierToMap.supplierID;
                supplierToView.supplierName = supplierToMap.supplierName;
                supplierToView.supplierAddress = supplierToMap.supplierAddress;
                supplierToView.supplierCity = supplierToMap.supplierCity;
                supplierToView.supplierState = supplierToMap.supplierState;
                supplierToView.supplierZip = supplierToMap.supplierZip;
                supplierToView.supplierPhoneNumber = supplierToMap.supplierPhoneNumber;
                supplierListToReturn.Add(supplierToView);
            }
            // return the list of suppliers
            return supplierListToReturn;
        }


        // create a mapper method that goes from the db to view for the suppliers
        public SupplierDAO Map(SupplierPO supplierToMap)
        {
            // create a new instance ofsupplierDAO
            SupplierDAO supplierToView = new SupplierDAO();

            // map the values for the supplier
            supplierToView.supplierID = supplierToMap.supplierID;
            supplierToView.supplierName = supplierToMap.supplierName;
            supplierToView.supplierAddress = supplierToMap.supplierAddress;
            supplierToView.supplierCity = supplierToMap.supplierCity;
            supplierToView.supplierState = supplierToMap.supplierState;
            supplierToView.supplierZip = supplierToMap.supplierZip;
            supplierToView.supplierPhoneNumber = supplierToMap.supplierPhoneNumber;

            // return the supplier
            return supplierToView;
        }

        // create a mapper method that goes from the view to db for the suppliers
        public SupplierPO Map(SupplierDAO supplierToMap)
        {
            // create a new instance ofsupplierDAO
            SupplierPO supplierToView = new SupplierPO();

            // map the values for the supplier
            supplierToView.supplierID = supplierToMap.supplierID;
            supplierToView.supplierName = supplierToMap.supplierName;
            supplierToView.supplierAddress = supplierToMap.supplierAddress;
            supplierToView.supplierCity = supplierToMap.supplierCity;
            supplierToView.supplierState = supplierToMap.supplierState;
            supplierToView.supplierZip = supplierToMap.supplierZip;
            supplierToView.supplierPhoneNumber = supplierToMap.supplierPhoneNumber;

            // return the supplier
            return supplierToView;
        }

        // create a mapper method to map all of the users in a list
        public List<UserPO> Map(List<UserDAO> userListToMap)
        {
            // instaniate a new list of type userPO
            List<UserPO> userListToReturn = new List<UserPO>();

            // create a foreach loop to loop throught the list
            foreach (UserDAO userToMap in userListToMap)
            {
                // instaniate a new userPO
                UserPO userToView = new UserPO();

                // map the values
                userToView.accountInfoID = userToMap.accountInfoID;
                userToView.accountFirstName = userToMap.accountFirstName;
                userToView.accountLastName = userToMap.accountLastName;
                userToView.accountEmail = userToMap.accountEmail;
                userToView.accountPhoneNumber = userToMap.accountPhoneNumber;
                userToView.accountAddress = userToMap.accountAddress;
                userToView.accountCity = userToMap.accountCity;
                userToView.accountState = userToMap.accountState;
                userToView.accountZip = userToMap.accountZip;
                userToView.userTableID = userToMap.userTableID;
                userToView.userName = userToMap.userName;
                userToView.userPassword = userToMap.userPassword;
                userToView.roleName = userToMap.roleName;
                userToView.userRole = userToMap.userRole;
                userListToReturn.Add(userToView);
            }
            // return the whole list of users
            return userListToReturn;
        }

        // map the users from the veiw to the db
        public UserPO Map(UserDAO userToMap)
        {
            // instaniate a new instance of userPO
            UserPO userToView = new UserPO();

            // map the values
            userToView.accountInfoID = userToMap.accountInfoID;
            userToView.accountFirstName = userToMap.accountFirstName;
            userToView.accountLastName = userToMap.accountLastName;
            userToView.accountEmail = userToMap.accountEmail;
            userToView.accountPhoneNumber = userToMap.accountPhoneNumber;
            userToView.accountAddress = userToMap.accountAddress;
            userToView.accountCity = userToMap.accountCity;
            userToView.accountState = userToMap.accountState;
            userToView.accountZip = userToMap.accountZip;
            userToView.userTableID = userToMap.userTableID;
            userToView.userName = userToMap.userName;
            userToView.userPassword = userToMap.userPassword;
            userToView.roleName = userToMap.roleName;
            userToView.userRole = userToMap.userRole;

            // return the userToView
            return userToView;
        }

        // map the users from the db to the view
        public UserDAO Map(UserPO userToMap)
        {
            // instaniate a new instance of userPO
            UserDAO userToView = new UserDAO();

            // map the values
            userToView.accountInfoID = userToMap.accountInfoID;
            userToView.accountFirstName = userToMap.accountFirstName;
            userToView.accountLastName = userToMap.accountLastName;
            userToView.accountEmail = userToMap.accountEmail;
            userToView.accountPhoneNumber = userToMap.accountPhoneNumber;
            userToView.accountAddress = userToMap.accountAddress;
            userToView.accountCity = userToMap.accountCity;
            userToView.accountState = userToMap.accountState;
            userToView.accountZip = userToMap.accountZip;
            userToView.userTableID = userToMap.userTableID;
            userToView.userName = userToMap.userName;
            userToView.userPassword = userToMap.userPassword;
            userToView.userRole = userToMap.userRole;
            userToView.roleName = userToMap.roleName;
            

            // return the userToView
            return userToView;
        }

        public CartDAO Map(CartPO cartToMap)
        {
            // Create an instance of the object
            CartDAO cartToView = new CartDAO();

            // map the values
            cartToView.checkOutID = cartToMap.checkOutID;
            cartToView.supplierID = cartToMap.supplierID;
            cartToView.supplierName = cartToMap.supplierName;
            cartToView.productDescription = cartToMap.productDescription;
            cartToView.productPrice = cartToMap.productPrice;
            cartToView.checkOutQuantity = cartToMap.checkOutQuantity;
            cartToView.checkOutTax = cartToMap.checkOutTax;
            cartToView.checkOutShipping = cartToMap.checkOutShipping;
            cartToView.checkOutTotal = cartToMap.checkOutTotal;
            cartToView.checkOutDate = cartToMap.checkOutDate;
            cartToView.userTableID = cartToMap.userTableID;
            cartToView.productID = cartToMap.productID;
            cartToView.userTransactionID = cartToMap.userTransactionID;
            cartToView.datePurchase = cartToMap.datePurchase;
            cartToView.productQuantity = cartToMap.productQuantity;
            
            // return the values
            return cartToView;

        }

        public CartPO Map(CartDAO cartToMap)
        {
            // Create an instance of the object
            CartPO cartToView = new CartPO();

            // map the values
            cartToView.checkOutID = cartToMap.checkOutID;
            cartToView.supplierID = cartToMap.supplierID;
            cartToView.supplierName = cartToMap.supplierName;
            cartToView.productDescription = cartToMap.productDescription;
            cartToView.productPrice = cartToMap.productPrice;
            cartToView.checkOutQuantity = cartToMap.checkOutQuantity;
            cartToView.checkOutTax = cartToMap.checkOutTax;
            cartToView.checkOutShipping = cartToMap.checkOutShipping;
            cartToView.checkOutTotal = cartToMap.checkOutTotal;
            cartToView.checkOutDate = cartToMap.checkOutDate;
            cartToView.userTableID = cartToMap.userTableID;
            cartToView.productID = cartToMap.productID;
            cartToView.userTransactionID = cartToMap.userTransactionID;
            cartToView.datePurchase = cartToMap.datePurchase;
            cartToView.productQuantity = cartToMap.productQuantity;

            // return the values
            return cartToView;
        }

        public List<CartPO> Map(List<CartDAO> cartListToMap)
        {
            // instaniate a new list of type userPO
            List<CartPO> cartListToReturn = new List<CartPO>();

            // create a foreach loop to loop throught the list
            foreach (CartDAO cartToMap in cartListToMap)
            {
                CartPO cartToView = new CartPO();

                // map the values
                cartToView.checkOutID = cartToMap.checkOutID;
                cartToView.supplierID = cartToMap.supplierID;
                cartToView.supplierName = cartToMap.supplierName;
                cartToView.productDescription = cartToMap.productDescription;
                cartToView.productPrice = cartToMap.productPrice;
                cartToView.checkOutQuantity = cartToMap.checkOutQuantity;
                cartToView.checkOutTax = cartToMap.checkOutTax;
                cartToView.checkOutShipping = cartToMap.checkOutShipping;
                cartToView.checkOutTotal = cartToMap.checkOutTotal;
                cartToView.checkOutDate = cartToMap.checkOutDate;
                cartToView.userTableID = cartToMap.userTableID;
                cartToView.productID = cartToMap.productID;
                cartToView.userTransactionID = cartToMap.userTransactionID;
                cartToView.datePurchase = cartToMap.datePurchase;
                cartToView.productQuantity = cartToMap.productQuantity;
                cartListToReturn.Add(cartToView);

            }
            // return the list
            return cartListToReturn;
        }


        public CartBO GetProductInfo(CartPO infoToMap)
        {
            // return an instance of the object
            CartBO infoToView = new CartBO();

            // map the info
            infoToView.checkOutQuantity = infoToMap.checkOutQuantity;
            infoToView.checkOutTax = infoToMap.checkOutTax;
            infoToView.checkOutShipping = infoToMap.checkOutShipping;
            infoToView.checkOutTotal = infoToMap.checkOutTotal;

            // return the info
            return infoToView;
        }

        public List<CartBO> GetProductInfoList(List<CartPO> infoToMapList)
        {
            // create an instance of the object list
            List<CartBO> cartBOList = new List<CartBO>();

            // create a foreach loop to map through each object
            foreach(CartPO singleCartToMap in infoToMapList)
            {
                CartBO singleProductBO =  GetProductInfo(singleCartToMap);

                // add the info to the list
                cartBOList.Add(singleProductBO);
            }
            // return the list
            return cartBOList;

        }
        public List<CartDAO> Map(List<CartPO> cartListToMap)
        {
            // instaniate a new list of type userPO
            List<CartDAO> cartListToReturn = new List<CartDAO>();

            // create a foreach loop to loop throught the list
            foreach (CartPO cartToMap in cartListToMap)
            {
                CartDAO cartToView = new CartDAO();

                // map the values
                cartToView.checkOutID = cartToMap.checkOutID;
                cartToView.supplierID = cartToMap.supplierID;
                cartToView.supplierName = cartToMap.supplierName;
                cartToView.productDescription = cartToMap.productDescription;
                cartToView.productPrice = cartToMap.productPrice;
                cartToView.checkOutQuantity = cartToMap.checkOutQuantity;
                cartToView.checkOutTax = cartToMap.checkOutTax;
                cartToView.checkOutShipping = cartToMap.checkOutShipping;
                cartToView.checkOutTotal = cartToMap.checkOutTotal;
                cartToView.checkOutDate = cartToMap.checkOutDate;
                cartToView.userTableID = cartToMap.userTableID;
                cartToView.productID = cartToMap.productID;
                cartToView.userTransactionID = cartToMap.userTransactionID;
                cartToView.datePurchase = cartToMap.datePurchase;
                cartToView.productQuantity = cartToMap.productQuantity;
                cartListToReturn.Add(cartToView);

            }
            // return the list 
            return cartListToReturn;
        }

    }
}