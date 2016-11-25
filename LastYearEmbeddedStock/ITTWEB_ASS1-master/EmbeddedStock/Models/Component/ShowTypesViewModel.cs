using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmbeddedStock.Models
{
    public class ShowTypesViewModel
    {
        public ComponentTypeViewModel Type { get; set; }
        public List<ComponentTypeViewModel> Types { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public ShowTypesViewModel()
        {
            // I just want this here to be able to use LabelFor
            Type = new ComponentTypeViewModel();

            Types = new List<ComponentTypeViewModel>();
        }
    }
}