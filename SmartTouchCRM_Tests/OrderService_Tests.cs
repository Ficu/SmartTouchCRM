using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartTouchCRM;
using SmartTouchCRM.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartTouchCRM_Tests
{
    [TestClass]
    public class OrderService_Tests
    {
        [TestMethod]
        public void AddOrder()
        {
            OrderService order = new OrderService();
            CustomersService customer = new CustomersService();
            ProductService product = new ProductService();

            Customers lastCustomer = customer.GetList().Last();
            Products lastProduct = product.GetList().Last();

            List<Products> productsList = new List<Products>
            {
                lastProduct
            };
            int exceptedID = order.GetOrders().Last().order_id + 1;
            order.AddOrder(lastCustomer.customer_id, productsList);
            int actualID = order.GetOrders().Last().order_id;

            Assert.AreEqual(exceptedID, actualID);
        }

        [TestMethod]
        public void RemoveOrder()
        {
            OrderService order = new OrderService();

            List<Orders> beforeRemove = order.GetOrders();

            order.Remove(beforeRemove.Last().order_id);

            List<Orders> afterRemove = order.GetOrders();

            Assert.AreNotEqual(beforeRemove, afterRemove);
        }
    }
}
