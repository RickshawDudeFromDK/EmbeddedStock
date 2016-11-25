using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmbeddedStock.Models
{
    public class ComponentCategoryViewModel
    {
        public int Id { get; set; }
        [DisplayName("Category")]
        [Required]
        public string Name { get; set; }
    }
}