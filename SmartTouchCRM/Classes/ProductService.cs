using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTouchCRM.Classes
{

    class ProductService
    {
        private SmartTouchDatabseEntities _db = new SmartTouchDatabseEntities();

        public List<Products> GetList()
        {
            return _db.Products.ToList();
        }
    }
}
