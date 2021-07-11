using OnlineStore.Data;
using OnlineStore.DataModels;
using OnlineStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class CategoriesController : BaseController
    {
        private StoreContext db = new StoreContext();

        [HttpGet]
        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public ActionResult ProductsByCategory(int? categoryId)
        {
            if (categoryId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Where(x => x.Id == categoryId).First();
            if (category == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoryName = category.Name;
            var products = Mapper.Map<List<Product>, List<ProductViewModel>>(db.Products.Where(x => x.CategoryId == categoryId).ToList());
            return View(products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}