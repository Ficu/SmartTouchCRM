﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTouchCRM.Classes
{

    class OrderService
    {
        private readonly SmartTouchDatabseEntities _db = new SmartTouchDatabseEntities();

        public List<Orders_Products> GetProducts(int orderid)
        {
            return _db.Orders_Products.Include("Orders").Include("Products").Where(x => x.order_id == orderid).ToList();
        }

        public void AddOrder(int customerID, List<Products> products)
        {
            int nextID = _db.Orders.Max(x => x.order_id);
            nextID += 1;
            decimal orderValue = 0;
            

            List<Orders_Products> orderproduct = new List<Orders_Products>();

            foreach(Products product in products)
            {
                orderproduct.Add(new Orders_Products() { order_id = nextID, product_id = product.product_id });
                orderValue += product.price;
            }

            Orders newOrder = new Orders()
            {
                customer_id = customerID,
                order_date = DateTime.Now,
                order_value = orderValue
            };

            _db.Orders.Add(newOrder);
            _db.Orders_Products.AddRange(orderproduct);

            _db.SaveChanges();

        }


        public void Remove(int orderID)
        {
            var toRemove = _db.Orders.Where(x => x.order_id == orderID).Single();
            _db.Orders.Remove(toRemove);

            _db.Orders_Products.RemoveRange(_db.Orders_Products.Where(x => x.order_id == orderID));

            _db.SaveChanges();
            
        }
	}
}