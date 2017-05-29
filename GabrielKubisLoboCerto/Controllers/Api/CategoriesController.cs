using GabrielKubisLoboCerto.Models;
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
        public CategoryListAPIModel Get()
        {
            var apiModel = new CategoryListAPIModel();

            try
            {
                apiModel.Result = categoryService.get();
            }
            catch (System.Exception)
            {
                apiModel.Message = "!OK";
            }
            return apiModel;
        }

        // GET: api/Categories/5
        public CategoryAPIModel Get(long? id)
        {
            var apiModel = new CategoryAPIModel();

            try
            {
                if (id == null)
                {
                    apiModel.Message = "!OK";
                }
                else
                {
                    // criar método no servico da categoria 
                    apiModel.Result = categoryService.getCategorytById(id);
                }

            }
            catch (System.Exception)
            {
                apiModel.Message = "!OK";
            }
            return apiModel;


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
