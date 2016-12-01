using EmbeddedStockSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmbeddedStockSolution.Models
{
    public class CategoryComponentType
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int ComponentTypeId { get; set; }
        public ComponentType ComponentType { get; set; }
    }
}
