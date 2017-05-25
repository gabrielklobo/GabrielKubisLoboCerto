using Models.Tables;
using Service.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace GabrielKubisLoboCerto.Controllers.Api
{
    public class CategoriesController : ApiController
    {

        CategoryService categoryService = new CategoryService();

        // GET: api/Categories
        public IQueryable<Category> Get()
        {
            return categoryService.getCategoriesByName();
        }

        // GET: api/Categories/5
        public Category Get(int id)
        {
            return categoryService.getCategorytById(id); ;
        }

        // POST: api/Categories
        public void Post([FromBody]Category value)
        {
            categoryService.InsertCategory(value);
        }

        // PUT: api/Categories/5
        public void Put(int id, [FromBody]string value)
        {
            categoryService.InsertCategory(categoryService.getCategorytById(id));
        }

        // DELETE: api/Categories/5
        public void Delete(int id)
        {
            categoryService.deletCategoryById(id);
        }
    }
}
