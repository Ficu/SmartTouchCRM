using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartTouchCRM;
using SmartTouchCRM.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartTouchCRM_Tests
{
    [TestClass]
    public class CustomerService_Tests
    {
        [TestMethod]
        public void AddCustomer()
        {
            CustomersService test = new CustomersService();

            Customers customerCheck = new Customers()
            {
                firstname = "Mariusz",
                lastname = "Stonoga",
                telephone = "725668916",
                mail = "dev@dev.pl"
            };
            test.Add(customerCheck.firstname, customerCheck.lastname, customerCheck.telephone, customerCheck.mail);

            List<Customers> listCustomers = test.GetList();

            Assert.AreEqual(customerCheck.firstname, listCustomers.Last().firstname);
            Assert.AreEqual(customerCheck.lastname, listCustomers.Last().lastname);
            Assert.AreEqual(customerCheck.telephone, listCustomers.Last().telephone);
            Assert.AreEqual(customerCheck.mail, listCustomers.Last().mail);
        }

        [TestMethod]
        public void UpdateCustomer()
        {
            CustomersService test = new CustomersService();

            Customers lastCustomer = test.GetList().Last();
            lastCustomer.firstname = "Magdalena";
            lastCustomer.lastname = "Konopka";
            lastCustomer.telephone = "789456123";
            lastCustomer.mail = "magdalena.konopka@test.pl";

            test.Update(lastCustomer.customer_id, lastCustomer.firstname, lastCustomer.lastname, lastCustomer.telephone, lastCustomer.mail);

            Customers updatedCustomer = test.GetList().Last();

            Assert.AreEqual(lastCustomer, updatedCustomer);
        }

        [TestMethod]
        public void RemoveCustomer()
        {
            CustomersService test = new CustomersService();
            Customers lastCustomerBefore = test.GetList().Last();

            Customers customerCheck = new Customers()
            {
                firstname = "Mariusz",
                lastname = "Stonoga",
                telephone = "725668916",
                mail = "dev@dev.pl"
            };
            test.Add(customerCheck.firstname, customerCheck.lastname, customerCheck.telephone, customerCheck.mail);
            int lastCustomerID = test.GetList().Last().customer_id;

            test.Remove(lastCustomerID);

            Customers lastCustomerAfter = test.GetList().Last();

            Assert.AreEqual(lastCustomerBefore, lastCustomerAfter);            
        }

        [TestMethod]
        public void DigitOnlyCheck()
        {
            CustomersService test = new CustomersService();


            Assert.IsTrue(test.IsDigitsOnly("123"));
            Assert.IsFalse(test.IsDigitsOnly("123ddd"));
        }

        [TestMethod]
        public void HasDigitCheck()
        {
            CustomersService test = new CustomersService();

            Assert.IsTrue(test.ItHasDigit("abc123"));
            Assert.IsFalse(test.ItHasDigit("abc"));
        }
    }
}
