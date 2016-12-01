using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmbeddedStockSolution.Models;

namespace EmbeddedStockSolution.Models
{
    public class Category
    {
        public int CategoryId { get; set;}
        public string Name { get; set; }
        public List<CategoryComponentType> CategoryComponentTypes { get; set; }
    }
}
