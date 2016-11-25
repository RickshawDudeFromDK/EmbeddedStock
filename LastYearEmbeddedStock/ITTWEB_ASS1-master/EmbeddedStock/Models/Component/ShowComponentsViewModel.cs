using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmbeddedStock.Models
{
    public class ShowComponentsViewModel
    {
        public ComponentViewModel Component { get; set; }
        public List<ComponentViewModel> Components { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public ShowComponentsViewModel()
        {
            // I just want this here to be able to use LabelFor
            Component = new ComponentViewModel();

            Components = new List<ComponentViewModel>();
        }
    }
}