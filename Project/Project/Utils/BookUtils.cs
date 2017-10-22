using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;
using Project.Entity;

namespace Project.Utils
{
    public class BooksUtils
    {
        public static void Save(Books book)
        {
            using (var db = new DatabaseEntities1())
            {
                var book1 = db.Books.FirstOrDefault(x => x.BookId == book.Id);
                if (book1 != null)
                {
                    book1.Title = book.BookTitle;
                    book1.Author = book.BookAuthor;
                    book1.Quantity = book.Qty;
                }
                else
                {
                    db.Books.Add(new Book { Title = book.BookTitle, Author = book.BookAuthor, Quantity = book.Qty });
                }
                db.SaveChanges();
            }
        }

        //public static void UpdateBookQuantity(Books book)
        //{ 
        //    using (var db = new DatabaseEntities1())
        //    {
        //        var bk = db.Books.FirstOrDefault(x => x.BookId == book.Id);
        //        if (bk != null)
        //        {
        //            bk.Quantity = bk.Quantity - quantity;
        //        }
        //    }
        //}

        public static void DeleteConfirm(int id)
        {
            using (var db = new DatabaseEntities1())
            {
                var selected = db.Books.FirstOrDefault(x => x.BookId == id);
                    if(selected != null)
                    {
                        db.Books.Remove(selected);
                        db.SaveChanges();
                    }
            }
        }

        public static List<Books> GetBooks(int id)
        {
            using (var db = new DatabaseEntities1())
            {
                if (id != 0)
                {
                    var a = db.Books.Where(i => i.BookId == id);
                    return a.Select(b => new Books { Id = b.BookId, BookTitle = b.Title, BookAuthor = b.Author, Qty = b.Quantity }).ToList();

                }
                else
                {
                    return db.Books.Select(b => new Books { Id = b.BookId, BookTitle = b.Title, BookAuthor = b.Author, Qty = b.Quantity }).ToList();
                }
            }
        }
    }
}