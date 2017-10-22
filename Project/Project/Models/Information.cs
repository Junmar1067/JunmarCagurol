using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Entity;

namespace Project.Models
{
    public class Information
    {
        public List<Account> Account { get; set; }
        public List<Book> Book { get; set; }
        public List<Reservation> BookReservation { get; set; }
        //public List<BookReservationInfo> BookReservationInfo { get; set; }

        public Information()
        {
            Account = new List<Account>();
            Book = new List<Book>();
            BookReservation = new List<Reservation>();
            //BookReservationInfo = new List<BookReservationInfo>();
        }
    }

    //public class BookReservationInfo
    //{
    //    public int Id { get; set; }

    //    public int BorrowerID { get; set; }
    //    public string BorrowersName { get; set; }
    //    public string BookName { get; set; }
    //    public int? Qty { get; set; }
    
}