using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTouchCRM.Classes
{

    public class ProductService
    {
        private readonly SmartTouchDatabseEntities _db = new SmartTouchDatabseEntities();

        public List<Products> GetList()
        {
            return _db.Products.ToList();
        }

        public void Add(string productName, string productDescription, decimal productPrice) {
            Products product = new Products()
            {
                product_name = productName,
                product_description = productDescription,
                price = productPrice
            };          

            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void Update(int productId, string productName, string productDescription, decimal productPrice)
        {
            Products updateProduct = _db.Products.Where(x => x.product_id == productId).Single();

            updateProduct.product_id = productId;
            updateProduct.product_name = productName;
            updateProduct.product_description = productDescription;
            updateProduct.price = productPrice;
            
            _db.SaveChanges();
        }

        public bool Remove(int productId)
        {
            
            int liczba = _db.Orders_Products.Where(x => x.product_id == productId).Count();
            if (liczba > 0)
            {
                return false;
            } else
            {
                var deleteProduct = _db.Products.Where(x => x.product_id == productId).Single();
                _db.Products.Remove(deleteProduct);
                _db.SaveChanges();
                return true;
            }          

        }

        public Products Search(string inputString)
        {
            return (Products)_db.Products.Where(x => x.product_name.StartsWith(inputString));
        }
    }
}
