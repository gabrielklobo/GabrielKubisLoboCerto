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
   public class SupplierDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Supplier> getSuppliersbyName() { return context.Suppliers.OrderBy(b => b.Name); }
        public Supplier getSupplierById(long id) { return context.Suppliers.Where(p => p.SupplierId == id).First(); }
        public void InsertSupplier(Supplier supplier) { if (supplier.SupplierId == null) { context.Suppliers.Add(supplier); } else { context.Entry(supplier).State = EntityState.Modified; } context.SaveChanges(); }
        public Supplier deletSupplierById(long id) { Supplier supplier = getSupplierById(id); context.Suppliers.Remove(supplier); context.SaveChanges(); return supplier; }
    }
}
