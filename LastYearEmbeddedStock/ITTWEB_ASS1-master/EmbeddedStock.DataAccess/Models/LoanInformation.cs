using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmbeddedStock.DataAccess.Models
{
    public class LoanInformation
    {
        public int Id { get; set; }
        public int ComponentId { get; set; }
        public virtual Component Component { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsEmailSent { get; set; }
        public DateTime ReservationDate { get; set; }
        public virtual Loaner LoanOwner { get; set; }
        public int LoanOwnerId { get; set; }
    }
}