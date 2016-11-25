using EmbeddedStock.Models.Loan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmbeddedStock.Models
{
    public class ComponentViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Admin Comment")]
        public string AdminComment { get; set; }
        [Required]
        [DisplayName("Component Number")]
        public int ComponentNumber { get; set; }
        [Required]
        [DisplayName("User Comment")]
        public string UserComment { get; set; }
        [DisplayName("Type")]
        public ComponentTypeViewModel Type { get; set; }
        [DisplayName("Type")]
        public int TypeId { get; set; }
        [DisplayName("Loaner")]
        public LoanViewModel Loaner { get; set; }

        public List<ComponentTypeViewModel> AvailableTypes { get; set; }

    }
}