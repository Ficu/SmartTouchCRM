using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTouchCRM.Classes
{
    /// <summary>
    /// Customer management service class
    /// </summary>
    public class CustomersService
    {
        private readonly SmartTouchDatabseEntities _db = new SmartTouchDatabseEntities();
        /// <summary>
        /// Returns List of Customers
        /// </summary>
        /// <returns>List of Customers in database</returns>

        public List<Customers> GetList()
        {
            return _db.Customers.ToList();
        }
        /// <summary>
        /// Create new Customer in database
        /// </summary>
        /// <param name="customerFirstname">Customer Firstname</param>
        /// <param name="customerLastname">Customer Lastname</param>
        /// <param name="customerTelephone">Customer phone numberm, less than 9 numbers</param>
        /// <param name="customerMail">Customer email adress</param>
        public void Add(string customerFirstname, string customerLastname, string customerTelephone, string customerMail)
        {
            Customers customer = new Customers()
            {
                firstname = customerFirstname,
                lastname = customerLastname,
                telephone = customerTelephone,
                mail = customerMail
            };

            _db.Customers.Add(customer);
            _db.SaveChanges();

        }
        /// <summary>
        /// Update selected customer in database
        /// </summary>
        /// <param name="customerId">ID of customer</param>
        /// <param name="customerFirstname">Customer Firstname</param>
        /// <param name="customerLastname">Customer Lastname</param>
        /// <param name="customerTelephone">Customer phone numberm, less than 9 numbers</param>
        /// <param name="customerMail">Customer email adress</param>
        public void Update(int customerId, string customerFirstname, string customerLastname, string customerTelephone, string customerMail)
        {
            Customers updateCustomer = _db.Customers.Where(x => x.customer_id == customerId).Single();

            updateCustomer.firstname = customerFirstname;
            updateCustomer.lastname = customerLastname;
            updateCustomer.telephone = customerTelephone;
            updateCustomer.mail = customerMail;

            _db.SaveChanges();

        }
        /// <summary>
        /// Remove selected Customer in database
        /// </summary>
        /// <param name="customerId">ID of customer to remove</param>
        public void Remove(int customerId)
        {
            var deleteCustomer = _db.Customers.Where(x => x.customer_id == customerId).Single();
            _db.Customers.Remove(deleteCustomer);
            _db.SaveChanges();

        }
        /// <summary>
        /// Check that string contains only digits
        /// </summary>
        /// <param name="str">String to check</param>
        /// <returns>Information that given string has only digits or not</returns>
        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Check that string contains any digit
        /// </summary>
        /// <param name="str">String to check</param>
        /// <returns>Information that given string contains digits</returns>
        public bool ItHasDigit(string str)
        {
            foreach (char c in str)
            {
                if (Char.IsDigit(c))
                    return true;
            }
            return false;
        }
    }
}

