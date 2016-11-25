using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmbeddedStock.Models
{
    public class InfoPageViewModel
    {
        public int Id { get; set; }
        [AllowHtml]
        [DisplayName("About page content")]
        public string PageContent { get; set; }
    }
}