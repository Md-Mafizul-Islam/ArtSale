using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using Project8MvcWithEntityFramework.DAL;
using Project8MvcWithEntityFramework.Models;
using Project8MvcWithEntityFramework.ViewModel;

namespace Project8MvcWithEntityFramework.Controllers
{
    public class CustomersController : Controller
    {
        private CustomerContext db = new CustomerContext();

        public ActionResult Index(string Searching,string currentFilter, string SortOrder, int?page)
        {
            ViewBag.NameSortParam = string.IsNullOrEmpty(SortOrder) ? "name_desc" : "";
            
            if (Searching != null)
            {
                page = 1;

            }
            else

            {
                Searching=currentFilter;
            }
           
            ViewBag.CurrentFilter = Searching;
            var customers = from s in  db.Customers.Include(c => c.Art).Include(c => c.Artist) select s;
            if (!string.IsNullOrEmpty(Searching))
            {
                customers = customers.Where(d => d.CustomerName.ToUpper().Contains(Searching.ToUpper()));
            }
            switch (SortOrder)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(s => s.CustomerName);
                    break;
                    
                default:
                    customers = customers.OrderBy(s => s.CustomerName);
                    break;
            };
            int pageSize = 3;int pageNumber = (page ?? 1);
            return View(customers.ToPagedList(pageNumber,pageSize));
        }

        public ActionResult Details(int id)
        {
            try
            {
                Customer customer = db.Customers.First(m => m.ID == id);
                return View(customer);
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
           
        }

        
        public ActionResult Create()
        {
            CustomerVM cvm = new CustomerVM();
            cvm.Art = db.Arts.ToList();
            cvm.Artist = db.Artists.ToList();
            
            return View(cvm);
        }
        [HttpPost]
        public ActionResult Create( CustomerVM cvm)
        {
            if (ModelState.IsValid)
            {
                Customer ct = new Customer();
                ct.ArtID = cvm.ArtID;
                ct.ArtistID = cvm.ArtistID;
                ct.CustomerName = cvm.CustomerName;
                ct.CustomerType = cvm.CustomerType;
                ct.Price = cvm.Price;
                db.Customers.Add(ct);
                db.SaveChanges();
              
                return RedirectToAction("Index");
            }
            return View(cvm);
        }

        public PartialViewResult Edit(int id)
        {
          
            Customer customer = db.Customers.Find(id);
            ViewBag.Art = db.Arts.ToList();
            ViewBag.Artist = db.Artists.ToList();
            return PartialView("_EditPartial", customer);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return PartialView(customer);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.FirstOrDefault(s=>s.ID==id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.FirstOrDefault(s => s.ID == id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
