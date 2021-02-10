using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Data;
using OnlineStore.DataModels;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using(StoreContext db = new StoreContext())
            {

                db.SaveChanges();
            }
            return View();
        }
    }
}