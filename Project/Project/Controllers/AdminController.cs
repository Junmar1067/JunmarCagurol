using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Entity;
using Project.Models;
using System.Net;
using Project.Utils;

namespace Project.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index(string search = "", string id = "")
        {

            if (search != "")
            {
                return View(AccountsUtils.GetAccounts(0).Where(a => a.Name == search || a.Username ==search));
            }

            return View(AccountsUtils.GetAccounts(0));
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Add(Accounts acc)
        {

            if (acc.Name != null)
            {
                AccountsUtils.Save(acc);
                return RedirectToAction("Index");
            }
            return View();
        }  

        public ActionResult Delete(int id)
        {
            AccountsUtils.DeleteConfirm(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Accounts acc)
        {
            return View(AccountsUtils.GetAccounts(acc.Id).FirstOrDefault());
        }

    }
}
