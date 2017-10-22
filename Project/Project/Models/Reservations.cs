using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Reservations
    {
        public int Id { get; set; }
        public int accID { get; set; }
        public int bbID { get; set; }
        public int Qty { get; set; }
        public DateTime ReserveDate { get; set; }
        public string BorrowersName { get; set; }
        public string BookTitle { get; set; }
    }
}