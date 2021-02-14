using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Data;
using OnlineStore.DataModels;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();

        [HttpGet]
        public ActionResult Index()
        {
            // Тут сервис добавь, чтобы отсюда дёргался сервис, а не контроллер в бд лазил
            var res = Mapper.Map(db.Products.ToList());

            return View(res);
        }

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = db.Products.Find(id);
            if(product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

    }
}