using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTouchCRM.Classes
{
    class CustomersService
    {
        private readonly SmartTouchDatabseEntities _db = new SmartTouchDatabseEntities();

        public List<Customers> GetList()
        {
            return _db.Customers.ToList();
        }

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

        public void Update(int customerId, string customerFirstname, string customerLastname, string customerTelephone, string customerMail)
        {
            Customers updateCustomer = _db.Customers.Where(x => x.customer_id == customerId).Single();

            updateCustomer.firstname = customerFirstname;
            updateCustomer.lastname = customerLastname;
            updateCustomer.telephone = customerTelephone;
            updateCustomer.mail = customerMail;

            //_db.Entry(updateCustomer).State = EntityState.Modified;
            _db.SaveChanges();

        }

        public void Remove(int customerId)
        {
            var deleteCustomer = _db.Customers.Where(x => x.customer_id == customerId).Single();
            _db.Customers.Remove(deleteCustomer);
            _db.SaveChanges();

        }

        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

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

