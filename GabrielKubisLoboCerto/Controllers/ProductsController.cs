
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Models.Tables;
using Models.Registers;
using System.Net;
using Service.Registers;
using Service.Tables;

namespace GabrielKubisLoboCerto.Controllers
{
    public class ProductsController : Controller
    {
        private ProductService productService = new ProductService();
        private CategoryService categoryService = new CategoryService();
        private SupplierService supplierService = new SupplierService();

        //	GET:Product/Index
        public ActionResult Index()
        {

            return View(productService.getProductsByName());
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();

        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {

            return recordProduct(product);

        }

        // GET: Product/Edit
        public ActionResult Edit(long? id)
        {

            PopularViewBag(productService.getProductById((long)id));
            return getViewByID(id);
        }

        // POST: Product/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {

            return recordProduct(product);

        }

        // GET: Products/Details
        public ActionResult Details(long? id)
        {


            return getViewByID(id);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(long? id)
        {

            return getViewByID(id);
        }


        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Product Product = productService.deletProductById(id);
                TempData["Message"] = "Product	" + Product.Name.ToUpper() + "	removed";
                return RedirectToAction("Index");
            }
            catch { return View(); }
        }

        private ActionResult getViewByID(long? id)
        {
            if (id == null)
            { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
            Product product = productService.getProductById((long)id);
            if (product == null) { return HttpNotFound(); }
            return View(product);
        }

        private void PopularViewBag(Product product = null)
        {
            if (product == null)
            {
                ViewBag.CategoryId = new SelectList(categoryService.getCategoriesByName(), "CategoryId", "Name");
                ViewBag.SupplierId = new SelectList(supplierService.getSuppliersByName(), "SupplierId", "Name");
            }
            else
            {
                ViewBag.CategoryId = new SelectList(categoryService.getCategoriesByName(), "CategoryId", "Name", product.CategoryId);
                ViewBag.SupplierId = new SelectList(supplierService.getSuppliersByName(), "SupplierId", "Name", product.SupplierId);
            }
        }


        private ActionResult recordProduct(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productService.InsertProduct(product);
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch { return View(product); }
        }
    }
}