using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmbeddedStock.DataAccess.Models
{
    public class Loaner
    {

        public int Id { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string StudentNumber { get; set; }
        public string Name { get; set; }

    }
}