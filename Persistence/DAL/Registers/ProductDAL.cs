
using Models.Registers;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DAL.Registers
{
    public class ProductDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Product> getProductsByName() { return context.Products.Include(c => c.Category).Include(f => f.Supplier).OrderBy(n => n.Name); }
        public Product getProductById(long id) { return context.Products.Where(p => p.ProductId == id).Include(c => c.Category).Include(f => f.Supplier).First(); }
        public void InsertProduct(Product product) { if (product.ProductId == null) { context.Products.Add(product); } else { context.Entry(product).State = EntityState.Modified; } context.SaveChanges(); }
        public Product deletProductById(long id) { Product product = getProductById(id); context.Products.Remove(product); context.SaveChanges(); return product; }
    }
}
