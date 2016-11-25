using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmbeddedStock.DataAccess.Models
{
    public class ComponentType
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string ComponentName { get; set; }
        public string ComponentInfo { get; set; }
        public virtual ComponentCategory Category { get; set; }
        public int CategoryId { get; set; }
        public string DataSheet { get; set; }
        public byte[] Image { get; set; }
        public string ManufacturerLink { get; set; }

    }
}