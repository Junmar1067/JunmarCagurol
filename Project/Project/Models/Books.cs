using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public int Qty { get; set; }
    }
}