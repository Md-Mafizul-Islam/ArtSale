using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Project8MvcWithEntityFramework.DAL;
using Project8MvcWithEntityFramework.Models;

namespace Project8MvcWithEntityFramework.Controllers
{
    public class AccountController : Controller
    {
       
        CustomerContext db = new CustomerContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
       public ActionResult Login(User obj)
        {
            var count = db.Users.Where(x => x.UserName == obj.UserName && x.Password == obj.Password).Count();
            if (count <= 0)
            {
                ViewBag.msg = "Not Valid User";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(obj.UserName, false);
                return RedirectToAction("Index", "Home");
            }
           

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Create()
        {
            User us = new User();
         

            return View(us);
        }
        [HttpPost]
        public ActionResult Create(User usr)
        {
            User us = new User();
            us.UserName = usr.UserName;
            us.Password = usr.Password;
            us.Role = usr.Role;
            db.Users.Add(us);
            db.SaveChanges();
            return View(usr);
        }
    }
}