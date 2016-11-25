using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmbeddedStock.Models
{
    public class ComponentTypeViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Serial Number")]
        public string SerialNumber { get; set; }
        [Required]
        [DisplayName("Component Name")]
        public string ComponentName { get; set; }
        [Required]
        [DisplayName("Component Info")]
        public string ComponentInfo { get; set; }
        [DisplayName("Category")]
        public ComponentCategoryViewModel Category { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("Datasheet")]
        public string DataSheet { get; set; }
        [DisplayName("Image")]
        public byte[] ImageByte { get; set; }
        [DisplayName("Image")]
        [Required]
        public HttpPostedFileBase ImageFile { get; set; }
        [Required]
        [DisplayName("Manufacturer Link")]
        public string ManufacturerLink { get; set; }
        public List<ComponentCategoryViewModel> AvailableCategories { get; set; }

    }
}