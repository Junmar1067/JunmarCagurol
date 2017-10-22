using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Entity;
using Project.Models;
using Project.Utils;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult HomeIndex()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account acc)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseEntities1 db = new DatabaseEntities1())
                {
                    var v = db.Accounts.Where(a => a.Username.Equals(acc.Username) && a.Password.Equals(acc.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedAccountId"] = v.AccountId.ToString();
                        Session["LogedName"] = v.Name.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View(acc);
        }

        public ActionResult AfterLogin(Account acc,string search)
        {
            using (var db = new DatabaseEntities1())
            {
                var current = db.Accounts.Where(a => a.AccountId.Equals(acc.AccountId)).FirstOrDefault();
                if (Session["LogedAccountId"] != null)
                {
                    if (Session["LogedName"].ToString() == "Admin")
                    {
                        return RedirectToAction("Home", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("HomeIndex", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
        }

        public ActionResult Logout()
        {
            return View("Login");
        }

        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult Add(Accounts acc)
        {

            if (acc.Name != null)
            {
                AccountsUtils.Save(acc);
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
    }
}
