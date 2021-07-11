using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Data;
using OnlineStore.DataModels;

namespace OnlineStore.Controllers
{
    //
    //
    // Читай это: https://www.smarly.net/pro-asp-net-mvc-4/introducing-asp-net-mvc-4/sportsstore-security-finishing-touches/image-uploads
    //
    //


    public class ProductsController : BaseController
    {
        private StoreContext db = new StoreContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.Include(m => m.Color).ToList());
        }

        // GET: Products/Details/id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Include(x => x.Color).Where(x => x.Id == id).First();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            SelectList list = new SelectList(db.Colors, "Id", "Name");
            ViewBag.ListOfColors = list;
            return View();
        }

        // POST: Products/Create
        // Обязательно прочитай позже про Атрибут ValidateAntiforgeryToken https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase image)
        {
            if(image == null)
            {
                ModelState.AddModelError("image", "Картинка обязательна");
                return View(product);
            }

            if (ModelState.IsValid)
            {
                return View(product);
            }
            byte[] imageData = null;
            // считываем переданный файл в массив байтов
            using (var binaryReader = new BinaryReader(image.InputStream))
            {
                imageData = binaryReader.ReadBytes(image.ContentLength);
            }
            // установка массива байтов
            product.MainImage = imageData;
            
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            SelectList list = new SelectList(db.Colors, "Id", "Name");
            ViewBag.ListOfColors = list;

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, HttpPostedFileBase image)
        {            
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            if (image != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(image.InputStream))
                {
                    imageData = binaryReader.ReadBytes(image.ContentLength);
                }
                // установка массива байтов
                product.MainImage = imageData;
            }
            else
            {
                product.MainImage = db.Products.AsNoTracking().Where(x => x.Id == product.Id).First().MainImage;
            }

            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
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
