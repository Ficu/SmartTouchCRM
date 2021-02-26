using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartTouchCRM;
using SmartTouchCRM.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartTouchCRM_Tests
{
    [TestClass]
    public class ProductService_Tests
    {
        [TestMethod]
        public void AddProduct()
        {
            ProductService product = new ProductService();

            Products productCheck = new Products()
            {
                product_name = "Testowy produkt",
                product_description = "Testowy opis",
                price = 20
            };

            product.Add(productCheck.product_name, productCheck.product_description, productCheck.price);

            Products lastProduct = product.GetList().Last();

            Assert.AreEqual(productCheck.product_name, lastProduct.product_name);
            Assert.AreEqual(productCheck.product_description, lastProduct.product_description);
            Assert.AreEqual(productCheck.price, lastProduct.price);
        }

        [TestMethod]
        public void UpdateProduct()
        {
            ProductService product = new ProductService();

            Products productUpdate = product.GetList().Last();

            productUpdate.product_name = "Nowa nazwa";
            productUpdate.product_description = "Nowy opis";
            productUpdate.price = 10;

            product.Update(productUpdate.product_id, productUpdate.product_name, productUpdate.product_description, productUpdate.price);

            Products productAfterUpdate = product.GetList().Last();

            Assert.AreEqual(productUpdate, productAfterUpdate);
        }

        [TestMethod]
        public void RemoveProduct()
        {
            ProductService product = new ProductService();

            Products lastProductBefore = product.GetList().Last();
            Products productCheck = new Products()
            {
                product_name = "Testowy produkt",
                product_description = "Testowy opis",
                price = 20
            };

            product.Add(productCheck.product_name, productCheck.product_description, productCheck.price);
            int lastProductID = product.GetList().Last().product_id;

            product.Remove(lastProductID);

            Products lastProductAfter = product.GetList().Last();

            Assert.AreEqual(lastProductBefore, lastProductAfter);
        }

        [TestMethod]
        public void RemoveProductFalse()
        {
            ProductService product = new ProductService();

            Assert.IsFalse(product.Remove(1));
        }
    }
    
}
