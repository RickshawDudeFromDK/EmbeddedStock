using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EmbeddedStock.Models
{
    public class ShowCategoriesViewModel
    {
        [DisplayName("Category")]
        public ComponentCategoryViewModel Category { get; set; }
        public List<ComponentCategoryViewModel> Categories { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public ShowCategoriesViewModel()
        {
            // I just want this here to be able to use LabelFor
            Category = new ComponentCategoryViewModel();

            Categories = new List<ComponentCategoryViewModel>();
        }
    }
}