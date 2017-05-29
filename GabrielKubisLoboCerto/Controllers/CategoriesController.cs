using Models.Tables;
using Models.Registers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GabrielKubisLoboCerto.Controllers;
using System.Net;
using System.Data.Entity;
using Service.Tables;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using GabrielKubisLoboCerto.Models;

namespace GabrielKubisLoboCerto.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoryService categoryService = new CategoryService();



        private async Task<HttpResponseMessage> getFromAPI(long? id, Action<HttpResponseMessage> action)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = string.Format("{0}://{1}", HttpContext.Request.Url.Scheme, HttpContext.Request.Url.Authority);
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                var url = "Api/Categories";
                if (id != null)
                {
                    url = "Api/Categories/" + id;
                }

                var request = await client.GetAsync(url);
                if (action != null)
                {
                    action.Invoke(request);
                }
                return request;
            }
        }


        public async Task<ActionResult> IndexApi()
        {
            var apiModel = new CategoryListAPIModel();
            var resp = await getFromAPI(null, response =>
            {
                var result = response.Content.ReadAsStringAsync().Result;
                apiModel = JsonConvert.DeserializeObject<CategoryListAPIModel>(result);
            });

            return View(apiModel);
        }

        //GET:Category/Index
        public ActionResult Index()
        {

            return View(categoryService.getCategoriesByName());
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();

        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category Category)
        {

            return recordCategory(Category);

        }

        // GET: Category/Edit
        public ActionResult Edit(long? id)
        {

            PopularViewBag(categoryService.getCategorytById((long)id));
            return getViewByID(id);
        }

        // POST: Category/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category Category)
        {

            return recordCategory(Category);

        }

        // GET: Categorys/Details
        public ActionResult Details(long? id)
        {


            return getViewByID(id);
        }

        // GET: Categorys/Delete/5
        public ActionResult Delete(long? id)
        {

            return getViewByID(id);
        }


        // POST: Categorys/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Category Category = categoryService.deletCategoryById(id);
                TempData["Message"] = "Category	" + Category.Name.ToUpper() + "	removed";
                return RedirectToAction("Index");
            }
            catch { return View(); }
        }


        private ActionResult getViewByID(long? id)
        {
            if (id == null)
            { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
            Category Category = categoryService.getCategorytById((long)id);
            if (Category == null) { return HttpNotFound(); }
            return View(Category);
        }

        private void PopularViewBag(Category Category = null)
        {
            if (Category == null)
            {
                ViewBag.CategoryId = new SelectList(categoryService.getCategoriesByName(), "CategoryId", "Name");

            }
            else
            {
                ViewBag.CategoryId = new SelectList(categoryService.getCategoriesByName(), "CategoryId", "Name", Category.CategoryId);

            }
        }

        private ActionResult recordCategory(Category Category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoryService.InsertCategory(Category);
                    return RedirectToAction("Index");
                }
                return View(Category);
            }
            catch { return View(Category); }
        }
    }

}
