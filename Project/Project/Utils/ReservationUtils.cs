using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Entity;
using Project.Models;

namespace Project.Utils
{
    public class ReservationUtils
    {

        public static List<Reservations> GetReservations(int id)
        {
            using (var db = new DatabaseEntities1())
            {

                if (id != 0)
                {
                    var a = db.Reservations.Where(i => i.ReservationId == id);
                    return a.Select(b => new Reservations { Id = b.ReservationId, accID = b.AccountId, bbID = b.BookId, ReserveDate = b.ReservationDate, Qty = b.Quantity, BorrowersName = b.BorrowersName, BookTitle = b.BookTitle }).ToList();
                }
                else
                {
                    return db.Reservations.Select(b => new Reservations { Id = b.ReservationId, accID = b.AccountId, bbID = b.BookId, ReserveDate = b.ReservationDate, Qty = b.Quantity, BorrowersName = b.BorrowersName, BookTitle = b.BookTitle }).ToList();
                }
            }
        }

        public static void CancelConfirm(int id)
        {
            using (var db = new DatabaseEntities1())
            {
                var selected = db.Reservations.FirstOrDefault(x => x.ReservationId == id);
                if (selected != null)
                {
                    db.Reservations.Remove(selected);
                    db.SaveChanges();
                }
            }
        }
    }
}