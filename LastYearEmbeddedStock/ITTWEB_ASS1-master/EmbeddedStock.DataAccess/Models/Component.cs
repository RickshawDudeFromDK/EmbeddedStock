using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmbeddedStock.DataAccess.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string AdminComment { get; set; }
        public int ComponentNumber { get; set; }
        public string UserComment { get; set; }
        public virtual ComponentType Type { get; set; }
        public int TypeId { get; set; }
        public int? LoanerId { get; set; }
        public virtual Loaner Loaner { get; set; }
    }
}