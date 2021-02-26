using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTouchCRM.Classes
{
    /// <summary>
    /// Product management service class
    /// </summary>
    public class ProductService
    {
        private readonly SmartTouchDatabseEntities _db = new SmartTouchDatabseEntities();
        /// <summary>
        /// Returns list of all products in database
        /// </summary>
        /// <returns>List of products</returns>
        public List<Products> GetList()
        {
            return _db.Products.ToList();
        }
        /// <summary>
        /// Create new product in database 
        /// </summary>
        /// <param name="productName">Product Name</param>
        /// <param name="productDescription">Product Description</param>
        /// <param name="productPrice">Product Price</param>
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
        /// <summary>
        /// Update product in database
        /// </summary>
        /// <param name="productId">ID of product to update</param>
        /// <param name="productName">New product name</param>
        /// <param name="productDescription">New product description</param>
        /// <param name="productPrice">New price</param>
        public void Update(int productId, string productName, string productDescription, decimal productPrice)
        {
            Products updateProduct = _db.Products.Where(x => x.product_id == productId).Single();

            updateProduct.product_id = productId;
            updateProduct.product_name = productName;
            updateProduct.product_description = productDescription;
            updateProduct.price = productPrice;
            
            _db.SaveChanges();
        }
        /// <summary>
        /// Removes product in database
        /// </summary>
        /// <param name="productId">ID of product to remove</param>
        /// <returns>Result of delete process</returns>
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
        
    }
}
