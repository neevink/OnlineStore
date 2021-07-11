using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Data;
using OnlineStore.DataModels;
using System.Data.Entity;

using OnlineStore.ViewModels;

namespace OnlineStore.Controllers
{
    public class HomeController : BaseController
    {
        private StoreContext db = new StoreContext();

        [HttpGet]
        public ActionResult Index()
        {
            var res = Mapper.Map<List<Product>, List<ProductViewModel>>(db.Products.ToList());

            return View(res);
        }

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = db.Products.Include(x => x.Color).Where(x => x.Id == id).First();
            if(product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        [HttpGet]
        public ActionResult Categories()
        {


            return View();
        }
    }
}