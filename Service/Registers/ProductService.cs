using Models.Registers;
using Persistence.DAL.Registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Registers
{
    public class ProductService
    {
        private ProductDAL productDAL = new ProductDAL();
        public IQueryable<Product> getProductsByName(){ return productDAL.getProductsByName(); }
        public Product getProductById(long id) { return productDAL.getProductById(id); }
        public void InsertProduct(Product product) { productDAL.InsertProduct(product); }
        public Product deletProductById(long id) { return productDAL.deletProductById(id); }

    }
}
