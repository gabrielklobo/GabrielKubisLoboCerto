using Models.Registers;
using Service.Registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GabrielKubisLoboCerto.Controllers.Api
{
    public class SuppliersController : ApiController
    {

        SupplierService supplierService = new SupplierService(); 
        // GET: api/Suppliers
        public IQueryable<Supplier> Get()
        {
            return supplierService.getSuppliersByName();
        }

        // GET: api/Suppliers/5
        public Supplier Get(int id)
        {
            return supplierService.getSuppliertById(id);
        }

        // POST: api/Suppliers
        public void Post([FromBody]Supplier value)
        {
            supplierService.InsertSupplier(value);
        }

        // PUT: api/Suppliers/5
        public void Put(int id, [FromBody]Supplier value)
        {
            supplierService.InsertSupplier(supplierService.getSuppliertById(id));
        }

        // DELETE: api/Suppliers/5
        public void Delete(int id)
        {
            supplierService.deletSupplierById(id);
        }
    }
}
