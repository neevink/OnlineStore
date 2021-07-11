using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class AccountController : Controller
    {
        // Читай: https://metanit.com/sharp/mvc5/12.15.php


        // GET: Account
        public ActionResult LogIn()
        {
            return View();
        }
    }
}