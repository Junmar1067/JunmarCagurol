using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Project.Entity;
using Project.Utils;

namespace Project.Controllers
{
    public class BookController : Controller
    {
        //
        // GET: /Book/

        public ActionResult Index(string search = "", string id = "")
        {
            if (search != "")
            {
                return View(BooksUtils.GetBooks(0).Where(x => x.BookTitle == search || x.BookAuthor == search));
            }
            return View(BooksUtils.GetBooks(0));
        }

        public ActionResult UserBookIndex(string search = "", string id = "")
        {
            if (search != "")
            {
                return View(BooksUtils.GetBooks(0).Where(x => x.BookTitle == search || x.BookAuthor == search));
            }
            return View(BooksUtils.GetBooks(0));
        }

        public ActionResult Add(Books book)
        {
            if (book.BookTitle != null)
            {
                BooksUtils.Save(book);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(Books book)
        {
            return View(BooksUtils.GetBooks(book.Id).FirstOrDefault());
        }

        public ActionResult Delete(int id)
        {
            BooksUtils.DeleteConfirm(id);
            return RedirectToAction("Index");
        }
    }
}
