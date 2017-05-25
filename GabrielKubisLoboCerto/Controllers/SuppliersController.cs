using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Models.Tables;
using Models.Registers;
using System.Net;
using System.Data.Entity;
using Service.Registers;
using Service.Tables;

namespace GabrielKubisLoboCerto.Controllers
{
    public class SuppliersController : Controller

    {
        private SupplierService SupplierService = new SupplierService();
        private CategoryService categoryService = new CategoryService();


        //	GET:Supplier/Index
        public ActionResult Index()
        {

            return View(SupplierService.getSuppliersByName());
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();

        }

        // POST: Supplier/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier Supplier)
        {

            return recordSupplier(Supplier);

        }

        // GET: Supplier/Edit
        public ActionResult Edit(long? id)
        {

            PopularViewBag(SupplierService.getSuppliertById((long)id));
            return getViewByID(id);
        }

        // POST: Supplier/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier Supplier)
        {

            return recordSupplier(Supplier);

        }

        // GET: Suppliers/Details
        public ActionResult Details(long? id)
        {


            return getViewByID(id);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(long? id)
        {

            return getViewByID(id);
        }


        // POST: Suppliers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Supplier Supplier = SupplierService.deletSupplierById(id);
                TempData["Message"] = "Supplier	" + Supplier.Name.ToUpper() + "	removed";
                return RedirectToAction("Index");
            }
            catch { return View(); }
        }


        private ActionResult getViewByID(long? id)
        {
            if (id == null)
            { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
            Supplier Supplier = SupplierService.getSuppliertById((long)id);
            if (Supplier == null) { return HttpNotFound(); }
            return View(Supplier);
        }

        private void PopularViewBag(Supplier Supplier = null)
        {
            if (Supplier == null)
            {
                ViewBag.CategoryId = new SelectList(categoryService.getCategoriesByName(), "CategoryId", "Name");
                ViewBag.SupplierId = new SelectList(SupplierService.getSuppliersByName(), "SupplierId", "Name");

            }
            else
            {
                ViewBag.CategoryId = new SelectList(categoryService.getCategoriesByName(), "CategoryId", "Name");
                ViewBag.SupplierId = new SelectList(SupplierService.getSuppliersByName(), "SupplierId", "Name", Supplier.SupplierId);

            }
        }

        private ActionResult recordSupplier(Supplier Supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SupplierService.InsertSupplier(Supplier);
                    return RedirectToAction("Index");
                }
                return View(Supplier);
            }
            catch { return View(Supplier); }
        }

    }
}