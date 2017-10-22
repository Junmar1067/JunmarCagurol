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
    public class ReservationController : Controller
    {
        //
        // GET: /Reservation/

        public ActionResult Index(string search = "", string id = "")
        {

            if (search != "")
            {
                return View(ReservationUtils.GetReservations(0).Where(a => a.BorrowersName == search || a.BookTitle == search));
            }

            return View(ReservationUtils.GetReservations(0));
        }

        public ActionResult UserIndex(Accounts acc)
        {
            int Id = Convert.ToInt32(Session["LogedAccountId"]);
            Information info = new Information();
            using (var db = new DatabaseEntities1())
            {
                var allAccount = db.Accounts.FirstOrDefault(a => a.AccountId == Id);
                var allBook = db.Books.ToList();
                var allResrv = db.Reservations.Where(br => br.AccountId == Id).ToList();
                info.Account.Add(allAccount);
                info.Book.AddRange(allBook);

                info.BookReservation.AddRange(allResrv.Select(b =>
                    new Reservation
                    {
                        ReservationId = b.ReservationId,
                        AccountId = b.AccountId,
                        BookTitle = allBook.FirstOrDefault(book => book.BookId == b.BookId).Title,
                        BorrowersName = db.Accounts.FirstOrDefault(account => account.AccountId == b.AccountId).Name,
                        Quantity = (int)b.Quantity
                    }));
            }
            return View(info);
        }

        //public ActionResult User()
        //{
        //    return View();
        //}

        public ActionResult Reserve(int AccountId, int BookId, int Qty, DateTime date, string name, string title)
        {
            using (var db = new DatabaseEntities1())
            {
                var selected = db.Accounts.FirstOrDefault(x => x.AccountId == AccountId);
                db.Reservations.Add(new Reservation { AccountId = selected.AccountId, BookId = BookId, Quantity = Qty, ReservationDate = date, BorrowersName = name, BookTitle = title });
                db.SaveChanges();
            }
            return RedirectToAction("UserIndex", new { id = AccountId });
        }

        public ActionResult MyReservation()
        {
            string search=Session["LogedName"].ToString();
            if (search != "")
            {
                return View(ReservationUtils.GetReservations(0).Where(a => a.BorrowersName == search));
            }

            return View(ReservationUtils.GetReservations(0));
        }

        public ActionResult DeleteAll()
        {
            using (var db = new DatabaseEntities1())
            {

                foreach (var ent in db.Reservations)
                {
                    db.Reservations.Remove(ent);
                }

                db.SaveChanges();
            }

            return RedirectToAction("UserIndex");
        }

        public ActionResult Cancel(int id)
        {
            ReservationUtils.CancelConfirm(id);
            return RedirectToAction("UserIndex");
        }

        public ActionResult AdminDelete(int id)
        {
            ReservationUtils.CancelConfirm(id);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            ReservationUtils.CancelConfirm(id);
            return RedirectToAction("MyReservation");
        }
    }
}
