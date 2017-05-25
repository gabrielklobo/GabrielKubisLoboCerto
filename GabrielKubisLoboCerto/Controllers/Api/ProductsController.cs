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
    public class ProductsController : ApiController
    {
        ProductService productService = new ProductService();

        // GET: api/Products
        public IQueryable<Product> Get()
        {
            return productService.getProductsByName();
        }

        // GET: api/Products/5
        public Product Get(int id)
        {
            return productService.getProductById(id);
        }

        // POST: api/Products
        public void Post([FromBody]Product value)
        {
            productService.InsertProduct(value);
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
            productService.InsertProduct(productService.getProductById(id));
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
            productService.deletProductById(id);
        }
    }
}
