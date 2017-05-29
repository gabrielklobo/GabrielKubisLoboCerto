using Models.Registers;
using Persistence.DAL.Registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Registers
{
  public  class SupplierService
    {
        private SupplierDAL supplierDAL = new SupplierDAL();
        public Supplier find(long id) { return supplierDAL.find(id); }
        public IQueryable<Supplier> getSuppliersByName() { return supplierDAL.getSuppliersbyName(); }
        public Supplier getSuppliertById(long id) { return supplierDAL.getSupplierById(id); }
        public void InsertSupplier(Supplier supplier) { supplierDAL.InsertSupplier(supplier); }
        public Supplier deletSupplierById(long id) { return supplierDAL.deletSupplierById(id); }
    }
}
