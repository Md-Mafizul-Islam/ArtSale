using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project8MvcWithEntityFramework.DAL;
using Project8MvcWithEntityFramework.Models;

namespace Project8MvcWithEntityFramework.Controllers
{
    public class ArtsController : Controller
    {
        private CustomerContext db = new CustomerContext();
        public ActionResult Index()
        {
            return View(db.Arts.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Art art = db.Arts.Find(id);
            if (art == null)
            {
                return HttpNotFound();
            }
            return View(art);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtID,Arts")] Art art)
        {
            if (ModelState.IsValid)
            {
                db.Arts.Add(art);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(art);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Art art = db.Arts.Find(id);
            if (art == null)
            {
                return HttpNotFound();
            }
            return View(art);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtID,Arts")] Art art)
        {
            if (ModelState.IsValid)
            {
                db.Entry(art).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(art);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Art art = db.Arts.Find(id);
            if (art == null)
            {
                return HttpNotFound();
            }
            return View(art);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Art art = db.Arts.Find(id);
            db.Arts.Remove(art);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
